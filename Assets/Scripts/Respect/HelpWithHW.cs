using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Respect
{
    public class HelpWithHW : IStatButton
    {
        public StatType StateType => StatType.Respect;
        public string Text => "Помочь с домашкой";
        public string NeedPay => $"{ScienceNeed} знаний";

        private const int ScienceNeed = 500;

        private int _science;
        private int _respect;
        
        private readonly List<string> _goodEvents = new()
        {
            "Одногруппница тебе очень благодарна :)", "Отлично помог, оказывается не только с домашкой",
            "Эх, умный парень"
        };

        private readonly List<string> _badEvents = new()
            {"Рофл? Ты же ничего не знаешь", "Ха-ха, себе помоги", "Без твоей помощи будет лучше"};

        public void Buffs()
        {
            _science = PlayerPrefs.GetInt("science");
            _respect = PlayerPrefs.GetInt("respect");

            if (TryGetGoodBuff(out var buffValue))
            {
                PlayerStats.EventText = _goodEvents[Random.Range(0, _goodEvents.Count)];
                _respect += buffValue;
            }
            else
                PlayerStats.EventText = _badEvents[Random.Range(0, _badEvents.Count)];
            
            UpdatePrefabValue();
        }
        
        private bool TryGetGoodBuff(out int buffValue)
        {
            var isGoodBuff = _science >= ScienceNeed;

            buffValue = isGoodBuff ? Random.Range(25, 55) : 0;
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