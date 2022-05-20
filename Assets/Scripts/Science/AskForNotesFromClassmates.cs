using UnityEngine;

namespace DefaultNamespace.Science
{
    public class AskForNotesFromClassmates : IStatButton
    {
        public StatType StateType => StatType.Science;

        public string Text => "Попросить конспекты у одногруппников";

        private int _respect;
        private int _science;
        
        public void Buffs()
        {
            _respect = PlayerPrefs.GetInt("respect");
            _science = PlayerPrefs.GetInt("science");

            if (TryGetGoodBuff(out var buffValue))
            {
                PlayerStats.EventText = "Одногруппницы тебе ДАЛИ (конспект)";
                _science += buffValue;
            }
            else
            {
                PlayerStats.EventText = "Не дали в этот раз, уважения мало...";
            }

            UpdatePrefabValue();
        }
        
        private bool TryGetGoodBuff(out int buffValue)
        {
            var isGoodBuff = _respect > 1000;
            
            buffValue = isGoodBuff ? Random.Range(50, 100) : 0;
            return isGoodBuff;
        }
        
        private void UpdatePrefabValue()
        {
            PlayerPrefs.SetInt("respect", _respect);
            PlayerPrefs.SetInt("science", _science);
            PlayerStats.NeedsUpdate = true;
        }
    }
}