using System;

namespace MarsRover.Domain.Models
{
    public class Position
    {
        public Position(int x, int y)
        {
            if (x == 0 || y == 0)
                throw new IndexOutOfRangeException("Invalid Position");

            this.x = x;
            this.y = y;
        }

        public int x { get; set; }
        public int y { get; set; }
    }
}
