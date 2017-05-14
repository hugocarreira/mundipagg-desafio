using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mundipagg.API.Models
{
    public class Pessoa
    {
        //public int uid { get; set; }
        //public string Nome { get; set; }
        //public string Sobrenome { get; set; }

        public string Id { get; set; }

        public DateTime? CreationDate { get; set; }

        public int? Score { get; set; }

        public int? AnswerCount { get; set; }

        public string Body { get; set; }

        public string Title { get; set; }

        [String(Index = FieldIndexOption.NotAnalyzed)]
        public IEnumerable<string> Tags { get; set; }

        [Completion]
        public IEnumerable<string> Suggest { get; set; }
    }
}