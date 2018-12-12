using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISDE2
{
    class Segment
    {
        public readonly float LENGTH = 1;
        public float Size { get; set; }

        public Segment(float size)
        {
            this.Size = size;
        }
    }
}
