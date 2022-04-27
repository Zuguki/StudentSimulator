namespace DefaultNamespace.Respect
{
    public class OpenDoorNight : IStatButton
    {
        public StatType StateType => StatType.Liquid; 
        public string Text => "Открыть дверь в общагу ночью";
        public void Buffs()
        {
        }
    }
}