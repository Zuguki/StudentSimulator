using UnityEngine;

namespace DefaultNamespace.Shop
{
    public class VideoCourse : IStatButton
    {
        public static string Name => "Видео курс";
        
        public StatType StateType => StatType.Shop;
        public string Text => "Видео курс";
        public string NeedPay => $"{CoursePrice}р";

        private const int CoursePrice = 1000;

        private int _money;

        public void Buffs()
        {
            _money = PlayerPrefs.GetInt("money");

            if (_money >= CoursePrice && !PlayerStats.Items.Contains(typeof(VideoCourse)))
            {
                PlayerStats.Items.Add(typeof(VideoCourse));
                PlayerStats.EventText = "Курс теперь у вас";
            }
            else
                PlayerStats.EventText = "Денег то нет, ну или ты крутой, курс уже у тебя";
            
            UpdatePrefabValue();
        }
        
        private void UpdatePrefabValue()
        {
            PlayerPrefs.SetInt("money", _money);
            PlayerStats.NeedsUpdate = true;
        }
    }
}