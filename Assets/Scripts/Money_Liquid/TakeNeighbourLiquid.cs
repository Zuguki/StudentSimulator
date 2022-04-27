namespace DefaultNamespace.Money
{
    public class TakeNeighbourLiquid : IStatButton
    {
        public StatType StateType => StatType.Liquid;
        public string Text => "Залить жижу соседа, пока он не видит";
        public void Buffs()
        { }
    }
}