using System;
using System.Linq;
using Envivo.Fresnel.ModelTypes;
using Envivo.Fresnel.ModelTypes.Interfaces;

namespace Envivo.Fresnel.Sample.Features.Model.K_Charts
{
    public class CalendarFactory : IFactory<Calendar>
    {
        private readonly Random _Random = new();

        public Calendar Create()
        {
            var daysInOneYear = Enumerable.Range(1, 365).ToArray();

            var startOfYear = new DateTime(DateTime.Now.Year, 1, 1);

            var calendarEntries =
                daysInOneYear
                .Select(d => new Calendar.CalendarEntry
                {
                    Id = Guid.NewGuid(),
                    Title = $"Entry for Day {d}",
                    EntryDate = startOfYear.AddDays(d).AddHours(9 + _Random.Next(8)),
                    Duration = TimeSpan.FromHours(1),
                })
                .OrderBy(d => d.Id)
                .Take(90)
                .ToList();

            return new Calendar
            {
                Id = Guid.NewGuid(),
                Title = $"Calendar for {startOfYear.Year}",
                Entries = calendarEntries
            };
        }
    }
}
