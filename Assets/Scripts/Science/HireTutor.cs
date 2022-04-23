namespace DefaultNamespace.Science
{
    public class HireTutor : IStatButton
    {
        public StatType StateType => StatType.Science;

        public string Text => "Нанять репетитора";
        
        public void Buffs()
        {
        }
    }
}