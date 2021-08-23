using MarsRover.Business.Abstractions;
using MarsRover.Domain.Enums;
using MarsRover.Domain.Models;
using System;

namespace MarsRover.Business.Services
{
    public class RoverService : IRoverService
    {
        public Rover MoveByCommandsOnGrid(Rover rover, Grid grid, string commands)
        {
            Console.WriteLine($"Commands: {commands}");
            Console.WriteLine($"First Coordinates: {rover.Position.x} {rover.Position.y} {rover.Direction}");

            var commandArray = commands.ToCharArray();

            foreach (var command in commandArray)
            {
                switch (command.ToString())
                {
                    case "L":
                        TurnLeft(rover);
                        break;

                    case "R":
                        TurnRight(rover);
                        break;

                    case "M":
                        if (CanItMove(rover, grid))
                            Move(rover);
                        else
                            throw new IndexOutOfRangeException("Invalid Position For Move!");
                        break;

                    default:
                        throw new ArgumentException(string.Format("Invalid Command: {0}", command));
                }
            }

            return rover;
        }

        #region Move

        private void Move(Rover rover)
        {
            switch (rover.Direction)
            {
                case Direction.N:
                    rover.Position.y++;
                    break;

                case Direction.E:
                    rover.Position.x++;
                    break;

                case Direction.S:
                    rover.Position.y--;
                    break;

                case Direction.W:
                    rover.Position.x--;
                    break;

                default:
                    throw new ArgumentException(string.Format("Invalid Direction: {0}", rover.Direction));
            }
        }

        private bool CanItMove(Rover rover, Grid grid)
        {
            return !((rover.Direction == Direction.N && rover.Position.y == grid.MaxVerticalCellCount)
                || (rover.Direction == Direction.E && rover.Position.x == grid.MaxHorizontalCellCount)
                || (rover.Direction == Direction.S && rover.Position.y == 0)
                || (rover.Direction == Direction.W && rover.Position.x == 0));
        }

        #endregion

        #region Directions

        private void TurnLeft(Rover rover)
        {
            var currentDirection = (int)rover.Direction;

            currentDirection = currentDirection - 1;

            if (currentDirection == 0)
                rover.Direction = Direction.W;
            else
                rover.Direction = (Direction)currentDirection;
        }

        private void TurnRight(Rover rover)
        {
            var currentDirection = (int)rover.Direction;

            currentDirection = currentDirection + 1;

            if (currentDirection == 5)
                rover.Direction = Direction.N;
            else
                rover.Direction = (Direction)currentDirection;
        }

        #endregion
    }
}
