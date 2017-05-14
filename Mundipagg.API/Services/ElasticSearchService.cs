using System;
using System.Collections.Generic;
using System.Linq;
using Mundipagg.API.Models;
using Nest;

namespace Mundipagg.API.Services
{
    public class ElasticSearchService : ISearchService<Pessoa>
    {
        private readonly IElasticClient client;

        public ElasticSearchService()
        {
            client = ElasticConfig.GetClient();
        }

        public SearchResult<Pessoa> Search(string query, int page, int pageSize)
        {
            var result = client.Search<Pessoa>(x => x.Query(q => q
                                                        .MultiMatch(mp => mp
                                                            .Query(query)
                                                                .Fields(f => f
                                                                    .Fields(f1 => f1.uid, f2 => f2.Nome, f3 => f3.Sobrenome))))
                                                    .Aggregations(a => a
                                                        .Terms("by_tags", t => t
                                                            .Field(f => f.Nome)
                                                            .Size(10)))
                                                    .From(page - 1)
                                                    .Size(pageSize));

            return new SearchResult<Pessoa>
            {
                Total = (int)result.Total,
                Page = page,
                Results = result.Documents,
                ElapsedMilliseconds = result.Took,
                AggregationsByTags = result.Aggs.Terms("by_tags").Buckets.ToDictionary(x => x.Key, y => y.DocCount.GetValueOrDefault(0))
            };
        }

        //public SearchResult<Pessoa> SearchByCategory(string query, IEnumerable<string> tags, int page = 1,
        //    int pageSize = 10)
        //{

        //    var filters = tags.Select(c => new Func<QueryContainerDescriptor<Post>, QueryContainer>(x => x.Term(f => f.Tags, c))).ToArray();
            
        //    var result = client.Search<Post>(x => x
        //        .Query(q => q
        //            .Bool(b => b
        //                .Must(m => m
        //                    .MultiMatch(mp => mp
        //                        .Query(query)
        //                            .Fields(f => f
        //                                .Fields(f1 => f1.Title, f2 => f2.Body, f3 => f3.Tags))))
        //                .Filter(f => f
        //                    .Bool(b1 => b1
        //                        .Must(filters)))))
        //        .Aggregations(a => a
        //            .Terms("by_tags", t => t
        //                .Field(f => f.Tags)
        //                .Size(10)
        //            )
        //        )
        //        .From(page - 1)
        //        .Size(pageSize));

        //    return new SearchResult<Post>
        //    {
        //        Total = (int)result.Total,
        //        Page = page,
        //        Results = result.Documents,
        //        ElapsedMilliseconds = result.Took,
        //        AggregationsByTags = result.Aggs.Terms("by_tags").Buckets.ToDictionary(x => x.Key, y => y.DocCount.GetValueOrDefault(0))
        //    };
        //}

        //public IEnumerable<string> Autocomplete(string query)
        //{
        //    var result = client.Suggest<Post>(x => x.Completion("tag-suggestions", c => c.Text(query)
        //        .Field(f => f.Suggest)
        //        .Size(6)));

        //    return result.Suggestions["tag-suggestions"].SelectMany(x => x.Options).Select(y => y.Text);
        //}

        //public IEnumerable<string> Suggest(string query)
        //{
        //    var result = client.Suggest<Post>(x => x.Term("post-suggestions", t => t.Text(query)
        //        .Field(f => f.Body)
        //        .Field(f => f.Title)
        //        .Field(f => f.Tags)
        //        .Size(6)));

        //    return result.Suggestions["post-suggestions"].SelectMany(x => x.Options).Select(y => y.Text);
        //}

        //public SearchResult<Post> FindMoreLikeThis(string id, int pageSize)
        //{
        //    var result = client.Search<Post>(x => x
        //        .Query(y => y
        //            .MoreLikeThis(m => m
        //                .Like(l => l.Document(d => d.Id(id)))
        //                .Fields(new[] { "title", "body", "tags" })
        //                .MinTermFrequency(1)
        //                )).Size(pageSize));

        //    return new SearchResult<Post>
        //    {
        //        Total = (int)result.Total,
        //        Page = 1,
        //        Results = result.Documents
        //    };
        //}

        public Pessoa Get(string id)
        {
            var result = client.Get<Pessoa>(new DocumentPath<Pessoa>(id));
            return result.Source;
        }
    }
}