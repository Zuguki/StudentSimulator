namespace DefaultNamespace.Science
{
    public class AskForNotesFromClassmates : IStatButton
    {
        public StatType StateType => StatType.Science;

        public string Text => "Попросить конспекты у одногруппников";
        
        public void Buffs()
        {
            
        }
    }
}