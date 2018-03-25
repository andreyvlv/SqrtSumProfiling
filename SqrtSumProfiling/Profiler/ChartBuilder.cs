using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ZedGraph;

namespace SqrtSumProfiling.Profiler
{
    class ChartBuilder
    {
        public Control Build(params ExpirementResultsList[] results)
        {
            var graph = new ZedGraphControl();
            var mPane = new MasterPane();
            var pane = new GraphPane();
            pane.CurveList.Clear();
            foreach (var result in results)
            {
                LineItem myCurve = pane.AddCurve(result.name, GetPointList(result.experimentResults), result.chartColor, SymbolType.None);
                myCurve.Line.Width = 2;
                myCurve.Line.IsAntiAlias = true;               
            }          
            mPane.Add(pane);
            graph.MasterPane = mPane;
            graph.AxisChange();
            graph.Invalidate();
            return graph;
        }

        PointPairList GetPointList(List<ExperimentResult> result)
        {
            var list = new PointPairList();
            foreach (var measure in result)
            {
                list.Add(measure.number, measure.time);
            }
            return list;
        }

    }
}