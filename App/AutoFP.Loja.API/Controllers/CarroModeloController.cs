using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoFP.Loja.API.Attributes;
using AutoFP.Loja.API.Controllers.Base;
using AutoFP.Loja.Crud.Application.Interface.Veiculo;

namespace AutoFP.Loja.API.Controllers
{
    [RoutePrefix("api/v1/automoveis")]
    [AllowAnonymous]
    public class CarroModeloController : BaseController
    {
        private readonly IModeloApplicationService _modeloApplicationService;

        public CarroModeloController(IModeloApplicationService modeloApplicationService)
        {
            _modeloApplicationService = modeloApplicationService;
        }

        [DeflateCompression]
        [Route("carro/{carroId}/modelos"), HttpGet]
        public Task<HttpResponseMessage> Modelo(int carroId)
        {
            try
            {
                var listCarrosModelos = _modeloApplicationService.ModeloAnoPorCarro(carroId);
                return CreateResponse(HttpStatusCode.OK, listCarrosModelos);
            }
            catch (Exception e)
            {
                return CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}