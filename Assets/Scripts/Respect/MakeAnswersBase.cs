using UnityEngine;

namespace DefaultNamespace.Respect
{
    public class MakeAnswersBase : IStatButton
    {
        public StatType StateType => StatType.Respect;
        public string Text => "Делать базу ответов";
        public string NeedPay => $"{MeetPrice} знакомств";

        private const int MeetPrice = 250;

        private int _respect;
        private int _meet;

        public void Buffs()
        {
            _respect = PlayerPrefs.GetInt("respect");
            _meet = PlayerPrefs.GetInt("meet");

            if (TryGetGoodBuff(out var buffValue))
            {
                PlayerStats.EventText = "О, ты успешно делаешь базу ответов, но тратишь на это много времени," +
                                        " количество знакомств уменьшилось";
                _respect += buffValue;
                _meet -= MeetPrice;
            }
            else
            {
                PlayerStats.EventText = "Иди знакомься для начала, у тебя мало знакомых";
            }
            
            UpdatePrefabValue();
        }
        
         private bool TryGetGoodBuff(out int buffValue)
         {
             var isGoodBuff = _meet >= MeetPrice;
 
             buffValue = Random.Range(100, 250);
             return isGoodBuff;
         }

         private void UpdatePrefabValue()
         {
             PlayerPrefs.SetInt("respect", _respect);
             PlayerPrefs.SetInt("meet", _meet);
             PlayerStats.NeedsUpdate = true;
         }
    }
}