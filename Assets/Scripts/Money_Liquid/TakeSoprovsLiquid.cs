using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Money
{
    public class TakeSoprovsLiquid : IStatButton
    {
        public StatType StateType => StatType.Liquid;
        public string Text => "Забрать жижу у сопров";
        public string NeedPay => $"{NeedRespect} уважения";

        private const int NeedRespect = 750;

        private int _respect;
        private int _science;
        private int _liquid;
        
        private readonly List<string> _goodEvents = new()
            {"Риск оправдался", "Фух, еле забрал", "Ну, ради жижки можно"};

        private readonly List<string> _badEvents = new()
            {"Тебя переиграли, вся жижа у них", "Как ты так просрал жижу...", "Куда ты полез?"};

        public void Buffs()
        {
            _respect = PlayerPrefs.GetInt("respect");
            _science = PlayerPrefs.GetInt("science");
            _liquid = PlayerPrefs.GetInt("liquid");

            if (TryGetGoodBuff(out var buffValue))
            {
                PlayerStats.EventText = _goodEvents[Random.Range(0, _goodEvents.Count)];
                _liquid += buffValue;
            }
            else
            {
                PlayerStats.EventText = _badEvents[Random.Range(0, _badEvents.Count)];
                _respect -= _respect - buffValue > 0 ? buffValue : _respect;
                _science -= _science - buffValue > 0 ? buffValue : _science;
                _liquid = 0;
            }
            
            UpdatePrefabValue();
        }
        
        
        private bool TryGetGoodBuff(out int buffValue)
        {
            var isGoodBuff = _respect >= NeedRespect && Random.Range(0, 100) > 25;
            
            buffValue = isGoodBuff ? Random.Range(20, 50) : Random.Range(25, 75);
            return isGoodBuff;
        }
        
        private void UpdatePrefabValue()
        {
            PlayerPrefs.SetInt("respect", _respect);
            PlayerPrefs.SetInt("science", _science);
            PlayerPrefs.SetInt("liquid", _liquid);
            PlayerStats.NeedsUpdate = true;
        }
    }
}