using AOPVSMSample.Dto;
using Nest;
using System;
using System.Threading.Tasks;

namespace AOPVSMSample.DataLayer
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

        internal async Task AddLog(CustomTraceLogModel customTraceLogModel)
        {
            var request = new IndexRequest<CustomTraceLogModel>("vdf-logging", "vdf-trace-logging", DateTime.Now.ToString("yyyyMMdd-hhmmffffff"));

            await elasticClient.IndexAsync(customTraceLogModel);
        }
    }
}
