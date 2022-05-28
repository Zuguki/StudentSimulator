using System.Collections.Generic;
using DefaultNamespace.Shop;
using UnityEngine;

namespace DefaultNamespace.Science
{
    public class EngageInVideoCourse : IStatButton
    {
        public StatType StateType => StatType.Science;

        public string Text => "Заниматься по видео курсу";
        public string NeedPay => "Видео курс";

        private int _science;
        
        private readonly List<string> _goodEvents = new()
        {
            "А курс то классный", "Всю ночь смотрел видосики(по учебе)",
            "Ты уже понял умножение"
        };

        private readonly List<string> _badEvents = new()
        {
            "Купи курс! Получи бонус", "Эх, посмотреть не вышло",
            "Ты не можешь найти курс"
        };
        
        public void Buffs()
        {
            _science = PlayerPrefs.GetInt("science");

            if (TryGetGoodBuff(out var buffValue))
            {
                PlayerStats.EventText = _goodEvents[Random.Range(0, _goodEvents.Count)];
                _science += buffValue;
            }
            else
                PlayerStats.EventText = _badEvents[Random.Range(0, _badEvents.Count)];
            
            UpdatePrefabValue();
        }
        
        private static bool TryGetGoodBuff(out int buffValue)
        {
            var isGoodBuff = PlayerStats.Items.Contains(typeof(VideoCourse));
            
            buffValue = isGoodBuff ? Random.Range(35, 60) : 0;
            return isGoodBuff;
        }
        
        private void UpdatePrefabValue()
        {
            PlayerPrefs.SetInt("science", _science);
            PlayerStats.NeedsUpdate = true;
        }
    }
}