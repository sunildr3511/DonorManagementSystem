using AutoMapper;
using DMS.Services.Application.Contracts.Persistence;
using DMS.Services.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DMS.Services.Application.Features
{
    public class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, string>
    {
        private readonly IMapper _mapper;
        private readonly IUserInfoRepository _repository;

        public UserCreateCommandHandler(IMapper mapper, IUserInfoRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<string> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                bool isDuplicateUser = await _repository.ValidateDuplicateUserInfoOnAdd(request.Name, request.Email);

                if (isDuplicateUser)
                {
                    return "User with name and email already exist.";
                }

                var mappedUser = _mapper.Map<UserInfo>(request);

                mappedUser.IsDelete = false;

               var userInfo= await _repository.AddAsync(mappedUser);

                return "User successfully created.";
            }
            catch (Exception ex)
            {

                if (ex is Exceptions.ValidationException)
                    throw new Exception(string.Join(",", (ex as Exceptions.ValidationException).ValidationErrors));
                else
                    throw new Exception(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
