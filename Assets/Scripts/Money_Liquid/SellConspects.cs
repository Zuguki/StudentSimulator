﻿using UnityEngine;

namespace DefaultNamespace.Money
{
    public class SellConspects : IStatButton
    {
        public StatType StateType => StatType.Money;
        public string Text => "Продать конспекты";

        private const int NeedsScience = 3000;

        private int _science;
        private int _money;

        public void Buffs()
        {
            _science = PlayerPrefs.GetInt("science");
            _money = PlayerPrefs.GetInt("money");

            if (TryGetGoodBuff(out var buffValue))
            {
                Debug.Log("Так, конаспект продали, бабки получили, все З&С");
                _money += buffValue;
            }
            else
            {
                Debug.Log($"Ну, либо знаний маловато, нужно: {NeedsScience}, или не повезло");
            }
            
            UpdatePrefabValue();
        }
        
        private bool TryGetGoodBuff(out int buffValue)
        {
            var isGoodBuff = _science > NeedsScience && Random.Range(0, 100) > 10;
            
            buffValue = Random.Range(200, 600);
            return isGoodBuff;
        }
        
        private void UpdatePrefabValue()
        {
            PlayerPrefs.SetInt("science", _science);
            PlayerPrefs.SetInt("money", _money);
            PlayerStats.NeedsUpdate = true;
        }
    }
}