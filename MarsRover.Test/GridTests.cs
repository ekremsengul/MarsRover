using MarsRover.Domain.Models;
using System;
using Xunit;

namespace MarsRover.Test
{
    public class GridTests
    {
        [Fact]
        public void GridCtor_InvalidGridSizeGiven_RetunException()
        {
            Assert.Throws<IndexOutOfRangeException>(() => new Grid(0, 0));
        }
    }
}
