using System;
using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.ModelTypes.Interfaces;

namespace Envivo.Fresnel.Sample.Features.Model.K_Charts
{
    [UiExplorer(preferredSize: UiExplorerSize.Maximised)]
    public class ChartDemo
    {
        public Guid Id { get; set; }

        public IChartData LineChart { get; internal set; }

        public ICalendar Calendar { get; internal set; }

        public IChartData ColumnChart { get; internal set; }

        public IChartData BarChart { get; internal set; }

        public IChartData BubbleChart { get; internal set; }

        public IChartData GaugeChart { get; internal set; }

        public IChartData TreeMapChart { get; internal set; }
    }
}
