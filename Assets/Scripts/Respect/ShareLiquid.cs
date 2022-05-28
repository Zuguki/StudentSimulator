using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Respect
{
    public class ShareLiquid : IStatButton
    {
        public StatType StateType => StatType.Respect;
        public string Text => "Поделиться жижей с соседом";
        public string NeedPay => $"{LiquidPrice}ж";

        private const int LiquidPrice = 10;

        private int _liquid;
        private int _respect;
        
        private readonly List<string> _goodEvents = new()
        {
            "Жижа подрил уважение", "О да, жижка, лучший друг радиста",
            "Жаль, у нас теперь мешьше жижла"
        };

        private readonly List<string> _badEvents = new()
            {"Пора заработать жижла", "Жижи много не бывает! Тем более у тебя", "Не хватает на заливку"};
        
        public void Buffs()
        {
            _liquid = PlayerPrefs.GetInt("liquid");
            _respect = PlayerPrefs.GetInt("respect");

            if (TryGetGoodBuff(out var buffValue))
            {
                PlayerStats.EventText = _goodEvents[Random.Range(0, _goodEvents.Count)];
                _liquid -= LiquidPrice;
                _respect += buffValue;
            }
            else
                PlayerStats.EventText = _badEvents[Random.Range(0, _badEvents.Count)];
            
            UpdatePrefabValue();
        }
        
        private bool TryGetGoodBuff(out int buffValue)
        {
            var isGoodBuff = _liquid >= LiquidPrice;
            
            buffValue = isGoodBuff ? Random.Range(10, 25) : 0;
            return isGoodBuff;
        }
        
        private void UpdatePrefabValue()
        {
            PlayerPrefs.SetInt("liquid", _liquid);
            PlayerPrefs.SetInt("respect", _respect);
            PlayerStats.NeedsUpdate = true;
        }
    }
}