using DMS.Services.Application.Contracts.Persistence;
using DMS.Services.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.Persistence.Repositories
{
    public class CentreRepository : BaseRepository<Centre>, ICentreRepository
    {
        private readonly DMSAppDbContext _dmsAppDBContext;
        public CentreRepository(DMSAppDbContext dmsAppDBContext) : base(dmsAppDBContext)
        {
            _dmsAppDBContext = dmsAppDBContext;
        }

        public async Task<IEnumerable<Centre>> GetCentresBasedOnLocation(int locationId)
        {

            var centres = await _dmsAppDBContext.CentreInfo.Select(x => new Centre
            {
                Id = x.Id,
                LocationId= x.LocationId,
                Name = x.Name
            }).Where(x => x.LocationId == locationId).ToListAsync<Centre>();

            return centres;
        }
    }
}
