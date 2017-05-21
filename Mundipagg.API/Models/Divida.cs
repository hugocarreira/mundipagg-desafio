using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mundipagg.API.Models
{
    /// <summary>
    ///  Classe Divida
    /// </summary>
    public class Divida
    {
        /// <summary>
        ///  SequencialDivida
        /// </summary>
        public int SequencialDivida { get; set; }

        /// <summary>
        ///  Local
        /// </summary>
        public string Local { get; set; }

        /// <summary>
        ///  Data
        /// </summary>
        public DateTime Data { get; set; }

        /// <summary>
        ///  ValorTotal
        /// </summary>
        public string ValorTotal { get; set; }

        /// <summary>
        ///  Descricao
        /// </summary>
        public string Descricao { get; set; }
    }
}