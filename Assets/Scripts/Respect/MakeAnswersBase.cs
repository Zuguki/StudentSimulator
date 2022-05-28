using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Respect
{
    public class MakeAnswersBase : IStatButton
    {
        public StatType StateType => StatType.Respect;
        public string Text => "Делать базу ответов";
        public string NeedPay => $"{MeetPrice} знакомств";

        private const int MeetPrice = 250;

        private int _respect;
        private int _meet;
        
        private readonly List<string> _goodEvents = new()
        {
            "Ну, копи паст с других баз, это не оч круто...", "База ответов... А ты хорош",
            "База прикольная получается, но учеба просела"
        };

        private readonly List<string> _badEvents = new()
            {"Зачем кому то NoName база?", "Иди знакомься", "База? Не, не слышал"};

        public void Buffs()
        {
            _respect = PlayerPrefs.GetInt("respect");
            _meet = PlayerPrefs.GetInt("meet");

            if (TryGetGoodBuff(out var buffValue))
            {
                PlayerStats.EventText = _goodEvents[Random.Range(0, _goodEvents.Count)];
                _respect += buffValue;
                _meet -= MeetPrice;
            }
            else
                PlayerStats.EventText = _badEvents[Random.Range(0, _badEvents.Count)];
            
            UpdatePrefabValue();
        }
        
         private bool TryGetGoodBuff(out int buffValue)
         {
             var isGoodBuff = _meet >= MeetPrice;
 
             buffValue = Random.Range(35, 70);
             return isGoodBuff;
         }

         private void UpdatePrefabValue()
         {
             PlayerPrefs.SetInt("respect", _respect);
             PlayerPrefs.SetInt("meet", _meet);
             PlayerStats.NeedsUpdate = true;
         }
    }
}