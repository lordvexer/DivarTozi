using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using System.Threading;
using Iptb.DivarTozi.DastebandiHa;

namespace Iptb.DivarTozi.AgahiHa
{
    public class AgahiManager : DomainService
    {
        private readonly IAgahiRepository _AgahiRepository;
        private readonly IRepository<Dastebandi, Guid> _DastebandiRepository;

        public AgahiManager(IAgahiRepository AgahiRepository, IRepository<Dastebandi, Guid> DastebandiRepository)
        {
            _AgahiRepository = AgahiRepository;
            _DastebandiRepository = DastebandiRepository;
        }

        public async Task CreateAsync(
            Guid regionId, 
            string title, 
            string officeName, 
            string brief, 
            DateTime releaseDate, 
            [CanBeNull]string[] DastebandiNames)
        {
            var agahi = new Agahi(GuidGenerator.Create(), regionId, title, officeName, brief, releaseDate);

            await SetDastebandiHaAsync(agahi, DastebandiNames);
            
            await _AgahiRepository.InsertAsync(agahi);
        }

        public async Task UpdateAsync(
            Agahi agahi,
            Guid regionId, 
            string title, 
            string officeName, 
            string brief, 
            DateTime releaseDate,
            [CanBeNull] string[] DastebandiNames
        )
        {
            agahi.RegionId = regionId;
            agahi.SetTitle(title);
            agahi.OfficeName = officeName;
            agahi.Brief = brief;
            agahi.ReleaseDate = releaseDate;
            
            await SetDastebandiHaAsync(agahi, DastebandiNames);

            await _AgahiRepository.UpdateAsync(agahi);
        }
        
        private async Task SetDastebandiHaAsync(Agahi Agahi, [CanBeNull] string[] DastebandiNames)
        {
            if (DastebandiNames == null || !DastebandiNames.Any())
            {
                Agahi.RemoveAllDastebandiHa();
                return;
            }

            var query = (await _DastebandiRepository.GetQueryableAsync())
                .Where(x => DastebandiNames.Contains(x.Name))
                .Select(x => x.Id)
                .Distinct();

            var DastebandiIds = await AsyncExecuter.ToListAsync(query);
            if (!DastebandiIds.Any())
            {
                return;
            }

            Agahi.RemoveAllDastebandiHaExceptGivenIds(DastebandiIds);

            foreach (var DastebandiId in DastebandiIds)
            {
                Agahi.AddDastebandi(DastebandiId);
            }
        }
    }
}