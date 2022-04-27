namespace DefaultNamespace.Respect
{
    public class GoToKillFish : IStatButton
    {
        public StatType StateType => StatType.Liquid;
        public string Text => "Позвать одногрупников в KillFish";
        public void Buffs()
        { }
    }
}