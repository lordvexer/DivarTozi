using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Auditing;

namespace Iptb.DivarTozi.AgahiHa
{
    public class AgahiBaJoziyat : IHasCreationTime
    {
        public Guid Id { get; set; }
        
        public Guid RegionId { get; set; }
        public string Title { get; set; }
        public string  OfficeName { get; set; }
        public string Brief { get; set; }
        public DateTime ReleaseDate { get; set; }

        public string[] DastebandiNames { get; set; }
        
        public DateTime CreationTime { get; set; }
        public string RegionName { get; set; }
    }
}