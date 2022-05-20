using UnityEngine;

namespace DefaultNamespace.Respect
{
    public class GoToKillFish : IStatButton
    {
        public StatType StateType => StatType.Respect;
        public string Text => "Позвать одногрупников в KillFish";
        public string NeedPay => $"{KillFishPrice}р";

        private const int KillFishPrice = 1000;

        private int _respect;
        private int _money;

        public void Buffs()
        {
            _respect = PlayerPrefs.GetInt("respect");
            _money = PlayerPrefs.GetInt("money");

            if (TryGetGoodBuff(out var buffValue))
            {
                PlayerStats.EventText = "Вы сходили в KillFish и успешно провели время";
                _respect += buffValue;
                _money -= KillFishPrice;
            }
            else
                PlayerStats.EventText = $"Заработай для начала, за тебя платить не будут необходимо: {KillFishPrice}";
            
            UpdatePrefabValue();
        }
        
         private bool TryGetGoodBuff(out int buffValue)
         {
             var isGoodBuff = _money >= KillFishPrice;
 
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