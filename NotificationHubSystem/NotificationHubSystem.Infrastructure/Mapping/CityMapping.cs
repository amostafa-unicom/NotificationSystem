using AutoMapper;
using NotificationHubSystem.Core.Entities;

namespace NotificationHubSystem.Infrastructure.Mapping
{
    public class CityMapping : Profile
    {
        #region Constructor
        public CityMapping()
        {
            //CreateCityMap();
            //GetCityDetailsMap();
        }
        #endregion
        #region Private - Method
        //private IMappingExpression<City, CreateCityDto> CreateCityMap()
        //{
        //    return CreateMap<CreateCityDto, City>()
        //        .ForMember(x => x.Name, opt => opt.MapFrom(o => o.Name))
        //        .ReverseMap();
        //}
        //private IMappingExpression<City, CityDto> GetCityDetailsMap()
        //{
        //    return CreateMap<CityDto, City>().ReverseMap()
        //        .ForMember(x => x.Id, opt => opt.MapFrom(o => o.Id))
        //        .ForPath(x => x.Name, opt => opt.MapFrom(o => o.Name));
        //}
        #endregion
    }
}
