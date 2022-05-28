using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Money
{
    public class SellConspects : IStatButton
    {
        public StatType StateType => StatType.Money;
        public string Text => "Продать конспекты";
        public string NeedPay => $"{NeedsScience} знаний";

        private const int NeedsScience = 1_000;

        private int _science;
        private int _money;
        
        private readonly List<string> _goodEvents = new()
        {
            "Не зря учился...", "Конспект продали, бабки получили, все З&С", "Ну, нужно же жижу покупать как то"
        };

        private readonly List<string> _badEvents = new()
            {"Твои конспекты никому не нужны", "Всем страшно брать твои конспекты", "Ты хочешь им жизнь усложнить?"};

        public void Buffs()
        {
            _science = PlayerPrefs.GetInt("science");
            _money = PlayerPrefs.GetInt("money");

            if (TryGetGoodBuff(out var buffValue))
            {
                PlayerStats.EventText = _goodEvents[Random.Range(0, _goodEvents.Count)];
                _money += buffValue;
            }
            else
                PlayerStats.EventText = _badEvents[Random.Range(0, _badEvents.Count)];
            
            UpdatePrefabValue();
        }
        
        private bool TryGetGoodBuff(out int buffValue)
        {
            var isGoodBuff = _science >= NeedsScience && Random.Range(0, 100) > 10;
            
            buffValue = Random.Range(100, 700);
            return isGoodBuff;
        }
        
        private void UpdatePrefabValue()
        {
            PlayerPrefs.SetInt("science", _science);
            PlayerPrefs.SetInt("money", _money);
            PlayerStats.NeedsUpdate = true;
        }
    }
}