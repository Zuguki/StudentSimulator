using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class MentorGroupChats : IStatButton
    {
        public StatType StateType => StatType.Meet;

        public string Text => "Менторить чатики групп";
        public string NeedPay => $"{SciencePrice} знаний";

        private const int SciencePrice = 200;

        private int _science;
        private int _meet;
        
        private readonly List<string> _goodEvents = new()
        {
            "Чатики под твоей защитой", "Не забывай про учебу, а то она проседает",
            "Ты познакомился с новыми ребятами"
        };

        private readonly List<string> _badEvents = new()
            {"Без тебя справятся", "Иди, учись", "А ты помнишь, что тут и учиться надо?"};

        public void Buffs()
        {
            _science = PlayerPrefs.GetInt("science");
            _meet = PlayerPrefs.GetInt("meet");

            if (TryGetGoodBuff(out var buffValue))
            {
                PlayerStats.EventText = _goodEvents[Random.Range(0, _goodEvents.Count)];
                _science -= SciencePrice / Random.Range(10, 100);
                _meet += buffValue;
            }
            else
                PlayerStats.EventText = _badEvents[Random.Range(0, _badEvents.Count)];
            
            UpdatePrefabValue();
        }
        
        
        private bool TryGetGoodBuff(out int buffValue)
        {
            var isGoodBuff = _science >= SciencePrice;
            
            buffValue = isGoodBuff ? Random.Range(15, 25) : 0;
            return isGoodBuff;
        }
        
        private void UpdatePrefabValue()
        {
            PlayerPrefs.SetInt("science", _science);
            PlayerPrefs.SetInt("meet", _meet);
            PlayerStats.NeedsUpdate = true;
        }
    }
}