using DefaultNamespace.Shop;
using UnityEngine;

namespace DefaultNamespace.Science
{
    public class PrepareAccordingToTextbooks : IStatButton
    {
        public StatType StateType => StatType.Science;

        public string Text => "Готовиться по учебникам";

        private int _science;
        
        public void Buffs()
        {
            _science = PlayerPrefs.GetInt("science");

            if (TryGetGoodBuff(out var buffValue))
            {
                Debug.Log("Хорош, позанимался");
                _science += buffValue;
            }
            else
            {
                Debug.Log("Тебе следует купить учебник!");
            }
            
            UpdatePrefabValue();
        }
        
        private static bool TryGetGoodBuff(out int buffValue)
        {
            var isGoodBuff = PlayerStats.Items.Contains(typeof(Book));
            
            buffValue = isGoodBuff ? Random.Range(25, 50) : 0;
            return isGoodBuff;
        }
        
        private void UpdatePrefabValue()
        {
            PlayerPrefs.SetInt("science", _science);
            PlayerStats.NeedsUpdate = true;
        }
    }
}