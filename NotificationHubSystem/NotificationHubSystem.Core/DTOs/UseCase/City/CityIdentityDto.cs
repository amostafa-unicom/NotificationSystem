using NotificationHubSystem.SharedKernal.Enum;
using NotificationHubSystem.SharedKernal.Helper;

namespace NotificationHubSystem.Core.DTOs.UseCase.City
{
    public class CityIdentityDto
    {
        public int Id { get; set; }
    }
    public class CityIdentityDtoValidator : SharedKernal.APIConfiguration.Base.BaseValidator<CreateCityDto>
    {
        public CityIdentityDtoValidator()
        {
            RuleFor(obj => obj.Name).NotWhiteSpaceOrEmpty(MessageResource.GetMessage(HttpEnum.ResponseStatus.NullValue), MessageResource.GetMessage(HttpEnum.ResponseStatus.EmptyData));
        }
    }
}
