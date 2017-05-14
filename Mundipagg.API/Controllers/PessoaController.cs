using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Mundipagg.API.Services;
using Mundipagg.API.Models;

namespace Mundipagg.API.Controllers
{
    public class PessoaController : ApiController
    {
        [HttpGet]
        [Route("pessoas")]
        public IHttpActionResult Buscar(string q, int page = 1, int pageSize = 10)
        {

            var results = service.Search(q, page, pageSize);
            return Ok(results);
        }
    }
}
