using MarsRover.Business.Abstractions;
using MarsRover.Domain.Enums;
using MarsRover.Domain.Models;
using System;

namespace MarsRover
{
    public class App
    {
        IRoverService _roverService;
        public App(IRoverService roverService)
        {
            _roverService = roverService;
        }

        public void Run()
        {
            var grid = new Grid(5, 5);

            var firstRover = new Rover(1, 2, Direction.N);
            var firstResult = _roverService.MoveByCommandsOnGrid(firstRover, grid, "LMLMLMLMM");
            WriteRoverResult(firstResult);

            var secondRover = new Rover(3, 3, Direction.E);
            var secondResult = _roverService.MoveByCommandsOnGrid(secondRover, grid, "MMRMMRMRRM");
            WriteRoverResult(secondResult);
        }

        public void WriteRoverResult(Rover rover)
        {
            Console.WriteLine($"Last Coordinates: {rover.Position.x} {rover.Position.y} {rover.Direction} \n");
        }
    }
}
