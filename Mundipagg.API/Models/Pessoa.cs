using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mundipagg.API.Models
{
    public class Pessoa
    {
        public int SequencialPessoa { get; set; }
        public int SequencialPessoaDivida { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string ValorPago { get; set; }
    }
}