using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Money
{
    public class AskLiquid : IStatButton
    {
        public StatType StateType => StatType.Liquid;
        public string Text => "Попросить у знакомых жижи";
        public string NeedPay => $"{NeedsRespect} уважения";

        private const int NeedsRespect = 250;

        private int _respect;
        private int _liquid;
        
        private readonly List<string> _goodEvents = new()
            {"Жижло есть", "Жижки много не бывает", "А ты хорошь, тебе опять ДАЛИ залить (жижу)"};

        private readonly List<string> _badEvents = new()
            {"Какая жижа? Тебя не уважают", "С тобой не хотят делиться", "Эх, опять не дали"};

        public void Buffs()
        {
            _respect = PlayerPrefs.GetInt("respect");
            _liquid = PlayerPrefs.GetInt("liquid");

            if (TryGetGoodBuff(out var buffValue))
            {
                PlayerStats.EventText = _goodEvents[Random.Range(0, _goodEvents.Count)];
                _liquid += buffValue;
            }
            else
                PlayerStats.EventText = _badEvents[Random.Range(0, _badEvents.Count)];
            
            UpdatePrefabValue();
        }
        
          private bool TryGetGoodBuff(out int buffValue)
          {
              var isGoodBuff = _respect >= NeedsRespect && Random.Range(0, 100) > 10;
              
              buffValue = isGoodBuff ? Random.Range(1, 5) : 0;
              return isGoodBuff;
          }
          
          private void UpdatePrefabValue()
          {
              PlayerPrefs.SetInt("respect", _respect);
              PlayerPrefs.SetInt("liquid", _liquid);
              PlayerStats.NeedsUpdate = true;
          }       
    }
}