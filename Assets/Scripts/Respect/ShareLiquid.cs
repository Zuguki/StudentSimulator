using UnityEngine;

namespace DefaultNamespace.Respect
{
    public class ShareLiquid : IStatButton
    {
        public StatType StateType => StatType.Respect;
        public string Text => "Поделиться жижей с соседом";
        public string NeedPay => $"{LiquidPrice}ж";

        private const int LiquidPrice = 10;

        private int _liquid;
        private int _respect;
        
        public void Buffs()
        {
            _liquid = PlayerPrefs.GetInt("liquid");
            _respect = PlayerPrefs.GetInt("respect");

            if (TryGetGoodBuff(out var buffValue))
            {
                PlayerStats.EventText = "Молодец, ты спас соседа";
                _liquid -= LiquidPrice;
                _respect += buffValue;
            }
            else
                PlayerStats.EventText = $"У тебя недостаточно жижи! {LiquidPrice}";
            
            UpdatePrefabValue();
        }
        
        private bool TryGetGoodBuff(out int buffValue)
        {
            var isGoodBuff = _liquid > LiquidPrice;
            
            buffValue = isGoodBuff ? Random.Range(25, 75) : 0;
            return isGoodBuff;
        }
        
        private void UpdatePrefabValue()
        {
            PlayerPrefs.SetInt("liquid", _liquid);
            PlayerPrefs.SetInt("respect", _respect);
            PlayerStats.NeedsUpdate = true;
        }
    }
}