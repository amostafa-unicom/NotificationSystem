using FluentValidation;
using NotificationHubSystem.SharedKernal.Enum;
using NotificationHubSystem.SharedKernal.Helper;
using NotificationHubSystem.SharedKernal.Helper.Pagination;

namespace NotificationHubSystem.Core.DTOs.UseCase.City
{
    public class SearchCityDto : PagingModel
    {
        public string Name { get; set; }
    }
    public class SearchCityDtoValidator : SharedKernal.APIConfiguration.Base.BaseValidator<SearchCityDto>
    {
        public SearchCityDtoValidator()
        {
            RuleFor(obj => obj.Index).NotNull().WithMessage(MessageResource.GetMessage(HttpEnum.ResponseStatus.NullValue));
            RuleFor(obj => obj.PageSize).NotDefault(MessageResource.GetMessage(HttpEnum.ResponseStatus.NullValue), MessageResource.GetMessage(HttpEnum.ResponseStatus.EmptyData));
        }
    }
}
