using DMS.Services.Application.Contracts.Persistence;
using DMS.Services.Application.Features;
using DMS.Services.Domain.Entities;
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

        public async Task<List<Donor>> GetAllDonors()
        {
            var result = await _dmsAppDBContext.DonorInfo
                                         .FromSqlRaw<Donor>($"SELECT Id,DonorId,Type,Name,[Location],[Centre],[FollowUpDate],'DonorProfile' As DonorType FROM [DonorInfo] UNION ALL " +
                                            $"SELECT Id,DonorId,'' AS [Type],FirstName + '-' + LastName AS [Name], '' AS [Location],'' AS [Centre],'' AS [FollowUpDate],'KindDonor' As DonorType FROM [KindDonorInfo]"
                                                
                                         )
                                         .Select(p => new Donor
                                         {
                                             Id = p.Id,
                                             DonorId = p.DonorId,
                                             Type = p.Type,
                                             Name=p.Name,
                                             //PanCard =p.PanCard,
                                             //Category = p.Category,
                                             //ReferedBy =p.ReferedBy,
                                             //RelationShipManager =p.RelationShipManager,
                                             //SourceOfPayment =p.SourceOfPayment,
                                             //Purpose=p.Purpose,
                                             Location=p.Location,
                                             Centre= p.Centre,
                                             //Comment=p.Comment,
                                             FollowUpDate=p.FollowUpDate,
                                             DonorType =p.DonorType
                                         }).ToListAsync<Donor>();

            return result;
        }

        public async Task<int> GetMaxId()
        {
            var itemsExist = await _dmsAppDBContext.DonorInfo.AnyAsync();

            int maxDonorId = (!itemsExist) ? 1 : await _dmsAppDBContext.DonorInfo.MaxAsync(x => x.Id) + 1;

            return maxDonorId;
        }
    }
}
