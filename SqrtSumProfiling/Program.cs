using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using SqrtSumProfiling.Profiler;
using SqrtSumProfiling.ProfilingTask;

namespace AnagramsFinderProfiling
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var testSet = SqrtSum.GetTestSet(50000, 250);

            Console.WriteLine("Calculate...");

            var oneThreadProfile = new Profiler().Measures(testSet, 1, 30, Color.Red, "one thread", SqrtSum.AutomaticSqrtSum);
            var twoThreadProfile = new Profiler().Measures(testSet, 2, 30, Color.Blue, "two thread", SqrtSum.AutomaticSqrtSum);
            var fourThreadProfile = new Profiler().Measures(testSet, 4, 30, Color.Green, "four thread", SqrtSum.AutomaticSqrtSum);

            Console.WriteLine("Calculating Complete!");

            var chart = new ChartBuilder().Build(oneThreadProfile, twoThreadProfile, fourThreadProfile);

            var form = new Form { ClientSize = new Size(1024, 768) };
            chart.Dock = DockStyle.Fill;
            form.Controls.Add(chart);
            Application.Run(form);
        }                

        

    }
}
