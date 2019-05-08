using Diagrammer.Api;
using System;

namespace Diagrammer.Charts {
    [Serializable]
    public abstract class BarChart: Chart {

        public BarChart(): base() { }

        public BarChart(params DataSeries[] dataSeries): base(dataSeries) { }

        public BarChart(string title, params DataSeries[] dataSeries) : base(title, dataSeries) { }
    }
}
