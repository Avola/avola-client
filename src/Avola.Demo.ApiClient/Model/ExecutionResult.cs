using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avola.Demo.ApiClient.Model
{
    public class ExecutionResult
    {
        public int DecisionTableId { get; set; }
        public int DecisionServiceId { get; set; }

        public ConclusionValueType ConclusionValueType { get; set; }
        public List<HitConclusion> HitConclusions { get; set; }
        public List<ErrorMessage> Errors { get; set; }
        public Dictionary<int, string> BusinessDataValues { get; set; }
    }
}
