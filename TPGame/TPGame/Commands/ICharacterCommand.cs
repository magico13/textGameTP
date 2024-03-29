namespace TPGame.Commands
{
    public interface ICharacterCommand
    {
        public bool AttackEnemy(bool combat);
        public void LowerSugar();
        public void SpawnEnemy(string roomName);
        public void SetCriticalThreshhold(double crit);
        public int GetLicks();
        public int GetSticks();
    }
}