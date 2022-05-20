using System;
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

        private const int SciencePrice = 200;

        private int _science;
        private int _meet;

        public void Buffs()
        {
            _science = PlayerPrefs.GetInt("science");
            _meet = PlayerPrefs.GetInt("meet");

            if (TryGetGoodBuff(out var buffValue))
            {
                Debug.Log("Вы участвуете в ивенте, нашли новых друзей, но учеба просела");
                _science -= SciencePrice;
                _meet += buffValue;
            }
            else
            {
                Debug.Log($"Тебе надо учиться, не хватает: {SciencePrice - _science} знанаий");
            }
            
            UpdatePrefabValue();
        }
        
        private bool TryGetGoodBuff(out int buffValue)
        {
            var isGoodBuff = _science > SciencePrice;
            
            buffValue = isGoodBuff ? Random.Range(50, 75) : 0;
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