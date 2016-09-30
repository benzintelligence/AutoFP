using AutoFP.Infra.Data.Interface;
using AutoFP.SharedKernel.DomainEvents;
using AutoFP.SharedKernel.DomainEvents.Handles;
using AutoFP.SharedKernel.Notification.Event;

namespace AutoFP.Loja.Crud.Application.AppService.Base
{
    public class BaseApplicationService
    {
        private readonly IHandler<DomainNotification> _notifications;
        private readonly IAppDatabase _banco;

        public BaseApplicationService(IAppDatabase banco)
        {
            _banco = banco;
            _notifications = DomainEvent.Container.GetService<IHandler<DomainNotification>>();
        }

        public bool HasNotification()
        {
            return _notifications.HasNotifications();
        }

        public bool Commit()
        {
            if (HasNotification()) return false;

            _banco.Commit();
            return true;
        }

        public void Rollback(string message)
        {
            DomainEvent.Raise<DomainNotification>(new DomainNotification("BusinessError", message));
            _banco.RollBack();
        }

        public void Rollback()
        {
            _banco.RollBack();
        }
    }
}