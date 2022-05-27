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
    public class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<UserInfo> _repository;

        public UserCreateCommandHandler(IMapper mapper, IAsyncRepository<UserInfo> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<int> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mappedUser = _mapper.Map<UserInfo>(request);

                mappedUser.IsDelete = false;

               var userInfo= await _repository.AddAsync(mappedUser);

                return userInfo.Id;
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
