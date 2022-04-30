using UnityEngine;

namespace DefaultNamespace.Science
{
    public class WriteOffClassmate : IStatButton
    {
        public StatType StateType => StatType.Science;

        public string Text => "Списать у одногрупника, пока он не видит";

        private int _respect;
        
        public void Buffs()
        {
            _respect = PlayerPrefs.GetInt("respect", 0);
            if (TryGetGoodBuff(out var buffValue))
            {
                Debug.Log("Успешно списал");
                _respect += buffValue;
            }
            else
            {
                Debug.Log("Неуспешно :(");
                _respect -= _respect - buffValue > 0 ? buffValue : _respect;
            }

            UpdatePrefabValue();
        }

        private static bool TryGetGoodBuff(out int buffValue)
        {
            var isGoodBuff = Random.Range(0, 100) > 25;
            
            buffValue = isGoodBuff ? Random.Range(0, 50) : Random.Range(25, 75);
            return isGoodBuff;
        }

        private void UpdatePrefabValue()
        {
            PlayerPrefs.SetInt("respect", _respect);
            PlayerStats.NeedsUpdate = true;
        }
    }
}