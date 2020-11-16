using NotificationHubSystem.SharedKernal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotificationHubSystem.SharedKernal
{
    public interface IUseCaseRequestDynamicResponseHandler<in TUseCaseRequest, dynamic>
    {
        Task<bool> HandleUseCase(TUseCaseRequest _request, IOutputPort<ResultDto<dynamic>> _response);
    }
}
