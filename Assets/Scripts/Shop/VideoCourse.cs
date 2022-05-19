using UnityEngine;

namespace DefaultNamespace.Shop
{
    public class VideoCourse : IStatButton
    {
        public StatType StateType => StatType.Shop;
        public string Text => "Видео курс";

        private const int CoursePrice = 1000;

        private int _money;

        public void Buffs()
        {
            _money = PlayerPrefs.GetInt("money");

            if (_money >= CoursePrice && !PlayerStats.Items.Contains(typeof(VideoCourse)))
            {
                PlayerStats.Items.Add(typeof(VideoCourse));
                Debug.Log("Курс теперь у вас");
            }
            else
            {
                Debug.Log("Денег то нет, ну или ты крутой, курс уже у тебя");
            }
            
            UpdatePrefabValue();
        }
        
        private void UpdatePrefabValue()
        {
            PlayerPrefs.SetInt("money", _money);
            PlayerStats.NeedsUpdate = true;
        }
    }
}