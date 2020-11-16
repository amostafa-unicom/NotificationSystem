using NotificationHubSystem.SharedKernal.Enum;
using NotificationHubSystem.SharedKernal.Helper;

namespace NotificationHubSystem.Core.DTOs.UseCase.City
{
    public class UpdateCityDto : CityIdentityDto
    {
        public string Name { get; set; }
    }
    public class UpdateCityDtoValidator : SharedKernal.APIConfiguration.Base.BaseValidator<UpdateCityDto>
    {
        public UpdateCityDtoValidator()
        {
            RuleFor(obj => obj.Id).NotDefault(MessageResource.GetMessage(HttpEnum.ResponseStatus.NullValue), MessageResource.GetMessage(HttpEnum.ResponseStatus.EmptyData));
            RuleFor(obj => obj.Name).NotWhiteSpaceOrEmpty(MessageResource.GetMessage(HttpEnum.ResponseStatus.NullValue), MessageResource.GetMessage(HttpEnum.ResponseStatus.EmptyData));
        }
    }
}
