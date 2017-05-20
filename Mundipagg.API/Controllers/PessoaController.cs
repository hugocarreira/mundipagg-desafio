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
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class PessoaController : ApiController
    {
        private ElasticClient service;

        public PessoaController()
        {
            var settings = new ConnectionSettings(new Uri("http://localhost:9200")).DefaultIndex("api");
            service = new ElasticClient(settings);
        }

        #region Métodos p/ Pessoas

        [HttpPost]
        public IHttpActionResult setPessoa(Pessoa pessoa)
        {
            var indexResponse = service.Index(pessoa);
            return Ok(indexResponse);
        }

        public IHttpActionResult getPessoas()
        {
            var searchResponse = service.Search<Pessoa>(s => s.MatchAll());

            return Ok(searchResponse.Documents);
        }

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

        [HttpPost]
        public IHttpActionResult getBySobrenome([FromBody] Pessoa pessoa)
        {
            var searchResponse = service.Search<Pessoa>(s => s
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.Sobrenome)
                        .Query(pessoa.Sobrenome)
                    )
                )
            );

            return Ok(searchResponse.Documents);
        }

        #endregion
    }
}
