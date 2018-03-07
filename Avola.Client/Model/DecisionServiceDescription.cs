﻿using System.Collections.Generic;

namespace Avola.Client.Model
{
    public class DecisionServiceDescription
    {
        public int DecisionServiceId { get; set; }
        public string Name { get; set; }
        public List<DecisionServiceVersionDescription> Versions { get; set; }
    }
}