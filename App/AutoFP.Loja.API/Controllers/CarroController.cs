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
    public class CarroController : BaseController
    {
        private readonly ICarroApplicationService _carroApplicationService;
        
        public CarroController(ICarroApplicationService carroApplicationService)
        {
            _carroApplicationService = carroApplicationService;
        }
        
        [DeflateCompression]
        [Route("montadora/{montadoraId}/carros"), HttpGet]
        public Task<HttpResponseMessage> Carro(int montadoraId)
        {
            try
            {
                var listCarros = _carroApplicationService.CarrosPorMontadora(montadoraId);
                return CreateResponse(HttpStatusCode.OK, listCarros);
            }
            catch (Exception e)
            {
                return CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}