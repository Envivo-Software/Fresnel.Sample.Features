using System;
using System.Linq;
using Envivo.Fresnel.ModelTypes;
using Envivo.Fresnel.ModelTypes.Interfaces;

namespace Envivo.Fresnel.Sample.Features.Model.K_Charts
{
    public class ChartDemoFactory : IFactory<ChartDemo>
    {
        private readonly Random _Random = new();
        private readonly CalendarFactory _CalendarFactory;

        public ChartDemoFactory(CalendarFactory calendarFactory)
        {
            _CalendarFactory = calendarFactory;
        }

        public ChartDemo Create()
        {
            var daysInOneYear = Enumerable.Range(1, 365).ToArray();

            var result = new ChartDemo()
            {
                Id = Guid.NewGuid(),

                LineChart = CreateLineChart(daysInOneYear),
                ColumnChart = CreateColumnChart(daysInOneYear),
                BarChart = CreateBarChart(daysInOneYear),
                BubbleChart = CreateBubbleChart(daysInOneYear),
                TreeMapChart = CreateTreeMapChart(daysInOneYear),
                GaugeChart = CreateGaugeChart(),
                Calendar = _CalendarFactory.Create(),
            };

            return result;
        }

        private ChartData CreateLineChart(int[] daysInOneYear)
        {
            var randomNumFunc = (int i) => (int)(_Random.NextDouble() * i);

            var chartData = new ChartData
            {
                Id = Guid.NewGuid(),
                ChartType = "Line",
                Series =
                [
                    CreateDataSeries("2024", daysInOneYear, randomNumFunc),
                    CreateDataSeries("2025", daysInOneYear, randomNumFunc)
                ]
            };
            return chartData;
        }

        private ChartData CreateBarChart(int[] daysInOneYear)
        {
            var randomNumFunc = (int i) => (int)(_Random.NextDouble() * i);

            var chartData = new ChartData
            {
                Id = Guid.NewGuid(),
                ChartType = "Bar",
                Series =
                [
                    CreateDataSeries("2020", daysInOneYear, randomNumFunc),
                ]
            };
            return chartData;
        }

        private ChartData CreateBubbleChart(int[] daysInOneYear)
        {
            var randomNumFunc = (int i) => (int)(_Random.NextDouble() * i);

            var points =
                daysInOneYear
                .Take(90)
                .Select(d => new ChartData.DataPoint
                {
                    Id = Guid.NewGuid(),
                    XValue = d,
                    YValue = randomNumFunc(d),
                    Size = d
                })
                .ToArray();

            var series = new ChartData.DataSeries
            {
                Id = Guid.NewGuid(),
                SeriesName = "2020",
                Points = points
            };

            var chartData = new ChartData
            {
                Id = Guid.NewGuid(),
                ChartType = "Bubble",
                Series = [series]
            };
            return chartData;
        }

        private ChartData CreateColumnChart(int[] daysInOneYear)
        {
            var randomNumFunc = (int i) => (int)(_Random.NextDouble() * i);

            var chartData = new ChartData
            {
                Id = Guid.NewGuid(),
                ChartType = "Column",
                Series =
                [
                    CreateDataSeries("2021", daysInOneYear, randomNumFunc),
                    CreateDataSeries("2022", daysInOneYear, randomNumFunc),
                    CreateDataSeries("2023", daysInOneYear, randomNumFunc)
                ]
            };
            return chartData;
        }

        private IChartData CreateGaugeChart()
        {
            var series =
                Enumerable.Range(1, 5)
                .Select(i => new ChartData.DataSeries
                {
                    Id = Guid.NewGuid(),
                    SeriesName = $"Series {i}",
                    Points = [new ChartData.DataPoint
                    {
                        Size = _Random.NextDouble()
                    }]
                })
                .ToArray();

            var chartData = new ChartData
            {
                Id = Guid.NewGuid(),
                ChartType = "Gauge",
                Series = series
            };

            return chartData;
        }

        private ChartData CreateTreeMapChart(int[] daysInOneYear)
        {
            var randomNumFunc = (int i) => (int)(_Random.NextDouble() * i);

            var points =
                daysInOneYear
                .Take(90)
                .Select(d => new ChartData.DataPoint
                {
                    Id = Guid.NewGuid(),
                    PointName = $"Day {d}",
                    Size = randomNumFunc(100),
                })
                .ToArray();

            var series = new ChartData.DataSeries
            {
                Id = Guid.NewGuid(),
                SeriesName = "Q1 Breakdown",
                Points = points
            };

            var chartData = new ChartData
            {
                Id = Guid.NewGuid(),
                ChartType = "Treemap",
                Series = [series]
            };

            return chartData;
        }

        private static ChartData.DataSeries CreateDataSeries(string seriesName, int[] xValues, Func<int, int> randomNumFunc)
        {
            var dataPoints =
                xValues
                .Select(d => new ChartData.DataPoint
                {
                    Id = Guid.NewGuid(),
                    XValue = d,
                    YValue = randomNumFunc(d)
                })
                .ToArray();

            var result = new ChartData.DataSeries
            {
                Id = Guid.NewGuid(),
                SeriesName = seriesName,
                Points = dataPoints
            };
            return result;
        }
    }
}
