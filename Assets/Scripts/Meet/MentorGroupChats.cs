namespace DefaultNamespace
{
    public class MentorGroupChats : IStatButton
    {
        public StatType StateType => StatType.Meet;

        public string Text => "Менторить чатики групп";

        public void Buffs()
        {
        }
    }


}