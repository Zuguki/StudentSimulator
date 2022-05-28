using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace DefaultNamespace.Science
{
    public class PrepareYourself : IStatButton
    {
        public StatType StateType => StatType.Science;

        public string Text => "Готовиться самому";
        public string NeedPay => $"{Price} знаний";

        private const int Price = 100;
        private int _science;
        
        private readonly List<string> _goodEvents = new()
        {
            "Ну и готовься сам, не интересно:(", "1 + 1 сможешь решить",
            "Ты какой то слишком умный"
        };

        private readonly List<string> _badEvents = new()
        {
            "Какой сам? Ты, сложение не знаешь", "Маловато знаний то", "Не позорься!"
        };
        
        public void Buffs()
        {
            _science = PlayerPrefs.GetInt("science");

            if (TryGetGoodBuff(out var buff))
            {
                PlayerStats.EventText = _goodEvents[Random.Range(0, _goodEvents.Count)];
                _science += buff;
            }
            else
                PlayerStats.EventText = _badEvents[Random.Range(0, _badEvents.Count)];
            
            UpdatePrefabValue();
        }
        
        private bool TryGetGoodBuff(out int buffValue)
        {
            var isGoodBuff = _science >= Price;
            
            buffValue = isGoodBuff ? Random.Range(0, 25) : 0;
            return isGoodBuff;
        }
        
        private void UpdatePrefabValue()
        {
            PlayerPrefs.SetInt("science", _science);
            PlayerStats.NeedsUpdate = true;
        }
    }
}