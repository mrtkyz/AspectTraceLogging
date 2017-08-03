using Common.Dto;
using Nest;
using System;

namespace Common.DataLayer
{
    [Serializable]
    public class ElasticSearchProvider
    {
        private static ElasticSearchProvider _instance = null;
        private static object _lockObject = new object();
        private ElasticClient elasticClient = null;

        internal ElasticSearchProvider()
        {
            elasticClient = new ElasticClient(new ConnectionSettings(new Uri("http://localhost:9200")));
        }

        internal static ElasticSearchProvider GetInstance()
        {
            if (_instance == null)
                lock (_lockObject)
                {
                    if (_instance == null)
                        _instance = new ElasticSearchProvider();
                }

            return _instance;
        }

        internal void AddLog(CustomTraceLogModel customTraceLogModel)
        {
            var res =  elasticClient.Index(customTraceLogModel, i=>i.Index("").Type("vdf-trace-logging").Id(DateTime.Now.ToString("yyyyMMdd-hhmmffffff")));
        }
    }
}
