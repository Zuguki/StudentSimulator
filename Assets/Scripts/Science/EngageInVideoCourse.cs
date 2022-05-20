using DefaultNamespace.Shop;
using UnityEngine;

namespace DefaultNamespace.Science
{
    public class EngageInVideoCourse : IStatButton
    {
        public StatType StateType => StatType.Science;

        public string Text => "Заниматься по видео курсу";
        public string NeedPay => "";

        private int _science;
        
        public void Buffs()
        {
            _science = PlayerPrefs.GetInt("science");

            if (TryGetGoodBuff(out var buffValue))
            {
                Debug.Log("Хорош, курс прикольный");
                _science += buffValue;
            }
            else
            {
                Debug.Log("Тебе следует купить курс");
            }
            
            UpdatePrefabValue();
        }
        
        private static bool TryGetGoodBuff(out int buffValue)
        {
            var isGoodBuff = PlayerStats.Items.Contains(typeof(VideoCourse));
            
            buffValue = isGoodBuff ? Random.Range(50, 25) : 0;
            return isGoodBuff;
        }
        
        private void UpdatePrefabValue()
        {
            PlayerPrefs.SetInt("science", _science);
            PlayerStats.NeedsUpdate = true;
        }
    }
}