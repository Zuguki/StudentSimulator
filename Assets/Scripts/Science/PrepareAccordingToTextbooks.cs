using System.Collections.Generic;
using DefaultNamespace.Shop;
using UnityEngine;

namespace DefaultNamespace.Science
{
    public class PrepareAccordingToTextbooks : IStatButton
    {
        public StatType StateType => StatType.Science;

        public string Text => "Готовиться по учебникам";
        public string NeedPay => "Учебник";

        private int _science;
        
        private readonly List<string> _goodEvents = new()
        {
            "Красивые картинки в учебнике", "А учебник то реально классный",
            "Ты опять весь вечер залипал в картинки учебника"
        };

        private readonly List<string> _badEvents = new()
        {
            "Следует сходить в магазинчик(не за жижей)", "Ты не смог найти учебник в портфеле",
            "Может следует купить сначала?"
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
            var isGoodBuff = PlayerStats.Items.Contains(typeof(Book));
            
            buffValue = isGoodBuff ? Random.Range(15, 35) : 0;
            return isGoodBuff;
        }
        
        private void UpdatePrefabValue()
        {
            PlayerPrefs.SetInt("science", _science);
            PlayerStats.NeedsUpdate = true;
        }
    }
}