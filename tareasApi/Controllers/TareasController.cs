using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Xml.Serialization;
using tareasApi.models;

namespace tareasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {
        //Variable de contexto de BD
        private readonly Bdtareas903Context _baseDatos;
        public TareasController(Bdtareas903Context baseDatos)
        {
            this._baseDatos = baseDatos;
        }

        

    }
}
