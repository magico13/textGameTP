namespace TPGame.Commands
{
    public interface ICharacterCommand
    {
        public void AttackEnemy(bool combat);
        public void LowerSugar();
        public void SpawnEnemy(string roomName);
    }
}