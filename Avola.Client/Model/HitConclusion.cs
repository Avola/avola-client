namespace Avola.Client.Model
{
    public class HitConclusion
    {
        public string ConclusionName { get; set; }
        public int ConclusionId { get; set; }
        public string DecisionTableName { get; set; }
        public int DecisionTableId { get; set; }
        public int BusinessDataId { get; set; }
        public int RowId { get; set; }
        public string Value { get; set; }
        public int RowOrder { get; set; }
    }
}