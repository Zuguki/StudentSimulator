namespace DefaultNamespace.Money
{
    public class SellTextBook : IStatButton
    {
        public StatType StateType => StatType.Money;
        public string Text => "Продать учебники";
        public void Buffs()
        { }
    }
}