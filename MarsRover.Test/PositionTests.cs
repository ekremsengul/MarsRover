using MarsRover.Domain.Models;
using System;
using Xunit;

namespace MarsRover.Test
{
    public class PositionTests
    {
        [Fact]
        public void PositionCtor_InvalidPositionGiven_RetunException()
        {
            Assert.Throws<IndexOutOfRangeException>(() => new Position(0, 0));
        }
    }
}
