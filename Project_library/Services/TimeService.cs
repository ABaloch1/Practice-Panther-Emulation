using Project_library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_library.Services
{
    internal class TimeService
    {
        private static TimeService? instance;

        private List<Time> timeList;

        public List<Time> Times
        {
            get { return timeList; }
        }

        public static TimeService Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new TimeService();
                }
                return instance;
            }
        }

        private TimeService()
        {
            timeList = new List<Time>()
            {
                new Time{Id = 1, EmployeeId = 1, ProjectId = 1, Hours=1.75M, Narrative = "TEST TIME ENTRY"}
            };
        }

        public Time AddOrUpdate(Time time)
        {
            timeList.Add(time);
            return time;
        }
    }
}
