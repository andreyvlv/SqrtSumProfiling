using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqrtSumProfiling.ProfilingTask
{
    class SqrtSum
    {
        public static decimal AutomaticSqrtSum(int number, int threads)
        {
            int step = number / threads;
            var results = new List<decimal>();
            Parallel.For(0, threads, i =>
            {
                results.Add(i < threads - 1 ?
                    GetSqrtSum(i * step, i * step + step) :
                    GetSqrtSum(i * step, number));
            });
            return results.Sum();
        }

        static decimal GetSqrtSum(int start, int end)
        {
            decimal result = 0;
            for (int i = start; i < end; i++)
            {
                result += (decimal)Math.Sqrt(i);
            }
            return result;
        }

        public static List<int> GetTestSet(int upperBound, int step)
        {
            var set = new List<int>();
            for (int i = 0; i <= upperBound; i += step)
            {
                set.Add(i);
            }
            return set;
        }
    }
}
