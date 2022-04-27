namespace DefaultNamespace.Respect
{
    public class OpenDoorNight : IStatButton
    {
        public StatType StateType => StatType.Respect;
        public string Text => "Открыть дверь в общагу ночью";
        public void Buffs()
        {
        }
    }
}