using UnityEngine;

namespace DefaultNamespace.Respect
{
    public class OrderFood : IStatButton
    {
        public StatType StateType => StatType.Respect;
        public string Text => "Заказать на соседей еды";
        public string NeedPay => $"{FoodPrice}р";

        private const int FoodPrice = 1000;

        private int _respect;
        private int _money;

        public void Buffs()
        {
            _respect = PlayerPrefs.GetInt("respect");
            _money = PlayerPrefs.GetInt("money");

            if (TryGetGoodBuff(out var buffValue))
            {
                Debug.Log("Вы вкусно покушали, всем понравилась еда");
                _respect += buffValue;
                _money -= FoodPrice;
            }
            else
            {
                Debug.Log($"Заработай для начала, за тебя платить не будут необходимо: {FoodPrice}");
            }
            
            UpdatePrefabValue();
        }
        
         private bool TryGetGoodBuff(out int buffValue)
         {
             var isGoodBuff = _money >= FoodPrice;
 
             buffValue = isGoodBuff ? Random.Range(200, 300) : 0;
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