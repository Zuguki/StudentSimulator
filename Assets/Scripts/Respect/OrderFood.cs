namespace DefaultNamespace.Respect
{
    public class OrderFood : IStatButton
    {
        public StatType StateType => StatType.Respect;
        public string Text => "Заказать на соседей еды";
        public void Buffs()
        { }
    }
}