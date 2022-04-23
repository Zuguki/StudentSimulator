namespace DefaultNamespace.Science
{
    public class EngageInVideoCourse : IStatButton
    {
        public StatType StateType => StatType.Science;

        public string Text => "Заниматься по видео курсу";
        
        public void Buffs()
        {
        }
    }
}