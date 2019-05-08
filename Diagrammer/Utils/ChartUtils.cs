using Diagrammer.Api;
using Diagrammer.Charts;
using System;

namespace Diagrammer.Utils {
    public enum ChartType {
        None = -1,
        VBar,
        HBar,
        Pie,
        Petal
    }

    static class ChartUtils {
        public static string[] ChartNames = new string[] {
            "Vertical bar chart",
            "Horizontal bar chart",
            "Pie chart",
            "Petal chart"
        };

        // Yes, we can use reflection to get all types, derrived from Chart, but it's so slow
        // And I think, this approach can be easily extended, if you want to add new charts
        public static ChartType ToEnum(Chart c) {
            Type t = c.GetType();
            
            if (t == typeof(VBarChart)) {
                return ChartType.VBar;
            }
            if (t == typeof(HBarChart)) {
                return ChartType.HBar;
            }
            if (t == typeof(PieChart)) {
                return ChartType.Pie;
            }
            if (t == typeof(PetalChart)) {
                return ChartType.Petal;
            }

            return ChartType.None;
        }

        public static Chart ToChart(ChartType type, params DataSeries[] ds) {
            Chart c;
            switch (type) {
                case (ChartType.VBar):
                    c = new VBarChart(ds);
                    break;
                case (ChartType.HBar):
                    c = new HBarChart(ds);
                    break;
                case (ChartType.Pie):
                    c = new PieChart(ds);
                    break;
                case (ChartType.Petal):
                    c = new PetalChart(ds);
                    break;
                default:
                    c = null;
                    break;
            }

            return c;
        }
    }
}
