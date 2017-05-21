using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mundipagg.API.Models
{
    /// <summary>
    ///  Classe Pessoa
    /// </summary>
    public class Pessoa
    {
        /// <summary>
        ///  SequencialPessoa
        /// </summary>
        public int SequencialPessoa { get; set; }

        /// <summary>
        ///  SequencialPessoaDivida - Relacionamento entre a Pessoa e a Divida (Default: SequencialDivida)
        /// </summary>
        public int SequencialPessoaDivida { get; set; }

        /// <summary>
        ///  Nome
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        ///  Sobrenome
        /// </summary>
        public string Sobrenome { get; set; }

        /// <summary>
        ///  Valor pago pela Pessoa
        /// </summary>
        public string ValorPago { get; set; }

        /// <summary>
        ///  Status da dívida
        /// </summary>
        public int Status { get; set; } = 0;
    }
}