using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class GoToTheAlley : IStatButton
    {
        public StatType StateType => StatType.Meet;

        public string Text => "Пить на аллейкe";
        public string NeedPay => $"{DrinkPrice}р";

        private const int DrinkPrice = 500;

        private int _meet;
        private int _money;
        
        private readonly List<string> _goodEvents = new()
        {
            "Опять бухаем? Где ты так заработал?", "Аккуратней, могут поймать",
            "Я вот думаю, что у тебя зависимость скоро будет"
        };

        private readonly List<string> _badEvents = new()
            {"Не вышло в этот раз", "Ха, тебе не продали алко", "А алко то уже не продают"};
        
        public void Buffs()
        {
            _meet = PlayerPrefs.GetInt("meet");
            _money = PlayerPrefs.GetInt("money");

            if (TryGetGoodBuff(out var buffValue))
            {
                PlayerStats.EventText = _goodEvents[Random.Range(0, _goodEvents.Count)];
                _meet += buffValue;
                _money -= DrinkPrice;
            }
            else
                PlayerStats.EventText = _badEvents[Random.Range(0, _badEvents.Count)];
            
            UpdatePrefabValue();
        }
        
        private bool TryGetGoodBuff(out int buffValue)
        {
            var isGoodBuff = _money >= DrinkPrice && Random.Range(0, 100) > 10;
            
            buffValue = isGoodBuff ? Random.Range(50, 75) : 0;
            return isGoodBuff;
        }
        
        private void UpdatePrefabValue()
        {
            PlayerPrefs.SetInt("meet", _meet);
            PlayerPrefs.SetInt("money", _money);
            PlayerStats.NeedsUpdate = true;
        }
    }
}