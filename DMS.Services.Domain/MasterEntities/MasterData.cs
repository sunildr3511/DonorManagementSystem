using DMS.Services.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Domain.MasterEntities
{
    public class MasterData
    {
        public int Id { get; set; }

        public string Value { get; set; }

        public bool IsActive { get; set; }
    }


    public class SysConfigMasterData
    {
        public IEnumerable<MasterData> Locations { get; set; }
        public IEnumerable<MasterData> DonorType { get; set; }
        public IEnumerable<MasterData> DonorCategory { get; set; }

        public IEnumerable<MasterData> Salutation { get; set; }

        public IEnumerable<MasterData> SourceOfPayment { get; set; }

        public IEnumerable<MasterData> Purpose { get; set; }

        public IEnumerable<MasterData> Documents { get; set; }

        public IEnumerable<MasterData> Roles { get; set; }

        public IEnumerable<MasterData> DonationReceived { get; set; }

    }
}
