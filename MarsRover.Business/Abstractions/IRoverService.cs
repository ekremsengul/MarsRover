using MarsRover.Domain.Models;

namespace MarsRover.Business.Abstractions
{
    public interface IRoverService
    {
        Rover MoveByCommandsOnGrid(Rover rover, Grid grid, string commands);
    }
}
