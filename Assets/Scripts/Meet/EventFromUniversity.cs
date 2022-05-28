using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class EventFromUniversity : IStatButton
    {
        public StatType StateType => StatType.Meet;
        public string Text => "Участвовать в ивенте от вуза";
        public string NeedPay => $"{SciencePrice} знаний";

        private const int SciencePrice = 100;

        private int _science;
        private int _meet;
        
        private readonly List<string> _goodEvents = new()
        {
            "О, нашел новых друзей, но учуба просела", "Да, ребята прикольные",
            "Ну, много времени ты там занимался"
        };

        private readonly List<string> _badEvents = new()
            {"А ты помнишь, что учиться надо?", "Сходи, почитай", "С таким глупеньким не захотят общаться"};

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
            
            buffValue = isGoodBuff ? Random.Range(10, 15) : 0;
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