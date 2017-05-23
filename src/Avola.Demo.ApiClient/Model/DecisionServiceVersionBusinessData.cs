using System.Collections.Generic;

namespace Avola.Demo.ApiClient.Model
{
    public class DecisionServiceVersionBusinessData
    {
        public int BusinessDataId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Question { get; set; }
        public IList<BusinessDataProperty> Properties { get; set; }

    }

    public class DecisionServiceVersionPairData
    {
        public int PairId { get; set; }
        public string ValueForTrue { get; set; }
        public string ValueForFalse { get; set; }
    }

    public class DecisionServiceVersionListData
    {
        public int ListId { get; set; }
        public IList<DecisionServiceVersionListDataItem> Items { get; set; }

    }

    public class DecisionServiceVersionListDataItem
    {
        public int Order { get; set; }
        public string Value { get; set; }
    }

    public class BusinessDataProperty
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}