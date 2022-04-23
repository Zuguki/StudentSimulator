namespace DefaultNamespace.Science
{
    public class WriteOffClassmate : IStatButton
    {
        public StatType StateType => StatType.Science;

        public string Text => "Списать у одногрупника, пока он не видит";
        
        public void Buffs()
        {
        }
    }
}