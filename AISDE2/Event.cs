using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISDE2
{
    class Event
    {
        public string Type { get; set; }
        public float StartTime { get; set; }
        public float EndTime { get; set; }
        public Segment Segment { get; set; }

        public Event(string type, Segment segment, int speed, float startTime)
        {
            EndTime = startTime + (segment.Size / speed);
            this.StartTime = startTime;
            this.Type = type;
            this.Segment = segment;
        }

        public Event(string type, float endTime)
        {
            this.Type = type;
            this.EndTime = endTime;
            this.StartTime = endTime;
        }
    }
}
