namespace DefaultNamespace.Respect
{
    public class HelpWithHW : IStatButton
    {
        public StatType StateType => StatType.Liquid; 
        public string Text => "Помочь с домашкой";
        public void Buffs()
        { }
    }
}