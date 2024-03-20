namespace TPGame.Commands
{
    public interface ICharacterCommand
    {
        void AttackEnemy(bool combat);
        void LowerSugar();
        void SpawnEnemy();
    }
}