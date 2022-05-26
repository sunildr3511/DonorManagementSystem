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
        private readonly ISystemConfigurationRepository _systemConfigurationRepository;
        private readonly ICentreRepository _centreRepository;

        public UserListQueryHandler(IMapper mapper, IAsyncRepository<UserInfo> repository, 
                                    ISystemConfigurationRepository systemConfigurationRepository,
                                    ICentreRepository centreRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _systemConfigurationRepository = systemConfigurationRepository;
            _centreRepository = centreRepository;

        }
        public async Task<List<UserListVM>> Handle(UserListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var allUsers = await _repository.ListAllAsync();

                List<UserListVM> allUsersVM = new List<UserListVM>();

                allUsersVM.Add(new UserListVM
                {
                    Id = 0
                }); 

                foreach(var user in allUsers)
                {
                    UserListVM userListVM = new UserListVM();
                    userListVM.Id = user.Id;
                    userListVM.Name = user.Name;
                    userListVM.Gender = user.Gender;
                    userListVM.Email = user.Email;
                    userListVM.Mobile = user.Mobile;
                    userListVM.Department = user.Department;
                    userListVM.ReportingManagerCode = user.ReportingManagerCode;
                    userListVM.ReportingManagerName = user.ReportingManagerName;
                    userListVM.ReportingManagerEmail = user.ReportingManagerEmail;
                    userListVM.ReportingManagerMobile = user.ReportingManagerMobile;
                    userListVM.RoleId = user.RoleId;
                    userListVM.LocationId = user.LocationId;
                    userListVM.CenterId = user.CenterId;
                    userListVM.Zone = user.Zone;
                    userListVM.IsActive = user.IsActive;
                    userListVM.RoleName = _systemConfigurationRepository.FetchNameBasedOnId(user.RoleId).Result;
                    userListVM.LocationName = _systemConfigurationRepository.FetchNameBasedOnId(user.LocationId).Result;
                    userListVM.CenterName = _centreRepository.FetchCenterNameBasedOnId(user.CenterId).Result;
                    allUsersVM.Add(userListVM);
                }

                return allUsersVM;
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
