using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SqrtSumProfiling.Profiler
{
    public class ExpirementResultsList
    {
        public readonly string name;
        public readonly Color chartColor;
        public readonly List<ExperimentResult> experimentResults;

        public ExpirementResultsList(string name, Color chartColor, List<ExperimentResult> experimentResults)
        {
            this.name = name;
            this.chartColor = chartColor;
            this.experimentResults = experimentResults;
        }
    }
}
