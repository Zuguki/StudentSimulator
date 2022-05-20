namespace DefaultNamespace
{
    public interface IStatButton
    {
        public StatType StateType { get; }
        
        public string Text { get; }
        public string NeedPay { get; }
        public void Buffs();
    }

}