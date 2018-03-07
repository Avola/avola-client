using System.Collections.Generic;

namespace Avola.Client.Model
{
    public class DecisionServiceVersionDescription
    {
        public int DecisionServiceId { get; set; }
        public string Name { get; set; }
        public int DecisionServiceVersionId { get; set; }
        public int VersionNumber { get; set; }
        public IList<DecisionServiceVersionBusinessData> InputData { get; set; }
        public IList<DecisionServiceVersionBusinessData> OutputData { get; set; }
        public IList<DecisionServiceVersionBusinessData> TraceData { get; set; }
        public IList<DecisionServiceVersionPairData> PairData { get; set; }
        public IList<DecisionServiceVersionListData> ListData { get; set; }
    }

   
}