using UnityEngine;

namespace DefaultNamespace.Respect
{
    public class OpenDoorNight : IStatButton
    {
        public StatType StateType => StatType.Respect;
        public string Text => "Открыть дверь в общагу ночью";

        private int _respect;
        private int _science;
        
        public void Buffs()
        {
            _respect = PlayerPrefs.GetInt("respect");
            _science = PlayerPrefs.GetInt("science");

            if (TryGetGoodBuff(out var buffValue))
            {
                Debug.Log("Вау, тебя не спалили, молодец");
                _respect += buffValue;
            }
            else
            {
                Debug.Log("Фааак, тебя спалили, подготовка к экзаменам ухудшилась, ведь ты весь день извинялся");
                _science -= _science - buffValue > 0 ? buffValue : _science;
            }
            
            UpdatePrefabValue();
        }

        private bool TryGetGoodBuff(out int buffValue)
        {
            var isGoodBuff = Random.Range(0, 100) > 65; 
            
            buffValue = isGoodBuff ? Random.Range(50, 75) : Random.Range(50, 100);
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