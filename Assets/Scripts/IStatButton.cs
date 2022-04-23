namespace DefaultNamespace
{
    public interface IStatButton
    {
        public StatType StateType { get; }
        
        public string Text { get; }
        public void Buffs();
    }

}