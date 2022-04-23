namespace DefaultNamespace
{
    public class CookMealInDorm : IStatButton
    {
        public StatType StateType => StatType.Meet;

        public string Text => "Приготовить еду в общаге";
        
        public void Buffs()
        {
        }
    }
}