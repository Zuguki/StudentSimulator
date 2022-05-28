using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class MakeFriendsWithSopras : IStatButton
    {
        public StatType StateType => StatType.Meet;
        
        public string Text => "Скорешиться с сопрами";
        public string NeedPay => $"{NeedsRespectStat} уважения";

        private const int NeedsRespectStat = 500;

        private int _meet;
        private int _respect;
        private int _science;
        
        private readonly List<string> _goodEvents = new()
        {
            "Затусил с сопрами? А ты хорош", "Прикольно, теперь тебя знают",
            "Оказывается они прикольные ребята"
        };

        private readonly List<string> _badEvents = new()
            {"Ха, какие сопры? Ты им и в XXX не встал", "А может не надо было?", "Поздравляю, тебя опять послали"};
        
         public void Buffs()
         {
             _meet = PlayerPrefs.GetInt("meet");
             _respect = PlayerPrefs.GetInt("respect");
             _science = PlayerPrefs.GetInt("science");
 
             if (TryGetGoodBuff(out var buffValue))
             {
                 PlayerStats.EventText = _goodEvents[Random.Range(0, _goodEvents.Count)];
                 _meet += buffValue;
             }
             else
             {
                 PlayerStats.EventText = _badEvents[Random.Range(0, _badEvents.Count)];
                 _meet -= _meet - buffValue > 0 ? buffValue : _meet;
                 _respect -= _respect - buffValue > 0 ? buffValue : _respect;
                 _science -= _science - buffValue > 0 ? buffValue : _science;
             }
             
             UpdatePrefabValue();
         }
         
         
         private bool TryGetGoodBuff(out int buffValue)
         {
             var isGoodBuff = _respect >= NeedsRespectStat && Random.Range(0, 100) > 20;
             
             buffValue = isGoodBuff ? Random.Range(50, 75) : Random.Range(10, 50);
             return isGoodBuff;
         }
         
         private void UpdatePrefabValue()
         {
             PlayerPrefs.SetInt("meet", _meet);
             PlayerPrefs.SetInt("respect", _respect);
             PlayerPrefs.SetInt("science", _science);
             PlayerStats.NeedsUpdate = true;
         }       
    }
}