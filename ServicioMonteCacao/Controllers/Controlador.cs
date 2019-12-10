using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ServicioMonteCacao.Controllers
{
    [ApiController]
    
    public class ControladorController : ControllerBase
    {

        [Route("api/hello")]
        [HttpGet]
        public string hello(){
        
            return JsonConvert.SerializeObject("hello");
        }

        [Route("api/listaProductos")]
        [HttpGet]
        public string listaProductos() {
            List<Producto> productos = new List<Producto>();
            ConexionBD conn = new ConexionBD();
            productos = conn.listarProductos();
            conn.cerrar(); 
            
            return JsonConvert.SerializeObject(productos);
        }
        
    }
}
