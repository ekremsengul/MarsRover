using MarsRover.Domain.Enums;

namespace MarsRover.Domain.Models
{
    public class Rover
    {
        public Rover(int x, int y, Direction direction)
        {
            Position = new Position(x, y);
            Direction = direction;
        }

        public Position Position { get; set; }
        public Direction Direction { get; set; }
    }
}
