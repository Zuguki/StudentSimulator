using UnityEngine;

namespace DefaultNamespace
{
    public class MentorGroupChats : IStatButton
    {
        public StatType StateType => StatType.Meet;

        public string Text => "Менторить чатики групп";
        public string NeedPay => $"{SciencePrice} знаний";

        private const int SciencePrice = 250;

        private int _science;
        private int _meet;

        public void Buffs()
        {
            _science = PlayerPrefs.GetInt("science");
            _meet = PlayerPrefs.GetInt("meet");

            if (TryGetGoodBuff(out var buffValue))
            {
                PlayerStats.EventText = "Вы участвуете в ивенте, нашли новых друзей, но учеба просела";
                _science -= SciencePrice;
                _meet += buffValue;
            }
            else
                PlayerStats.EventText = $"Тебе надо учиться, не хватает: {SciencePrice - _science} знанаий";
            
            UpdatePrefabValue();
        }
        
        
        private bool TryGetGoodBuff(out int buffValue)
        {
            var isGoodBuff = _science > SciencePrice;
            
            buffValue = isGoodBuff ? Random.Range(75, 100) : 0;
            return isGoodBuff;
        }
        
        private void UpdatePrefabValue()
        {
            PlayerPrefs.SetInt("science", _science);
            PlayerPrefs.SetInt("meet", _meet);
            PlayerStats.NeedsUpdate = true;
        }
    }
}