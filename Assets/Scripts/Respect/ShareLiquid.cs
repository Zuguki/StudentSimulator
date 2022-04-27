namespace DefaultNamespace.Respect
{
    public class ShareLiquid : IStatButton
    {
        public StatType StateType => StatType.Liquid; 
        public string Text => "Поделиться жижей с соседом";
        public void Buffs()
        {
        }
    }
}