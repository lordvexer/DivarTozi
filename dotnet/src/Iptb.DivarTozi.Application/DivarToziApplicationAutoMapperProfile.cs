using Iptb.DivarTozi.AgahiHa;
using Iptb.DivarTozi.AgahiHa.Dtos;
using Iptb.DivarTozi.DastebandiHa;
using Iptb.DivarTozi.DastebandiHa.Dtos;
using Iptb.DivarTozi.MantageHa;
using Iptb.DivarTozi.MantageHa.Dtos;
using AutoMapper;

namespace Iptb.DivarTozi;

public class DivarToziApplicationAutoMapperProfile : Profile
{
    public DivarToziApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Agahi, AgahiDto>();
        CreateMap<CreateUpdateAgahiDto, Agahi>(MemberList.Source);
        CreateMap<Dastebandi, DastebandiDto>();
        CreateMap<CreateUpdateDastebandiDto, Dastebandi>(MemberList.Source);
        CreateMap<Mantage, MantageDto>();
        CreateMap<CreateUpdateMantageDto, Mantage>(MemberList.Source);
    }
}
