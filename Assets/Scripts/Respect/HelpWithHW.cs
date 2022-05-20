using UnityEngine;

namespace DefaultNamespace.Respect
{
    public class HelpWithHW : IStatButton
    {
        public StatType StateType => StatType.Respect;
        public string Text => "Помочь с домашкой";
        public string NeedPay => $"{ScienceNeed} знаний";

        private const int ScienceNeed = 3000;

        private int _science;
        private int _respect;

        public void Buffs()
        {
            _science = PlayerPrefs.GetInt("science");
            _respect = PlayerPrefs.GetInt("respect");

            if (TryGetGoodBuff(out var buffValue))
            {
                PlayerStats.EventText = "Одногруппница тебе очень благодарна :)";
                _respect += buffValue;
            }
            else
                PlayerStats.EventText = "Ты рофлишь? Ты слишком тупой, чтобы помочь кому то";
            
            UpdatePrefabValue();
        }
        
        private bool TryGetGoodBuff(out int buffValue)
        {
            var isGoodBuff = _science > ScienceNeed;

            buffValue = isGoodBuff ? Random.Range(100, 200) : 0;
            return isGoodBuff;
        }
         
        private void UpdatePrefabValue()
        {
            PlayerPrefs.SetInt("science", _science);
            PlayerPrefs.SetInt("respect", _respect);
            PlayerStats.NeedsUpdate = true;
        }       
    }
}