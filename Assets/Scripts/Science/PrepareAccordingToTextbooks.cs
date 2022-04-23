namespace DefaultNamespace.Science
{
    public class PrepareAccordingToTextbooks : IStatButton
    {
        public StatType StateType => StatType.Science;

        public string Text => "Готовиться по учебникам";
        
        public void Buffs()
        {
            
        }
    }
}