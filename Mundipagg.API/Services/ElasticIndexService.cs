using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Hosting;
using System.Xml;
using System.Xml.Linq;
using Mundipagg.API.Models;
using Nest;

namespace Mundipagg.API.Services
{
        private readonly IElasticClient client;

        public ElasticIndexService()
        {
            client = ElasticConfig.GetClient();
        }

        public void CreateIndex(string fileName, int maxItems)
        {
            if (!client.IndexExists(ElasticConfig.IndexName).Exists)
            {
                var indexDescriptor = new CreateIndexDescriptor(ElasticConfig.IndexName)
                    .Mappings(ms => ms
                        .Map<Post>(m => m.AutoMap()));

                client.CreateIndex(ElasticConfig.IndexName, i=> indexDescriptor);
            }

        }

    }
}