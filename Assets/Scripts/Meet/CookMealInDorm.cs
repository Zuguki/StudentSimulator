using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class CookMealInDorm : IStatButton
    {
        public StatType StateType => StatType.Meet;

        public string Text => "Приготовить еду в общаге";
        public string NeedPay => $"{MealPrice}р";

        private const int MealPrice = 750;

        private int _meet;
        private int _money;
        
        private readonly List<string> _goodEvents = new()
        {
            "Вот это ты готовишь, так вкусно получилось", "Удивительно, всем понравилось",
            "Где ты так научился готовить?"
        };

        private readonly List<string> _badEvents = new()
            {"Продукты подорожали", "Магазинчики то закрыты уже", "Обойдутся без твоей еды"};
        
        public void Buffs()
        {
            _meet = PlayerPrefs.GetInt("meet");
            _money = PlayerPrefs.GetInt("money");

            if (TryGetGoodBuff(out var buffValue))
            {
                PlayerStats.EventText = _goodEvents[Random.Range(0, _goodEvents.Count)];
                _meet += buffValue;
                _money -= MealPrice;
            }
            else
                PlayerStats.EventText = _badEvents[Random.Range(0, _badEvents.Count)];
            
            UpdatePrefabValue();
        }
        
         private bool TryGetGoodBuff(out int buffValue)
         {
             var isGoodBuff = _money >= MealPrice;
             
             buffValue = isGoodBuff ? Random.Range(75, 100) : 0;
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