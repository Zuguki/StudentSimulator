namespace DefaultNamespace.Respect
{
    public class MakeAnswersBase : IStatButton
    {
        public StatType StateType => StatType.Liquid; 
        public string Text => "Делать базу ответов";
        public void Buffs()
        { }
    }
}