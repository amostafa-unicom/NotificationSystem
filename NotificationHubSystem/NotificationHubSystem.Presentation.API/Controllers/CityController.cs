//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using NotificationHubSystem.Core.DTOs.UseCase.City;
//using NotificationHubSystem.Core.Interfaces.UseCase;
//using NotificationHubSystem.SharedKernal.AppConfiguration.Base;
//using NotificationHubSystem.SharedKernal.Helper.HttpInOutHandler;
//using NotificationHubSystem.SharedKernal.Helper.Pagination;

//namespace NotificationHubSystem.Presentation.API.Controllers
//{
//    [Route("api/[controller]/[action]")]
//    [ApiController]
//    public class CityController : BaseController
//    {
//        #region Properties
//        private ICityUseCase _cityUseCase { get; }
//        #endregion
//        #region Contructor
//        public CityController(ICityUseCase cityUseCase)
//        {
//            _cityUseCase = cityUseCase;
//        }
//        #endregion
//        #region Actions
//        [HttpPost]
//        public async Task<ActionResult<BaseResponseDto<PageList<CityDto>>>> GetAll(BaseRequestDto<SearchCityDto> request)
//        {
//            return await Presenter.Handle(_cityUseCase.GetAll, request);
//        }
//        [HttpPost]
//        public async Task<ActionResult<BaseResponseDto<CityDto>>> Get(BaseRequestDto<CityIdentityDto> request)
//        {
//            return await Presenter.Handle(_cityUseCase.Get, request);
//        }
//        [HttpPost]
//        public async Task<ActionResult<BaseResponseDto<CityDto>>> Post(BaseRequestDto<CreateCityDto> request)
//        {
//            return await Presenter.Handle(_cityUseCase.Create, request);
//        }
//        [HttpPut]
//        public async Task<ActionResult<BaseResponseDto<CityDto>>> Put(BaseRequestDto<UpdateCityDto> request)
//        {
//            return await Presenter.Handle(_cityUseCase.Update, request);
//        }
//        [HttpDelete]
//        public async Task<ActionResult<BaseResponseDto<bool>>> Delete(BaseRequestDto<CityIdentityDto> request)
//        {
//            return await Presenter.Handle(_cityUseCase.Delete, request);
//        }
//        #endregion
//    }
//}
