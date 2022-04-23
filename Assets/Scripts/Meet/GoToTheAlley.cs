namespace DefaultNamespace
{
    public class GoToTheAlley : IStatButton
    {
        public StatType StateType => StatType.Meet;

        public string Text => "Пить на аллейкe";
        
        public void Buffs()
        {
        }
    }
}