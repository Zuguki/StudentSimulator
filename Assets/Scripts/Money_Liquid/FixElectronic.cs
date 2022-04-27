namespace DefaultNamespace.Money
{
    public class FixElectronic : IStatButton
    {
        public StatType StateType => StatType.Money;
        public string Text => "Починить подик знакомому";
        public void Buffs()
        { }
    }
}