using DMS.Services.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Domain.MasterEntities
{
    public class MasterData
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }


    public class SysConfigMasterData
    {
        public IEnumerable<string> DonorType { get; set; }
        public IEnumerable<string> DonorCategory { get; set; }

        public IEnumerable<string> Salutation { get; set; }

        public IEnumerable<string> SourceOfPayment { get; set; }

        public IEnumerable<string> Purpose { get; set; }

        public IEnumerable<string> Documents { get; set; }

        public IEnumerable<string> Roles { get; set; }

        public List<Location> Locations { get; set; }

        public IEnumerable<string> DonationReceived { get; set; }

    }
}
