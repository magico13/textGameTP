using TPGame.Models;

namespace TPGame.Commands
{
    public interface IStuffCommand
    {
        void CheckItem(string target);
        void GetItem(string target, Room currentLocation);
        void UseItem(string target, Room currentLocation);
    }
}