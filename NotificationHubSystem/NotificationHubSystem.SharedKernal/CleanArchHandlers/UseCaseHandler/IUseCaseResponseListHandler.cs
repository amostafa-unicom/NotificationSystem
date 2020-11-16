using System.Threading.Tasks;

namespace NotificationHubSystem.SharedKernal
{
    public interface IUseCaseResponseListHandler</*out*/ TUseCaseResponse> 
    {
        Task<bool> HandleUseCase(IOutputPort<ListResultDto<TUseCaseResponse>> _response);
    }
}
