using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Science
{
    public class HireTutor : IStatButton
    {
        public StatType StateType => StatType.Science;

        public string Text => "Заниматься с репетитором";
        public string NeedPay => $"{TutorPrice}р";

        private int _money;
        private int _science;

        private const int TutorPrice = 1_000;
        
        private readonly List<string> _goodEvents = new()
        {
            "Репетитор прикольный", "Как то деньжат стало заметно меньше",
            "Кто то заработал на тебе, но и ты узнал новое"
        };

        private readonly List<string> _badEvents = new()
        {
            "С таким кошельком никому ты не нужен", "С тобой никто не хочет работать",
            "Синяя купюра нужна!"
        };
        
        public void Buffs()
        {
            _money = PlayerPrefs.GetInt("money");
            _science = PlayerPrefs.GetInt("science");

            if (TryGetGoodBuff(out var buffValue))
            {
                _money -= TutorPrice;
                _science += buffValue;
                PlayerStats.EventText = _goodEvents[Random.Range(0, _goodEvents.Count)];
            }
            else
                PlayerStats.EventText = _badEvents[Random.Range(0, _badEvents.Count)];
            
            UpdatePrefabValue();
        }
        
        private bool TryGetGoodBuff(out int buffValue)
        {
            var isGoodBuff = _money >= TutorPrice;
            
            buffValue = isGoodBuff ? Random.Range(100, 200) : 0;
            return isGoodBuff;
        }
        
        private void UpdatePrefabValue()
        {
            PlayerPrefs.SetInt("money", _money);
            PlayerPrefs.SetInt("science", _science);
            PlayerStats.NeedsUpdate = true;
        }
    }
}