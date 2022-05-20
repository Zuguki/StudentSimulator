using UnityEngine;

namespace DefaultNamespace.Money
{
    public class TakeNeighbourLiquid : IStatButton
    {
        public StatType StateType => StatType.Liquid;
        public string Text => "Залить жижу соседа, пока он не видит";
        public string NeedPay => "";

        private int _respect;
        private int _liquid;

        public void Buffs()
        {
            _respect = PlayerPrefs.GetInt("respect");
            _liquid = PlayerPrefs.GetInt("liquid");

            if (TryGetGoodBuff(out var buffValue))
            {
                Debug.Log("Вау, никто не заметил тебя, крыска");
                _liquid += buffValue;
            }
            else
            {
                Debug.Log("Лошара, тебя спалили");
                _respect -= _respect - buffValue > 0 ? buffValue : _respect;
            }
            
            UpdatePrefabValue();
        }
        
         private bool TryGetGoodBuff(out int buffValue)
         {
             var isGoodBuff = Random.Range(0, 100) > 40;
             
             buffValue = isGoodBuff ? Random.Range(0, 10) : Random.Range(25, 75);
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