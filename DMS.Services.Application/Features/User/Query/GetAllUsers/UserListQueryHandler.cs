using AutoMapper;
using DMS.Services.Application.Contracts.Persistence;
using DMS.Services.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DMS.Services.Application.Features
{
    public class UserListQueryHandler : IRequestHandler<UserListQuery, List<UserListVM>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<UserInfo> _repository;

        public UserListQueryHandler(IMapper mapper, IAsyncRepository<UserInfo> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<List<UserListVM>> Handle(UserListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var allUsers = await _repository.ListAllAsync();

                var allUsersVM = _mapper.Map<List<UserListVM>>(allUsers);

                return allUsersVM.Where(x => x.Name.ToLower() != "admin").ToList();
            }
            catch (Exception ex )
            {

                if (ex is Exceptions.ValidationException)
                    throw new Exception(string.Join(",", (ex as Exceptions.ValidationException).ValidationErrors));
                else
                    throw new Exception(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }

        }
    }
}
