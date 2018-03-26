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
                var rangeSum = i < threads - 1 ?
                    GetSqrtSum(i * step, i * step + step) :
                    GetSqrtSum(i * step, number);

                lock(results)
                {
                    results.Add(rangeSum);
                }
            });
            return results.Sum();
        }

        // Другой параллельный метод
        public static decimal AutomaticSqrtSum2(int number, int threads)
        {
            int step = number / threads;
            var results = new List<decimal>();
            var threadsArr = new Task[threads];
            foreach (var num in ParallelEnumerable.Range(0, threads))
            {
                threadsArr[num] = Task.Run(() =>
                {
                    var rangeSum = num < threadsArr.Length - 1 ?
                    GetSqrtSum(num * step, num * step + step) :
                    GetSqrtSum(num * step, number);

                    lock (results)
                    {
                        results.Add(rangeSum);
                    }
                });
            }
            Task.WaitAll(threadsArr);
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

        public static List<int> GetTestSet(int lowerBound, int upperBound, int step)
        {
            var set = new List<int>();
            for (int i = lowerBound; i <= upperBound; i += step)
            {
                set.Add(i);
            }
            return set;
        }
    }
}
