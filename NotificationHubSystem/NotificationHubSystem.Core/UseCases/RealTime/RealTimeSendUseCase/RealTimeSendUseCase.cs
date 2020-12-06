using Newtonsoft.Json;
using NotificationHubSystem.Core.Base;
using NotificationHubSystem.Core.Entities;
using NotificationHubSystem.Core.Helper.FireBase;
using NotificationHubSystem.SharedKernal;
using NotificationHubSystem.SharedKernal.Settings;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationHubSystem.Core.UseCases.RealTime.RealTimeSendUseCase
{
    internal class RealTimeSendUseCase : BaseUseCase, IRealTimeSendUseCase
    {

        private readonly FireBaseSettings fireBaseSettings;
        public RealTimeSendUseCase(FireBaseSettings _fireBaseSettings)
        {
            fireBaseSettings = _fireBaseSettings;
        }
        public async Task<bool> HandleUseCase(List<NotificationBase> _request, IOutputPort<ResultDto<bool>> _response)
        {
            FirebaseDB firebaseDB = new FirebaseDB(fireBaseSettings.DbURL);

            _request.ForEach(notification =>
            {
                List<string> Nodes = notification.RealTime.Event.Split('/').ToList();

                firebaseDB = firebaseDB.Node(Nodes[0]);
                Nodes.RemoveAt(0);
                Nodes.ForEach(node => { firebaseDB = firebaseDB.NodePath(node); });

                FirebaseResponse putResponse = firebaseDB.Put(JsonConvert.SerializeObject(notification.Body));

                if (putResponse != default && putResponse.Success)
                    notification.StatusId = (byte)SharedKernal.Enum.CommonEnum.SendingStatus.Success;
                else
                {
                    notification.StatusId = (byte)SharedKernal.Enum.CommonEnum.SendingStatus.Failed;
                    notification.Exception = putResponse.ErrorMessage;
                }
            });

            await UnitOfWork.Commit();

            _response.HandlePresenter(new ResultDto<bool>(true));
            return true;
        }
    }
}
