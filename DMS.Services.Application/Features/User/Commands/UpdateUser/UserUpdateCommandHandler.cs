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
   public class UserUpdateCommandHandler : IRequestHandler<UserUpdateCommand,string>
   {
        private readonly IMapper _mapper;
        private readonly IUserInfoRepository _repository;
    public UserUpdateCommandHandler(IMapper mapper, IUserInfoRepository repository)
    {
            _mapper = mapper;
            _repository = repository;
    }
    public async Task<string> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
    {
            try
            {
                var userToUpdate = await _repository.GetByIdAsync(request.Id);

                if (userToUpdate == null)
                {
                    throw new Exceptions.NotFoundException(nameof(Domain.Entities.UserInfo), Convert.ToString(request.Id));
                }

                bool isDuplicateUser = await _repository.ValidateDuplicateUserInfoOnUpdate(request.Email,request.Id);

                if (isDuplicateUser)
                {
                    return "User with email already exist.";
                }

                userToUpdate.IsDelete = false;

                _mapper.Map(request, userToUpdate, typeof(UserUpdateCommand), typeof(Domain.Entities.UserInfo));

                await _repository.UpdateAsync(userToUpdate);

                return "User successfully updated.";
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
