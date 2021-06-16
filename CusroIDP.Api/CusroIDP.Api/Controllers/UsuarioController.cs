using CusroIDP.Api.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CusroIDP.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            List<Usuario> usuarios = new List<Usuario>
            {
                new Usuario{Email ="juanpablomato89@gmail.com",Nombre = "Juan Pablo",Telefono="54744600"},
               new Usuario{Email ="yudi@gmail.com",Nombre = "Yudaisy",Telefono="58311649"}
            };
            return usuarios;
        }
    }
}
