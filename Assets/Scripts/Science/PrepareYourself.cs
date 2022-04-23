namespace DefaultNamespace.Science
{
    public class PrepareYourself : IStatButton
    {
        public StatType StateType => StatType.Science;

        public string Text => "Готовиться самому";
        
        public void Buffs()
        {
            
        }
    }
}