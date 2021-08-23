using System;

namespace MarsRover.Domain.Models
{
    public class Grid
    {
        public Grid(int maxHorizontalCellCount, int maxVerticalCellCount)
        {
            if (maxHorizontalCellCount == 0 || maxVerticalCellCount == 0)
                throw new IndexOutOfRangeException("Invalid Grid Size");

            MaxVerticalCellCount = maxVerticalCellCount;
            MaxHorizontalCellCount = maxHorizontalCellCount;
        }

        public int MaxVerticalCellCount { get; private set; }
        public int MaxHorizontalCellCount { get; private set; }
    }
}
