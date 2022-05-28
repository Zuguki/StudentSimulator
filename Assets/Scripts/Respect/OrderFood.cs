using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Respect
{
    public class OrderFood : IStatButton
    {
        public StatType StateType => StatType.Respect;
        public string Text => "Заказать на соседей еды";
        public string NeedPay => $"{FoodPrice}р";

        private const int FoodPrice = 1_000;

        private int _respect;
        private int _money;
        
        private readonly List<string> _goodEvents = new()
        {
            "Сосед кайфанул, еще бы попарить", "Мак комбо на всех? А ты хорош!",
            "Где ты столько денег взял?"
        };

        private readonly List<string> _badEvents = new()
            {"Ой, а деньжат то нет :)", "Ты что, хочешь отравить всех?", "Ты видел цену на мак комбо?"};

        public void Buffs()
        {
            _respect = PlayerPrefs.GetInt("respect");
            _money = PlayerPrefs.GetInt("money");

            if (TryGetGoodBuff(out var buffValue))
            {
                PlayerStats.EventText = _goodEvents[Random.Range(0, _goodEvents.Count)];
                _respect += buffValue;
                _money -= FoodPrice;
            }
            else
                PlayerStats.EventText = _badEvents[Random.Range(0, _badEvents.Count)];
            
            UpdatePrefabValue();
        }
        
         private bool TryGetGoodBuff(out int buffValue)
         {
             var isGoodBuff = _money >= FoodPrice;
 
             buffValue = isGoodBuff ? Random.Range(60, 100) : 0;
             return isGoodBuff;
         }
          
         private void UpdatePrefabValue()
         {
             PlayerPrefs.SetInt("respect", _respect);
             PlayerPrefs.SetInt("money", _money);
             PlayerStats.NeedsUpdate = true;
         }       

    }
}