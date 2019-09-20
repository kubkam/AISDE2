using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISDE2
{
    class Simulator
    {
        private Player player = new Player();
        private Random rand = new Random();
        private Random rand2 = new Random();
        private List<Event> events = new List<Event>();
        private int currentSpeed;
        private float currentTime, loadTime;
        private Event lastDownloading;
        private readonly int BufferMaxSize = 20;

        public List<float> times = new List<float>();
        public List<float> bufferlenght = new List<float>();
        public List<int> speeds = new List<int>();

        int randTime(int time)
        {
            return rand.Next(5, time - 5);
        }

        int randSpeed()
        {
            return rand2.Next(0, 10) < 4 ? 5 : 10;
            //return rand2.Next(1, 20);
        }

        void Sort()
        {
            events.Sort((e1, e2) => e1.EndTime.CompareTo(e2.StartTime));
        }

        public void Startsimulation(int totalTime)
        {
            //currentSpeed = 5;
            currentSpeed = randSpeed();
            float lasttime = 0;
            events.Add(new Event("load", 0));

            
            for (int i = 0; i < 20; i++)
            {
                var tmpTime = randTime(totalTime);
                events.Add(new Event("change speed", tmpTime));
            }
            

            while (currentTime < totalTime)
            {
                Sort();
                Event lastEvent = events[0];

                lasttime = currentTime;
                currentTime = lastEvent.EndTime;

                Console.WriteLine(currentTime);
                events.Remove(lastEvent);

                if (lastEvent.Type == "load")
                {
                    var tmpEvent = new Event("downloaded", new Segment(6), currentSpeed, currentTime);
                    events.Add(tmpEvent);
                    lastDownloading = tmpEvent;
                }

                if (lastEvent.Type == "downloaded")
                {
                    player.BufferSize += lastEvent.Segment.LENGTH;
                    //events.Add(new Event("load", currentTime));
                    if (player.BufferSize > BufferMaxSize) //kiedy buffersize jest wiekszy niz dopuszczlany
                    {
                        loadTime = player.BufferSize - BufferMaxSize;
                        //currentTime += loadTime;
                        events.Add(new Event("load", currentTime + loadTime));

                    }
                    else
                    {

                        events.Add(new Event("load", currentTime));
                    }
                }

                if (lastEvent.Type == "change speed")
                {
                    int newSpeed = randSpeed();
                    float t = currentTime - lastEvent.StartTime;
                    float downloadedPart = t * currentSpeed;
                    float size = lastDownloading.Segment.Size;
                    float t2 = (size - downloadedPart) / newSpeed;
                    lastDownloading.EndTime = (currentTime + t2);
                    currentSpeed = newSpeed;
                }

                //var distance = currentTime - lastEvent.getStartTime();
                var distance = currentTime - lasttime;
                //var distance = currentTime - lastEventTime;
                if (distance > player.BufferSize)
                {
                    player.BufferSize = 0;
                }
                else
                {
                    player.BufferSize -= distance;
                }

                times.Add(currentTime);
                bufferlenght.Add(player.BufferSize);
                speeds.Add(currentSpeed);

            }
        }
    }
}
