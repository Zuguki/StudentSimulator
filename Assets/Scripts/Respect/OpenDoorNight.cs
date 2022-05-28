using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Respect
{
    public class OpenDoorNight : IStatButton
    {
        public StatType StateType => StatType.Respect;
        public string Text => "Открыть дверь в общагу ночью";
        public string NeedPay => "Синячок";

        private int _respect;
        private int _science;
        
        private readonly List<string> _goodEvents = new()
        {
            "Дверца открыта, ты красавчик", "Фух, повезло - повезло",
            "Как тебя не спалили? Там Дед в порядке?"
        };

        private readonly List<string> _badEvents = new()
            {"А вот зачем ты шел открывать дверь с колонкой?", "Ну, опять получил п-ды", "Ооо, да, Дед в порядке"};
        
        public void Buffs()
        {
            _respect = PlayerPrefs.GetInt("respect");
            _science = PlayerPrefs.GetInt("science");

            if (TryGetGoodBuff(out var buffValue))
            {
                PlayerStats.EventText = _goodEvents[Random.Range(0, _goodEvents.Count)];
                _respect += buffValue;
            }
            else
            {
                PlayerStats.EventText = _badEvents[Random.Range(0, _badEvents.Count)];
                _science -= _science - buffValue > 0 ? buffValue : _science;
            }
            
            UpdatePrefabValue();
        }

        private static bool TryGetGoodBuff(out int buffValue)
        {
            var isGoodBuff = Random.Range(0, 100) > 50; 
            
            buffValue = Random.Range(10, 50);
            return isGoodBuff;
        }
        
        private void UpdatePrefabValue()
        {
            PlayerPrefs.SetInt("respect", _respect);
            PlayerPrefs.SetInt("science", _science);
            PlayerStats.NeedsUpdate = true;
        }
    }
}