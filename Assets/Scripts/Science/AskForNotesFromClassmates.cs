using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Science
{
    public class AskForNotesFromClassmates : IStatButton
    {
        public StatType StateType => StatType.Science;

        public string Text => "Попросить конспекты у одногруппников";
        public string NeedPay => $"{Price} уважения";

        private const int Price = 250;
        private int _respect;
        private int _science;
        
        private readonly List<string> _goodEvents = new()
        {
            "Он тебе дал...", "Одногрупник тебя уважает, теперь можно позанимться",
            "Я не знаю как, но ты понравился одногрупнице и она тебе ДАЛА (конспект)"
        };

        private readonly List<string> _badEvents = new()
        {
            "Тебя чуть не избили", "Сказали: 'Иди ка ты наФиг'",
            "Окуратней, тебя не уважают"
        };
        
        public void Buffs()
        {
            _respect = PlayerPrefs.GetInt("respect");
            _science = PlayerPrefs.GetInt("science");

            if (TryGetGoodBuff(out var buffValue))
            {
                PlayerStats.EventText = _goodEvents[Random.Range(0, _goodEvents.Count)];
                _science += buffValue;
            }
            else
                PlayerStats.EventText = _badEvents[Random.Range(0, _badEvents.Count)];

            UpdatePrefabValue();
        }
        
        private bool TryGetGoodBuff(out int buffValue)
        {
            var isGoodBuff = _respect >= Price;
            
            buffValue = isGoodBuff ? Random.Range(20, 50) : 0;
            return isGoodBuff;
        }
        
        private void UpdatePrefabValue()
        {
            PlayerPrefs.SetInt("respect", _respect);
            PlayerPrefs.SetInt("science", _science);
            PlayerStats.NeedsUpdate = true;
        }
    }
}