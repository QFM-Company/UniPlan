using Core.Entities;
using System.Collections;

namespace Core.Services
{
    public class ScheduleManager : IEnumerable<int>
    {
        private SessionOverlapComparer _sessionOverlapComparer;

        public Dictionary<DayOfWeek, SortedSet<CourseSession>> Schedule { get; }

        public string? ConflictMeesage { get => _sessionOverlapComparer.ConflictMessage; }

        public ScheduleManager()
        {
            Schedule = new Dictionary<DayOfWeek, SortedSet<CourseSession>>();
            _sessionOverlapComparer = new SessionOverlapComparer();
        }

        public ScheduleManager(ScheduleManager schedule)
        {
            _sessionOverlapComparer = new SessionOverlapComparer();

            Schedule = new Dictionary<DayOfWeek, SortedSet<CourseSession>>(schedule.Schedule);
            foreach (var kvp in schedule.Schedule)
            {
                Schedule[kvp.Key] = new SortedSet<CourseSession>(kvp.Value, _sessionOverlapComparer);
            }
        }

        private bool _Add(CourseSession session)
        {
            if(!Schedule.ContainsKey(session.Day))
            {
                Schedule.Add(session.Day, new SortedSet<CourseSession>(_sessionOverlapComparer));
            }

            return Schedule[session.Day].Add(session);
        }

        private bool _Remove(CourseSession session)
        {
            if (Schedule.TryGetValue(session.Day, out var daySessions))
            {
                return daySessions != null && daySessions.Remove(session);
            }

            return false;
        }

        public bool TryAdd(List<CourseSession> sessions)
        {
            int failedIndex = sessions.Count;

            for (int i = 0; i < sessions.Count; i++)
            {
                if (! _Add(sessions[i]))
                {
                    failedIndex = i;
                    break;
                }
            }

            if(failedIndex != sessions.Count)
            {
                for (int i = failedIndex - 1; i >= 0; i--)
                {
                    _Remove(sessions[i]);
                }

                return false;
            }

            return true;
        }

        public void Remove(List<CourseSession> sessions)
        {
            foreach (var session in sessions)
            {
                _Remove(session);
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            HashSet<int> visitedOfferings = new HashSet<int>();

            foreach (var daySchedule in Schedule.Values)
            {
                foreach (var session in daySchedule)
                {
                    var offering = session.CourseOffering;

                    if (offering != null && visitedOfferings.Add(offering.OfferingID))
                    {
                        yield return offering.OfferingID;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
