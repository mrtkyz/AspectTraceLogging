using System;
using System.Collections.Generic;

namespace AOPVSMSample.Dto
{
    [Serializable]
    public class CustomTraceLogModel
    {
        public CustomTraceLogModel()
        {
            DateTime = DateTime.Now;
        }

        public string Index { get; set; }

        public string Type { get; set; }

        public string Id { get; set; }

        public string ClassName { get; set; }

        public string MethodName { get; set; }

        public TraceStatus TraceStatus { get; set; }

        public List<KeyValueModel> Parameters { get; set; }

        public string ReturnType { get; set; }

        public object ReturnValue { get; set; }

        public string StackTrace { get; set; }

        public DateTime DateTime { get; set; }
    }

    public class KeyValueModel
    {
        public string Key { get; set; }

        public string Value { get; set; }
    }

    public enum TraceStatus
    {
        OnEntry,
        OnExit,
        OnException
    }
}
