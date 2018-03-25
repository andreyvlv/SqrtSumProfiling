using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqrtSumProfiling.Profiler
{
    public class ExperimentResult
    {
        public readonly int number;
        public readonly double time;       

        public ExperimentResult(int number, double time)
        {
            this.number = number;
            this.time = time;          
        }
    }
}
