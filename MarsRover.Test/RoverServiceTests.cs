using MarsRover.Business.Services;
using MarsRover.Domain.Enums;
using MarsRover.Domain.Models;
using System;
using Xunit;

namespace MarsRover.Test
{
    public class RoverServiceTests
    {
        [Theory]
        [InlineData(5, 5, 1, 2, Direction.N, "LMLMLMLMM", 1, 3, Direction.N)]
        [InlineData(5, 5, 3, 3, Direction.E, "MMRMMRMRRM", 5, 1, Direction.E)]
        public void MoveByCommandsOnGrid_CommandGiven_RetunRoverSuccess(int input_grid_x, int input_grid_y, int input_x, int input_y, Direction input_direction, string input_commands, int output_x, int output_y, Direction output_Direction)
        {
            var grid = new Grid(input_grid_x, input_grid_y);
            var rover = new Rover(input_x, input_y, input_direction);
            var service = new RoverService();

            var result = service.MoveByCommandsOnGrid(rover, grid, input_commands);

            Assert.Equal(output_x, result.Position.x);
            Assert.Equal(output_y, result.Position.y);
            Assert.Equal(output_Direction, result.Direction);
        }

        [Fact]
        public void MoveByCommandsOnGrid_InvalidCommandGiven_RetunException()
        {
            var grid = new Grid(5, 5);
            var rover = new Rover(1, 2, Direction.N);
            var service = new RoverService();

            Assert.Throws<ArgumentException>(() => service.MoveByCommandsOnGrid(rover, grid, "X"));
        }

        [Fact]
        public void MoveByCommandsOnGrid_OutOfGridMoveCommandGiven_RetunException()
        {
            var grid = new Grid(5, 5);
            var rover = new Rover(1, 2, Direction.N);
            var service = new RoverService();

            Assert.Throws<IndexOutOfRangeException>(() => service.MoveByCommandsOnGrid(rover, grid, "MMMMMMMMM"));
        }
    }
}
