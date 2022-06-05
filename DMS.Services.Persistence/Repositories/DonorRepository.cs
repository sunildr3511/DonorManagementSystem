using DMS.Services.Application.Contracts.Persistence;
using DMS.Services.Application.Features;
using DMS.Services.Domain.DataModel;
using DMS.Services.Domain.Entities;
using DMS.Services.Domain.RoleBasedDonors;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.Persistence.Repositories
{
   public class DonorRepository : BaseRepository<Donor>, IDonorRepository
    {
        private readonly DMSAppDbContext _dmsAppDBContext;

        public DonorRepository(DMSAppDbContext dmsAppDBContext) : base(dmsAppDBContext)
        {
            _dmsAppDBContext = dmsAppDBContext;
        }

        public async Task<List<ReportingManagerDonorList>> FetchReportingManagerDonors(int loggedinUserId)
        {
            var donorresult = await (from t1 in _dmsAppDBContext.DonorInfo
                                     join t2 in _dmsAppDBContext.UserInfo
                                     on t1.CreatedBy equals t2.Id
                                     where t2.ReportingManagerCode == loggedinUserId || t2.Id == loggedinUserId
                                                            group t2 by new { t2.Id, t2.Name, t2.ReportingManagerCode } into grouping
                                     select new ReportingManagerDonorList { UserId = grouping.Key.Id, 
                                                                        UserName = grouping.Key.Name, 
                                                                        ReportingManagerCode = grouping.Key.ReportingManagerCode,
                                                                        ReportingManagerName = _dmsAppDBContext.UserInfo.Where(x=>x.Id == grouping.Key.ReportingManagerCode).Select(u=>u.Name).FirstOrDefault(),
                                                                        DonorProfileCount = grouping.Count() }).ToListAsync<ReportingManagerDonorList>();

            var Kinddonorresult = await (from t1 in _dmsAppDBContext.KindDonorInfo
                                         join t2 in _dmsAppDBContext.UserInfo
                                         on t1.CreatedBy equals t2.Id
                                         where t2.ReportingManagerCode == loggedinUserId || t2.Id == loggedinUserId
                                         group t2 by new { t2.Id, t2.Name, t2.ReportingManagerCode } into grouping
                                         select new ReportingManagerDonorList { UserId = grouping.Key.Id, 
                                                                           UserName = grouping.Key.Name, 
                                                                        ReportingManagerCode = grouping.Key.ReportingManagerCode,
                                             ReportingManagerName = _dmsAppDBContext.UserInfo.Where(x => x.Id == grouping.Key.ReportingManagerCode).Select(u => u.Name).FirstOrDefault(),
                                             DonorProfileCount = grouping.Count() }).ToListAsync<ReportingManagerDonorList>();

            var final=  donorresult.Concat(Kinddonorresult)
            .GroupBy(x => new
            {
                x.UserId,
                x.UserName,
                x.ReportingManagerCode,
                x.ReportingManagerName
            }).Select(grp => new ReportingManagerDonorList
            {
                UserId = grp.Key.UserId,
                UserName = grp.Key.UserName,
                ReportingManagerCode = grp.Key.ReportingManagerCode,
                ReportingManagerName = grp.Key.ReportingManagerName,
                DonorProfileCount = grp.Sum(ta => ta.DonorProfileCount)
            }).ToList();

            return final;
        }

        public async Task<List<DonorDM>> GetAllDonors(int loggedinUserId)
        {
            var donorsInfo = await _dmsAppDBContext.DonorInfo.Where(x=>x.CreatedBy== loggedinUserId).Select(p => new DonorDM
            {

                Id = p.Id,
                DonorId = p.DonorId,
                Type = p.Type,
                Name = p.Name,
                Location = p.Location,
                Centre = p.Centre,
                FollowUpDate = p.FollowUpDate,
                DonorType = p.DonorType,
                TypeId =p.TypeId,
                Status = _dmsAppDBContext.DonorCommentInfo.OrderByDescending(x=>x.Id).Where(y=>y.DonorId==p.Id).FirstOrDefault().Status

            }).ToListAsync<DonorDM>();

            return donorsInfo;
        }

        public async Task<int> GetMaxId()
        {
            var itemsExist = await _dmsAppDBContext.DonorInfo.AnyAsync();

            int maxDonorId = (!itemsExist) ? 1 : await _dmsAppDBContext.DonorInfo.MaxAsync(x => x.Id) + 1;

            return maxDonorId;
        }
    }
}
