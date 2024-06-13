using TPGame.Handlers;
using System.Data;
using TPGame.Dictionaries;
using TPGame.Items;

namespace TPGame.Models
{
    public static class Cheat
    {
        public static void PlayGameForMe()
        {
            CreateSendAction("use", "light switch");
            CreateSendAction("get", "tool belt");
            CreateSendAction("move", "kitchen");
            CreateSendAction("get", "knife");
            CreateSendAction("get", "water bottle");
            CreateSendAction("use", "water bowl");
            CreateSendAction("use", "water bottle");
            InputHandler.Map.InCombat = false;
            CreateSendAction("move", "living room");
            CreateSendAction("get", "mints");
            CreateSendAction("get", "key");
            InputHandler.Map.InCombat = false;
            CreateSendAction("move", "guest bedroom");
            CreateSendAction("get", "guard");
            InputHandler.Map.InCombat = false;
            CreateSendAction("move", "bathroom");
            CreateSendAction("get", "dentures");
            CreateSendAction("use", "toilet");
            CreateSendAction("use", "water bottle");
            InputHandler.Map.InCombat = false;
            CreateSendAction("move", "office");
            CreateSendAction("get", "batteries");
            InputHandler.Map.InCombat = false;
            GrindXP();
            CreateSendAction("move", "garage");
            CreateSendAction("use", "key");
            CreateSendAction("use", "sander");
            while (!InputHandler.Map.CurrentLocation.BossDefeated && InputHandler.Character.Player.GetSugar() < 100)
            {
                CreateSendAction("lick", "");
            }
            CreateSendAction("use", "knife");
            CreateSendAction("get", "ladder");
            CreateSendAction("move", "attic");
            CreateSendAction("use", "ladder");
            CreateSendAction("use", "home gym");
            while (!InputHandler.Map.CurrentLocation.BossDefeated && InputHandler.Character.Player.GetSugar() < 100)
            {
                CreateSendAction("lick", "");
            }
            CreateSendAction("get", "lantern");
            CreateSendAction("use", "batteries");
            CreateSendAction("move", "basement");
            CreateSendAction("use", "lantern");
            CreateSendAction("use", "milk crates");
            while (!InputHandler.Map.CurrentLocation.BossDefeated && InputHandler.Character.Player.GetSugar() < 100)
            {
                CreateSendAction("lick", "");
            }
            CreateSendAction("get", "shovel");
            CreateSendAction("get", "metal detector");
            CreateSendAction("use", "water main");
            CreateSendAction("move", "kitchen");
            CreateSendAction("use", "sink");
            InputHandler.Map.InCombat = false;
            CreateSendAction("move", "bathroom");
            CreateSendAction("use", "sink");
            InputHandler.Map.InCombat = false;
            CreateSendAction("move", "backyard");
            CreateSendAction("use", "metal detector");
            CreateSendAction("use", "shovel");
            CreateSendAction("use", "switch");
            CreateSendAction("move", "hidden room");
            CreateSendAction("use", "knife");
            CreateSendAction("use", "shovel");
            CreateSendAction("use", "water bottle");
            while (!InputHandler.Map.CurrentLocation.BossDefeated && InputHandler.Character.Player.GetSugar() < 100)
            {
                CreateSendAction("lick", "");
            }
            CreateSendAction("use", "mints");
            CreateSendAction("use", "mints");
            CreateSendAction("use", "button");
        }

        private static void CreateSendAction(string command, string target)
        {
            InputAction action = new()
            {
                Command = command,
                Target = target
            };
            InputHandler.HandleAction(action);
        }

        private static void GrindXP()
        {
            while (InputHandler.Character.Player.GetSticks() < 9)
            {
                bool combat = true;
                InputHandler.Character.SpawnEnemy("Pantry");
                while (combat)
                {
                    combat = InputHandler.Character.AttackEnemy(true);
                }
            }
        }
    }
}
