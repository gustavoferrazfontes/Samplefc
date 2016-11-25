using SampleFC.SharedKernel.Events;
using SampleFC.SharedKernel.Interfaces;

namespace SampleFC.RegisterAuthentication.Core.ApplicationLayer.Services
{
    public class UseCaseBase
    {
        private readonly IUnitOfWork _uow;
        private readonly INotifiable<DomainNotification> _notifacoesDeDominio;

        public UseCaseBase(IUnitOfWork uow, INotifiable<DomainNotification> notifacoesDeDominio)
        {
            _uow = uow;
            _notifacoesDeDominio = notifacoesDeDominio;
        }
        public bool Commit()
        {
            if (_notifacoesDeDominio.HasNotifications())
            {
                _uow.Rollback();
                return false;
            }
            else
            {
                _uow.Commit();
                return true;
            }
        }
    }
}
