namespace DefaultNamespace.Respect
{
    public class GoToKillFish : IStatButton
    {
        public StatType StateType => StatType.Respect;
        public string Text => "Позвать одногрупников в KillFish";
        public void Buffs()
        { }
    }
}