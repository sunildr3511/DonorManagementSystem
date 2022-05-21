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
    public class UserDeleteCommandHandler : IRequestHandler<UserDeleteCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<UserInfo> _repository;
        public UserDeleteCommandHandler(IMapper mapper, IAsyncRepository<UserInfo> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<Unit> Handle(UserDeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var userToDelete = await _repository.GetByIdAsync(request.Id);

                if (userToDelete == null)
                {
                    throw new Exceptions.NotFoundException(nameof(Domain.Entities.UserInfo), Convert.ToString(request.Id));
                }

                _mapper.Map(request, userToDelete, typeof(UserDeleteCommand), typeof(Domain.Entities.UserInfo));

                await _repository.DeleteAsync(userToDelete);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
