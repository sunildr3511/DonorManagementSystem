using AutoMapper;
using DMS.Services.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DMS.Services.Application.Features
{
    public class UserInfoQueryHandler : IRequestHandler<UserInfoQuery, UserInfoVM>
    {
        private readonly IMapper _mapper;
        private readonly IUserInfoRepository _userInfoRepository;
        public UserInfoQueryHandler(IMapper mapper, IUserInfoRepository userInfoRepository)
        {
            _mapper = mapper;
            _userInfoRepository = userInfoRepository;
        }

        public async Task<UserInfoVM> Handle(UserInfoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var loggedInUser = await _userInfoRepository.FetchLoggedInUserInfo(request.UserName,request.Email);

                return _mapper.Map<UserInfoVM>(loggedInUser);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
