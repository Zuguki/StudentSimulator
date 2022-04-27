namespace DefaultNamespace.Money
{
    public class AskLiquid : IStatButton
    {
        public StatType StateType => StatType.Liquid;
        public string Text => "Попросить у знакомых жижи";
        public void Buffs()
        { }
    }
}