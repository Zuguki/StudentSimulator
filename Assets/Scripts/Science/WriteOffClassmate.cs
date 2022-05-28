using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Science
{
    public class WriteOffClassmate : IStatButton
    {
        public StatType StateType => StatType.Science;

        public string Text => "Списать у одногрупника, пока он не видит";
        public string NeedPay => "Могут леща дать";

        private int _science;
        private int _respect;
        
        private readonly List<string> _goodEvents = new()
        {
            "Ну, мы такое не поддерживаем, но у тебя получилось", "Слепой одногрупник, какой то",
            "О, тебя не спалили"
        };

        private readonly List<string> _badEvents = new()
        {
            "Оказывается одногрупник сам дурак, ничего не пишет", "Тепеь у тебя синяк под глазом", "Ахаха, тебя спалили"
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
            {
                _respect = PlayerPrefs.GetInt("respect");
                PlayerStats.EventText = _badEvents[Random.Range(0, _badEvents.Count)];
                _respect -= _respect - buffValue > 0 ? buffValue : _respect;
            }

            UpdatePrefabValue();
        }

        private static bool TryGetGoodBuff(out int buffValue)
        {
            var isGoodBuff = Random.Range(0, 100) >= 25;
            
            buffValue = isGoodBuff ? Random.Range(0, 25) : Random.Range(10, 25);
            return isGoodBuff;
        }

        private void UpdatePrefabValue()
        {
            PlayerPrefs.SetInt("science", _science);
            PlayerPrefs.SetInt("respect", _respect);
            
            PlayerStats.NeedsUpdate = true;
        }
    }
}