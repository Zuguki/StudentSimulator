using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Money
{
    public class TakeNeighbourLiquid : IStatButton
    {
        public StatType StateType => StatType.Liquid;
        public string Text => "Залить жижу соседа, пока он не видит";
        public string NeedPay => "Новое лицо";

        private int _respect;
        private int _liquid;
        
        private readonly List<string> _goodEvents = new()
            {"Вау, тебя не спалили, крыска", "Столько жижи налутал", "Что поделать, жижа необходима"};

        private readonly List<string> _badEvents = new()
            {"Лол, тебя спалили", "Ха-ха, у тебя теперь такой синяк", "Новое, синие лицо"};

        public void Buffs()
        {
            _respect = PlayerPrefs.GetInt("respect");
            _liquid = PlayerPrefs.GetInt("liquid");

            if (TryGetGoodBuff(out var buffValue))
            {
                PlayerStats.EventText = _goodEvents[Random.Range(0, _goodEvents.Count)];
                _liquid += buffValue;
            }
            else
            {
                PlayerStats.EventText = _badEvents[Random.Range(0, _badEvents.Count)];
                _respect -= _respect - buffValue > 0 ? buffValue : _respect;
            }
            
            UpdatePrefabValue();
        }
        
         private static bool TryGetGoodBuff(out int buffValue)
         {
             var isGoodBuff = Random.Range(0, 100) > 60;
             
             buffValue = isGoodBuff ? Random.Range(1, 4) : Random.Range(15, 50);
             return isGoodBuff;
         }
         
         private void UpdatePrefabValue()
         {
             PlayerPrefs.SetInt("respect", _respect);
             PlayerPrefs.SetInt("liquid", _liquid);
             PlayerStats.NeedsUpdate = true;
         }       
    }
}