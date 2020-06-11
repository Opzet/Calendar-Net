using System.Collections.Generic;
using System.Linq;

namespace CalendarNet
{
    public class CalendarEvents : List<ICalendarEvent>
    {
        public int GenerateEventId()
        {
            return Count == 0 ? 1 : this.Max(z => z.EventId) + 1;
        }

        public int Add(ICalendarEvent evnt, int id)
        {
            if (this.FirstOrDefault(z => z.EventId == id) != null)
            {
                throw new IdAlreadyExistsException();
            }
            evnt.EventId = id;
            base.Add(evnt);

            return evnt.EventId;
        }

        public new int Add(ICalendarEvent evnt)
        {
            evnt.EventId = GenerateEventId();
            base.Add(evnt);

            return evnt.EventId;
        }

        public void RemoveByEventId(int id)
        {
            if (this.FirstOrDefault(z => z.EventId == id) != null)
            {
                RemoveAll(z => z.EventId == id);
            }
            else
            {
                throw new IdNotFoundException();
            }
        }

        public ICalendarEvent GetByEventId(int id)
        {
            if (this.FirstOrDefault(z => z.EventId == id) != null)
            {
                return this.First(z => z.EventId == id);
            }
            
            throw new IdNotFoundException();
        }
    }
}
