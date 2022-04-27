namespace DefaultNamespace.Money
{
    public class TakeSoprovsLiquid : IStatButton
    {
        public StatType StateType => StatType.Liquid;
        public string Text => "Забрать жижу у сопров";
        public void Buffs()
        { }
    }
}