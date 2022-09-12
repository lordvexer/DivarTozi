using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Iptb.DivarTozi.AgahiHa
{
    public class Agahi : FullAuditedAggregateRoot<Guid>
    {
        public Guid RegionId { get; set; }
        public string Title { get; set; }
        public string  OfficeName { get; set; }
        public string Brief { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ICollection<AgahiDastebandi> DastebandiHa { get; private set; }

        private Agahi()
        {
        }

        public Agahi(
            Guid id, 
            Guid regionId, 
            string title, 
            string officeName, 
            string brief, 
            DateTime releaseDate) 
            : base(id)
        {
            RegionId = regionId;
            SetTitle(title);
            OfficeName = officeName;
            Brief = brief;
            ReleaseDate = releaseDate;

            DastebandiHa = new Collection<AgahiDastebandi>();
        }

        public void SetTitle(string title)
        {
            Title = Check.NotNullOrWhiteSpace(title, nameof(title), AgahiConsts.MaxTitleLength);
        }

        public void AddDastebandi(Guid DastebandiId)
        {
            Check.NotNull(DastebandiId, nameof(DastebandiId));

            if (IsInDastebandi(DastebandiId))
            {
                return;
            }
            
            DastebandiHa.Add(new AgahiDastebandi(AgahiId: Id, DastebandiId));
        }

        public void RemoveDastebandi(Guid DastebandiId)
        {
            Check.NotNull(DastebandiId, nameof(DastebandiId));

            if (!IsInDastebandi(DastebandiId))
            {
                return;
            }

            DastebandiHa.RemoveAll(x => x.DastebandiId == DastebandiId);
        }

        public void RemoveAllDastebandiHaExceptGivenIds(List<Guid> DastebandiIds)
        {
            Check.NotNullOrEmpty(DastebandiIds, nameof(DastebandiIds));
            
            DastebandiHa.RemoveAll(x => !DastebandiIds.Contains(x.DastebandiId));
        }

        public void RemoveAllDastebandiHa()
        {
            DastebandiHa.RemoveAll(x => x.AgahiId == Id);
        }

        private bool IsInDastebandi(Guid DastebandiId)
        {
            return DastebandiHa.Any(x => x.DastebandiId == DastebandiId);
        }
    }
}