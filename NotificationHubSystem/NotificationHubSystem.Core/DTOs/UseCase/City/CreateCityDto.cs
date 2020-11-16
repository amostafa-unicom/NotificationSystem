using NotificationHubSystem.SharedKernal.Enum;
using NotificationHubSystem.SharedKernal.Helper;

namespace NotificationHubSystem.Core.DTOs.UseCase.City
{
    public class CreateCityDto
    {
        public string Name { get; set; }
    }
    public class CreateCityDtoValidator : SharedKernal.APIConfiguration.Base.BaseValidator<CreateCityDto>
    {
        public CreateCityDtoValidator()
        {
            RuleFor(obj => obj.Name).NotWhiteSpaceOrEmpty(MessageResource.GetMessage(HttpEnum.ResponseStatus.NullValue), MessageResource.GetMessage(HttpEnum.ResponseStatus.EmptyData));
        }
    }
}
