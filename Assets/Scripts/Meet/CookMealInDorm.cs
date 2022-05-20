using UnityEngine;

namespace DefaultNamespace
{
    public class CookMealInDorm : IStatButton
    {
        public StatType StateType => StatType.Meet;

        public string Text => "Приготовить еду в общаге";
        public string NeedPay => $"{MealPrice}р";

        private const int MealPrice = 500;

        private int _meet;
        private int _money;
        
        public void Buffs()
        {
            _meet = PlayerPrefs.GetInt("meet");
            _money = PlayerPrefs.GetInt("money");

            if (TryGetGoodBuff(out var buffValue))
            {
                Debug.Log("Ты приготовил вкусное блюдо, теперь у тебя больше знакомых");
                _meet += buffValue;
                _money -= MealPrice;
            }
            else
            {
                Debug.Log($"У тебя нет денег на покупку продуктов, необходимо: {MealPrice}," +
                          $" или в общаге итак все сыты");
            }
            
            UpdatePrefabValue();
        }
        
         private bool TryGetGoodBuff(out int buffValue)
         {
             var isGoodBuff = _money > MealPrice && Random.Range(0, 100) > 10;
             
             buffValue = isGoodBuff ? Random.Range(100, 150) : 0;
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