using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Money
{
    public class FixElectronic : IStatButton
    {
        public StatType StateType => StatType.Money;
        public string Text => "Починить подик знакомому";
        public string NeedPay => $"{NeedsScience} знаний\n{NeedsMeet} знакомств";

        private const int NeedsMeet = 500;
        private const int NeedsScience = 500;

        private int _meet;
        private int _science;
        private int _respect;
        private int _money;
        
        private readonly List<string> _goodEvents = new()
        {
            "Делать бизнес блин, вот так!", "Починил, девченка тебе благодарна", "Ну, миллионер прям"
        };

        private readonly List<string> _badEvents = new()
            {"Ха, рукожоп ты", "Лучше еще поучись", "Как ты смог его еще больше сломать?"};

        public void Buffs()
        {
            _meet = PlayerPrefs.GetInt("meet");
            _science = PlayerPrefs.GetInt("science");
            _respect = PlayerPrefs.GetInt("respect");
            _money = PlayerPrefs.GetInt("money");

            if (TryGetGoodBuff(out var buffValue))
            {
                PlayerStats.EventText = _goodEvents[Random.Range(0, _goodEvents.Count)];
                _money += buffValue;
            }
            else
            {
                PlayerStats.EventText = _badEvents[Random.Range(0, _badEvents.Count)];
                _meet -= _meet - buffValue > 0 ? buffValue : _meet;
                _science -= _science - buffValue > 0 ? buffValue : _science;
                _respect -= _respect - buffValue > 0 ? buffValue : _respect;
            }
            
            UpdatePrefabValue();
        }
        
        private bool TryGetGoodBuff(out int buffValue)
        {
            var isGoodBuff = _meet >= NeedsMeet && _science >= NeedsScience && Random.Range(0, 100) > 10;
            
            buffValue = Random.Range(100, 500);
            return isGoodBuff;
        }
        
        private void UpdatePrefabValue()
        {
            PlayerPrefs.SetInt("meet", _meet);
            PlayerPrefs.SetInt("science", _science);
            PlayerPrefs.SetInt("respect", _respect);
            PlayerPrefs.SetInt("money", _money);
            
            PlayerStats.NeedsUpdate = true;
        }
    }
}