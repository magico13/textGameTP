using TPGame.Models;

namespace TPGame.Commands
{
    public interface IRoomCommand
    {
        Room CurrentLocation { get; set; }
        bool InCombat { get; set; }

        bool ChangeRoom(string target);
        bool CheckCombat();
        void ViewMap();

        void SearchRoom();
    }
}