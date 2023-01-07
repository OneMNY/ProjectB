using AutoMapper;
using BusinessLogicLibrary.Model;

namespace BusinessLogicLibrary.Application
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<OrderHeaderDto, OrderHeaderModel>()
                .ForMember(d => d.TransportMode, opt => opt.MapFrom(s => s.Transportation.Mode))
                .ForMember(d => d.CarrierId, opt => opt.MapFrom(s => s.Carrier.ID))
                .ForMember(d => d.CarrierName, opt => opt.MapFrom(s => s.Carrier.Name))
                .ForMember(d => d.CarrierAddress, opt => opt.MapFrom(s => s.Carrier.Address))
                .ForMember(d => d.ConsigneeId, opt => opt.MapFrom(s => s.Consignee.ID))
                .ForMember(d => d.ConsigneeName, opt => opt.MapFrom(s => s.Consignee.Name))
                .ForMember(d => d.ConsigneeAddress, opt => opt.MapFrom(s => s.Consignee.Address))
                .ReverseMap();

            CreateMap<OrderDetailDto, OrderDetailModel>()
                .ReverseMap();
        }
    }
}
