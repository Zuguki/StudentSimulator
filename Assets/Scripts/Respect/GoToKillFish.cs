using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Respect
{
    public class GoToKillFish : IStatButton
    {
        public StatType StateType => StatType.Respect;
        public string Text => "Позвать одногрупников в KillFish";
        public string NeedPay => $"{KillFishPrice}р";

        private const int KillFishPrice = 750;

        private int _respect;
        private int _money;
        
        private readonly List<string> _goodEvents = new()
        {
            "Не думал, что ты такой любитель выпить", "Со здоровьем то все ок будет?",
            "Как ты столько выпил?"
        };

        private readonly List<string> _badEvents = new()
            {"Фух, хоть немного отдохнешь", "Деньжат нема уже?", "Все пропил..."};

        public void Buffs()
        {
            _respect = PlayerPrefs.GetInt("respect");
            _money = PlayerPrefs.GetInt("money");

            if (TryGetGoodBuff(out var buffValue))
            {
                PlayerStats.EventText = _goodEvents[Random.Range(0, _goodEvents.Count)];
                _respect += buffValue;
                _money -= KillFishPrice;
            }
            else
                PlayerStats.EventText = _badEvents[Random.Range(0, _badEvents.Count)];
            
            UpdatePrefabValue();
        }
        
         private bool TryGetGoodBuff(out int buffValue)
         {
             var isGoodBuff = _money >= KillFishPrice;
 
             buffValue = isGoodBuff ? Random.Range(50, 75) : 0;
             return isGoodBuff;
         }
          
         private void UpdatePrefabValue()
         {
             PlayerPrefs.SetInt("respect", _respect);
             PlayerPrefs.SetInt("money", _money);
             PlayerStats.NeedsUpdate = true;
         }       
    }
}