using Iptb.DivarTozi.AgahiHa.Dtos;
using Iptb.DivarTozi.Web.Pages.AgahiHa.Agahi.ViewModels;
using Iptb.DivarTozi.DastebandiHa.Dtos;
using Iptb.DivarTozi.Web.Pages.DastebandiHa.Dastebandi.ViewModels;
using Iptb.DivarTozi.MantageHa.Dtos;
using Iptb.DivarTozi.Web.Pages.MantageHa.Mantage.ViewModels;
using Iptb.DivarTozi.AgahiHa.Dtos;
using Iptb.DivarTozi.Web.Pages.AgahiHa.AgahiAttachment.ViewModels;
using AutoMapper;

namespace Iptb.DivarTozi.Web;

public class DivarToziWebAutoMapperProfile : Profile
{
    public DivarToziWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.
        CreateMap<AgahiDto, CreateEditAgahiViewModel>();
        CreateMap<CreateEditAgahiViewModel, CreateUpdateAgahiDto>();
        CreateMap<DastebandiDto, CreateEditDastebandiViewModel>();
        CreateMap<CreateEditDastebandiViewModel, CreateUpdateDastebandiDto>();
        CreateMap<MantageDto, CreateEditMantageViewModel>();
        CreateMap<CreateEditMantageViewModel, CreateUpdateMantageDto>();
        CreateMap<AgahiAttachmentDto, CreateEditAgahiAttachmentViewModel>();
        CreateMap<CreateEditAgahiAttachmentViewModel, CreateUpdateAgahiAttachmentDto>();
    }
}
