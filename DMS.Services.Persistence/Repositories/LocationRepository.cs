using DMS.Services.Application.Contracts.Persistence;
using DMS.Services.Domain.Entities;
using DMS.Services.Domain.MasterEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.Persistence.Repositories
{
    public class LocationRepository : BaseRepository<Location>, ILocationRepository
    {
        private readonly DMSAppDbContext _dmsAppDBContext;
        public LocationRepository(DMSAppDbContext dmsAppDBContext) : base(dmsAppDBContext)
        {
            _dmsAppDBContext = dmsAppDBContext;
        }

        public async Task<List<Location>> GetLocations()
        {
            var result = await _dmsAppDBContext.LocationInfo.Select(x => new Location { 
                                Id=x.Id,
                                Name=x.Name
            
            }).ToListAsync<Location>();

            return result;
        }
    }
}
