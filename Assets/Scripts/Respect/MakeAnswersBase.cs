namespace DefaultNamespace.Respect
{
    public class MakeAnswersBase : IStatButton
    {
        public StatType StateType => StatType.Respect;
        public string Text => "Делать базу ответов";
        public void Buffs()
        { }
    }
}