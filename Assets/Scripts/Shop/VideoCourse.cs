using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Shop
{
    public class VideoCourse : IStatButton
    {
        public static string Name => "Видео курс";
        
        public StatType StateType => StatType.Shop;
        public string Text => "Видео курс";
        public string NeedPay => $"{CoursePrice}р";

        private const int CoursePrice = 1_000;

        private readonly List<string> _goodEvents = new()
        {
            "Инфо циганский курс у вас", "ЕЕЕ вы купили курс: SON:SUCK:JS:FUCK:ABS:PASCAL:GG10001",
            "Приятного просмотра"
        };

        private readonly List<string> _badEvents = new()
            {"Это тебе не Гоша Дударь, иди еще заработай", "Не, иди дальше ХаудиХо смотри", "Не будем продавать тебе"};


        private int _money;

        public void Buffs()
        {
            _money = PlayerPrefs.GetInt("money");

            if (_money >= CoursePrice && !PlayerStats.Items.Contains(typeof(VideoCourse)))
            {
                PlayerStats.Items.Add(typeof(VideoCourse));
                _money -= CoursePrice;
                PlayerStats.EventText = _goodEvents[Random.Range(0, _goodEvents.Count)];
            }
            else
                PlayerStats.EventText = _badEvents[Random.Range(0, _badEvents.Count)];
            
            UpdatePrefabValue();
        }
        
        private void UpdatePrefabValue()
        {
            PlayerPrefs.SetInt("money", _money);
            PlayerStats.NeedsUpdate = true;
        }
    }
}