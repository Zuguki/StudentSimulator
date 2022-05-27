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
                _money -= ExamPrice;
                PlayerStats.EventText = "Вы купили сдачу экзаменов, теперь вам ничего не угрожает";
            }
            else
                PlayerStats.EventText = "У вас недостаточно денег";
            
            UpdatePrefabValue();
        }
        
        private void UpdatePrefabValue()
        {
            PlayerPrefs.SetInt("money", _money);
            PlayerStats.NeedsUpdate = true;
        }
    }
}