using System.Collections.Generic;

namespace Avola.Demo.ApiClient.Model
{
    public class ApiExecutionRequest
    {
        public int DecisionServiceId { get; set; }
        public int VersionNumber { get; set; }
        public string Reference { get; set; }
        public IList<ExecutionRequestData> ExecutionRequestData { get; set; }
        public IList<ExecutionRequestData> ExecutionRequestMetaData { get; set; }
    }
}