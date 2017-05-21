using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Mundipagg.API.Models;
using Nest;


namespace Mundipagg.API.Controllers
{
    /// <summary>  
    /// DividaController
    /// </summary>  
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class DividaController : ApiController
    {
        private ElasticClient service;

        /// <summary>  
        /// Inicia o ElasticSearch com defaultIndex = api  
        /// </summary>  
        public DividaController()
        {
            var settings = new ConnectionSettings(new Uri("http://localhost:9200")).DefaultIndex("api");        
            service = new ElasticClient(settings);
        }

        #region Métodos p/ Dividas
        // <summary>
        // Método para criar o Index Dívida
        // </summary>
        // <param name="Objeto Dívida">Objeto Divida (DTO)</param>
        // <returns>Response HTTP</returns>  
        [HttpPost]
        public IHttpActionResult setDivida(Divida divida)
        {
            var indexResponse = service.Index(divida);
            return Ok(indexResponse);
        }

        // <summary>
        // Método para buscar todas as Dividas
        // </summary>
        // <returns>Dívidas</returns>  
        [HttpGet]
        public IHttpActionResult getDivida()
        {
            var searchResponse = service.Search<Divida>(s => s.MatchAll());

            return Ok(searchResponse.Documents);
        }

        // <summary>
        // Método para buscar Dívida baseado no SequencialDivida
        // </summary>
        // <param name="Objeto Dívida">Objeto Dívida (DTO)</param>
        // <returns>Dívidas filtradas</returns>
        [HttpPost]
        public IHttpActionResult getbyseq([FromBody] Divida divida)
        {
            var seqDivida = Convert.ToString(divida.SequencialDivida);

            var searchResponse = service.Search<Divida>(s => s
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.SequencialDivida)
                        .Query(seqDivida)
                    )
                )
            );

            return Ok(searchResponse.Documents);
        }
        #endregion

    }
}
