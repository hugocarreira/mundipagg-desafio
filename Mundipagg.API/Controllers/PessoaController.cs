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
    public class PessoaController : ApiController
    {
        private ElasticClient service;
        /// <summary>  
        /// Inicia o ElasticSearch com defaultIndex = api  
        /// </summary>  
        public PessoaController()
        {
            var settings = new ConnectionSettings(new Uri("http://localhost:9200")).DefaultIndex("api");
            service = new ElasticClient(settings);
        }

        #region Métodos p/ Pessoas

        // <summary>
        // Método para criar o Index Pessoa
        // </summary>
        // <param name="Objeto Dívida">Objeto Pessoa (DTO)</param>
        // <returns>Response HTTP</returns>  
        [HttpPost]
        public IHttpActionResult setPessoa(Pessoa pessoa)
        {
            var indexResponse = service.Index(pessoa);
            return Ok(indexResponse);
        }

        // <summary>
        // Método para buscar todas as Pessoas
        // </summary>
        // <returns>Pessoas</returns>
        public IHttpActionResult getPessoas()
        {
            var searchResponse = service.Search<Pessoa>(s => s.MatchAll());

            return Ok(searchResponse.Documents);
        }

        // <summary>
        // Método para buscar Pessoas baseado no SequencialPessoaDivida
        // </summary>
        // <param name="Objeto Dívida">Objeto Dívida (DTO)</param>
        // <returns>Pessoas filtradas pela dívida</returns>
        [HttpPost]
        public IHttpActionResult getbyseq([FromBody] Pessoa pessoa)
        {
            var seqDivida = Convert.ToString(pessoa.SequencialPessoaDivida);

            var searchResponse = service.Search<Pessoa>(s => s
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.SequencialPessoaDivida)
                        .Query(seqDivida)
                    )
                )
            );

            return Ok(searchResponse.Documents);
        }
        #endregion
    }
}
