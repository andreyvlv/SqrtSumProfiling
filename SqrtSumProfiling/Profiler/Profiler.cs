using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Drawing;
using System.IO;

namespace SqrtSumProfiling.Profiler
{
    class Profiler
    {                   
        public ExpirementResultsList Measures(List<int> testSet, int threadsCount, int repetitionsCount,
            Color color, string expirementName, Func<int, int, decimal> measurableMethod)
        {
            var results = new List<ExperimentResult>();
            foreach (var number in testSet)
            {
                results.Add(Measure(number, threadsCount, repetitionsCount, measurableMethod));
            }           
            return new ExpirementResultsList(expirementName, color, results);
        }

        ExperimentResult Measure(int number, int threadsCount, int repetionsCount, Func<int, int, decimal> measurableMethod)
        {
            double measureTimes = 0;          
            for (int i = 0; i < repetionsCount; i++)
            {
                Stopwatch sw = new Stopwatch();
                var heating = measurableMethod(number, threadsCount);      
                sw.Start();
                var found = measurableMethod(number, threadsCount);
                sw.Stop();
                measureTimes += sw.Elapsed.TotalMilliseconds;              
            }
            return new ExperimentResult(number, measureTimes / repetionsCount);
        }         
    }
}
