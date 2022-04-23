namespace DefaultNamespace
{
    public class MakeFriendsWithSopras : IStatButton
    {
        public StatType StateType => StatType.Meet;
        
        public string Text => "Скорешиться с сопрами";
        
        public void Buffs()
        {
        }
    }
}