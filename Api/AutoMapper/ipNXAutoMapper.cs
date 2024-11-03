using static System.Runtime.InteropServices.JavaScript.JSType;
using AutoMapper;
using API.Data.Dtos;
using Data.Models.PlanModels;
using Data.Models.CustomerRequestsModels;
using Data.Models.OrderModels;
using Data.Dtos;
using Data.Models.DiscountModel;

namespace API.AutoMapper
{
    public class ipNXAutoMapper : Profile
    {

        public ipNXAutoMapper()
        {
            //Mapping for sign up         
            CreateMap<ResidentialOrderDto, ResidentialOrder>().ReverseMap();
            CreateMap<ResidentialOrder, ResidentialOrderBillingDetail>().ReverseMap();
            CreateMap<ResidentialOrderBillingDetailDto, ResidentialOrderBillingDetail>().ReverseMap();
            CreateMap<ResidentialOrderDto, ResidentialOrderBillingDetailDto>().ReverseMap();//if billing address is same as residential
            CreateMap<ResidentialDocumentUploadDto, ResidentialOrderBillingDetail>().ReverseMap();

            //Mapping for Sme sign up
            CreateMap<SmeOrderDto, SmeOrder>().ReverseMap();
            CreateMap<SmeOrder, SmeOrderBillingDetail>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.SmeId, opt => opt.MapFrom(src => src.Id)).ReverseMap();
            CreateMap<SmeOrderBillingDetailDto, SmeOrderBillingDetail>().ReverseMap();
            CreateMap<SmeOrderDto, SmeOrderBillingDetailDto>().ReverseMap();

            //Mappings for Plans
            CreateMap<PlanDto, Plan>().ReverseMap();
            CreateMap<AddPlanDto, Plan>().ReverseMap();
            CreateMap<PlanTypeDto, PlanType>().ReverseMap();
            CreateMap<ViewPlanTypeDto, PlanType>().ReverseMap();

            //Mapping for CustomerRequests
            CreateMap<RequestForInstallationDto, RequestForInstallation>().ReverseMap();
            CreateMap<RequestCallBackDto, RequestCallBack>().ReverseMap();
   

            //Mapping for Discount
            CreateMap<DiscountDto, Discount>().ReverseMap();

        }
    }
}

