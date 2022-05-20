using UnityEngine;

namespace DefaultNamespace.Money
{
    public class AskLiquid : IStatButton
    {
        public StatType StateType => StatType.Liquid;
        public string Text => "Попросить у знакомых жижи";
        public string NeedPay => $"{NeedsRespect} уважения";

        private const int NeedsRespect = 500;

        private int _respect;
        private int _liquid;

        public void Buffs()
        {
            _respect = PlayerPrefs.GetInt("respect");
            _liquid = PlayerPrefs.GetInt("liquid");

            if (TryGetGoodBuff(out var buffValue))
            {
                PlayerStats.EventText = "Вау, ты крут, тебе ДАЛИ залить (жижу)";
                _liquid += buffValue;
            }
            else
                PlayerStats.EventText = "Эх, опять жижла не дали";
            
            UpdatePrefabValue();
        }
        
          private bool TryGetGoodBuff(out int buffValue)
          {
              var isGoodBuff = _respect > NeedsRespect && Random.Range(0, 100) > 10;
              
              buffValue = isGoodBuff ? Random.Range(5, 20) : 0;
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