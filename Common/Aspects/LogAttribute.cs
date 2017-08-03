using PostSharp.Aspects;
using Common.DataLayer;
using Common.Dto;
using PostSharp.Serialization;
using System.Linq;
using System.Collections.Generic;

namespace Common.Aspects
{
    [PSerializable]
    public sealed class LogAttribute : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            ElasticSearchProvider provider = ElasticSearchProvider.GetInstance();

            string[] parameterNames = args.Method.GetParameters().Select(p => p.Name).ToArray();

            var parameters = new List<KeyValueModel>();
            for (int i = 0; i < args.Arguments.Count; i++)
            {
                parameters.Add(new KeyValueModel
                {
                    Key = parameterNames[i].ToString(),
                    Value = args.Arguments[i].ToString()
                });
            }
            provider.AddLog(new CustomTraceLogModel
            {
                ClassName = args.Method.DeclaringType.FullName,
                MethodName = args.Method.Name,
                Parameters = parameters,
                TraceStatus = TraceStatus.OnEntry
            });
        }


        public override void OnExit(MethodExecutionArgs args)
        {
            ElasticSearchProvider provider = ElasticSearchProvider.GetInstance();

            provider.AddLog(new CustomTraceLogModel
            {
                ClassName = args.Method.DeclaringType.FullName,
                MethodName = args.Method.Name,
                ReturnValue = args.ReturnValue,
                TraceStatus = TraceStatus.OnExit
            });
        }


        public override void OnException(MethodExecutionArgs args)
        {
            ElasticSearchProvider provider = ElasticSearchProvider.GetInstance();

            provider.AddLog(new CustomTraceLogModel
            {
                ClassName = args.Method.DeclaringType.FullName,
                MethodName = args.Method.Name,
                ReturnValue = args.ReturnValue,
                StackTrace = args.Exception.StackTrace,
                TraceStatus = TraceStatus.OnException
            });

            args.FlowBehavior = FlowBehavior.Continue;
        }
    }
}
