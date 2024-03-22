namespace TPGame.Commands
{
    public interface ICharacterCommand
    {
        public bool AttackEnemy(bool combat);
        public void LowerSugar();
        public void SpawnEnemy(string roomName);

        public int GetLicks();
    }
}