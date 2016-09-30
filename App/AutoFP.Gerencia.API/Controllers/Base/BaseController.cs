using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoFP.SharedKernel.DomainEvents;
using AutoFP.SharedKernel.DomainEvents.Handles;
using AutoFP.SharedKernel.Notification.Event;

namespace AutoFP.Gerencia.API.Controllers.Base
{
    // [Authorize] TODO: Descomentar Authorize
    public class BaseController : ApiController
    {
        private readonly IHandler<DomainNotification> _notifications;
        protected HttpResponseMessage _responseMessage;

        public BaseController()
        {
            _notifications = DomainEvent.Container.GetService<IHandler<DomainNotification>>();
            _responseMessage = new HttpResponseMessage();
        }

        protected Task<HttpResponseMessage> CreateResponse(HttpStatusCode code, object result)
        {
            if (_notifications.HasNotifications())
                _responseMessage = Request.CreateResponse(HttpStatusCode.BadRequest,
                    new { errors = _notifications.Notify() });
            else
                _responseMessage = Request.CreateResponse(code, result);

            return Task.FromResult(_responseMessage);
        }

        protected Task<HttpResponseMessage> CreateErrorResponse(HttpStatusCode code, string message)
        {
            if (_notifications.HasNotifications())
                _responseMessage = Request.CreateResponse(HttpStatusCode.BadRequest,
                    new { errors = _notifications.Notify() });
            else
                _responseMessage = Request.CreateResponse(code);

            // TODO: Inserir log aqui usando message...
            return Task.FromResult(_responseMessage);
        }

        protected override void Dispose(bool disposing)
        {
            _notifications.Dispose();
        }
    }
}