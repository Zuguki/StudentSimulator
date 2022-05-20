using UnityEngine;

namespace DefaultNamespace.Shop
{
    public class Exam : IStatButton
    {
        public static string Name => "Экзамен";
        
        public StatType StateType => StatType.Shop;
        public string Text => "Экзамен";
        public string NeedPay => $"{ExamPrice}р";

        private const int ExamPrice = 50_000;

        private int _money;

        public void Buffs()
        {
            _money = PlayerPrefs.GetInt("money");

            if (_money >= ExamPrice && !PlayerStats.Items.Contains(typeof(Exam)))
            {
                PlayerStats.Items.Add(typeof(Exam));
                PlayerStats.EventText = "Учебник теперь у вас";
            }
            else
                PlayerStats.EventText = "Денег то нет, ну или ты крутой, учебник уже у тебя";
            
            UpdatePrefabValue();
        }
        
        private void UpdatePrefabValue()
        {
            PlayerPrefs.SetInt("money", _money);
            PlayerStats.NeedsUpdate = true;
        }
    }
}