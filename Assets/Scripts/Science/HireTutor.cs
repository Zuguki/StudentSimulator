using UnityEngine;

namespace DefaultNamespace.Science
{
    public class HireTutor : IStatButton
    {
        public StatType StateType => StatType.Science;

        public string Text => "Заниматься с репетитором";
        public string NeedPay => $"{TutorPrice}р";

        private int _money;
        private int _science;

        private const int TutorPrice = 1000;
        
        public void Buffs()
        {
            _money = PlayerPrefs.GetInt("money");
            _science = PlayerPrefs.GetInt("science");

            if (TryGetGoodBuff(out var buffValue))
            {
                _money -= TutorPrice;
                _science += buffValue;
                PlayerStats.EventText = "Ну, нормально позанимались";
            }
            else
                PlayerStats.EventText = "Бомжара, иди работай";
            
            UpdatePrefabValue();
        }
        
        private bool TryGetGoodBuff(out int buffValue)
        {
            var isGoodBuff = _money >= TutorPrice;
            
            buffValue = isGoodBuff ? Random.Range(200, 250) : 0;
            return isGoodBuff;
        }
        
        private void UpdatePrefabValue()
        {
            PlayerPrefs.SetInt("money", _money);
            PlayerPrefs.SetInt("science", _science);
            PlayerStats.NeedsUpdate = true;
        }
    }
}