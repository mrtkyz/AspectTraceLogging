using System;
using PostSharp.Aspects;
using AOPVSMSample.DataLayer;
using AOPVSMSample.Dto;
using System.Collections.Generic;
using System.Linq;

namespace AOPVSMSample.Aspects
{
    [Serializable]
    public class LogAttribute : OnMethodBoundaryAspect
    {
        //((System.RuntimeType)((System.Reflection.RuntimeMethodInfo) args.Method).ReturnType).FullName
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
