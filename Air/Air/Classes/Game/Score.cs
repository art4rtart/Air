using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Air
{
    public class Score
    { 
        public double flightDistance = 0;
        public double flightTime = 0;
        public double velocity = 0;
        public int index = 0;

        public Score(double score, double time, double velocity, int index)
        {
            this.flightDistance = score;
            this.flightTime = time;
            this.velocity = velocity;
            this.index = index;
        }
    }
}
