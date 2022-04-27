namespace DefaultNamespace.Respect
{
    public class ShareLiquid : IStatButton
    {
        public StatType StateType => StatType.Respect;
        public string Text => "Поделиться жижей с соседом";
        public void Buffs()
        {
        }
    }
}