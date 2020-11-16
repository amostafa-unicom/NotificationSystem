using System.Threading.Tasks;

namespace NotificationHubSystem.SharedKernal
{
    public interface IUseCaseResponseHandler</*out*/ TUseCaseResponse> 
    {
        Task<bool> HandleUseCase(IOutputPort<ResultDto<TUseCaseResponse>> _response);
    }
}
