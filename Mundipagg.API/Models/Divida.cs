using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mundipagg.API.Models
{
    public class Divida
    {
        public int SequencialDivida { get; set; }
        public string Local { get; set; }
        public DateTime Data { get; set; }
        public string ValorTotal { get; set; }
        public string Descricao { get; set; }
    }
}