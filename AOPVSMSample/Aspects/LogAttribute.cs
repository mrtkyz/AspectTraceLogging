using System;
using PostSharp.Aspects;
using System.Diagnostics;

namespace AOPVSMSample.Aspects
{
    [Serializable]
    public class LogAttribute : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            Trace.Write(string.Format("Method başladı... {0}", args.Method));
            Trace.Write(" Parametreler:");

            for (int i = 0; i < args.Arguments.Count; i++)
            {
                Trace.Write(" " + args.Arguments[i]);
                Trace.WriteIf(i != args.Arguments.Count - 1, ",");
            }

            Trace.Write(Environment.NewLine);
        }


        public override void OnExit(MethodExecutionArgs args)
        {
            Trace.WriteLine(string.Format("method bitti, {0}. cevap: {1}", args.Method, args.ReturnValue));
        }


        public override void OnException(MethodExecutionArgs args)
        {
            Trace.WriteLine(String.Format("Metod hata oluştu. {0}: {1}", args.Method.Name,
                args.Exception.StackTrace));
            args.FlowBehavior = FlowBehavior.Continue;
        }
    }
}
