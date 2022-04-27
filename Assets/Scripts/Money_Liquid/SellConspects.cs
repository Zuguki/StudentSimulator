namespace DefaultNamespace.Money
{
    public class SellConspects : IStatButton
    {
        public StatType StateType => StatType.Money;
        public string Text => "Продать конспекты";
        public void Buffs()
        { }
    }
}