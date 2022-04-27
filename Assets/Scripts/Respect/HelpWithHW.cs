namespace DefaultNamespace.Respect
{
    public class HelpWithHW : IStatButton
    {
        public StatType StateType => StatType.Respect;
        public string Text => "Помочь с домашкой";
        public void Buffs()
        { }
    }
}