using TMPro;
using UnityEngine;

namespace DefaultNamespace.Science
{
    public class PrepareYourself : IStatButton
    {
        public StatType StateType => StatType.Science;

        public string Text => "Готовиться самому";
        public string NeedPay => $"{Price} знаний";

        private const int Price = 250;
        private int _science;
        
        public void Buffs()
        {
            _science = PlayerPrefs.GetInt("science");

            if (TryGetGoodBuff(out var buff))
            {
                Debug.Log("Вы успешно готовитесь самостоятельно");
                _science += buff;
            }
            else
            {
                Debug.Log("У вас недостаточно знаний");
            }
            
            UpdatePrefabValue();
        }
        
        private bool TryGetGoodBuff(out int buffValue)
        {
            var isGoodBuff = _science >= 250;
            
            buffValue = isGoodBuff ? Random.Range(25, 75) : 0;
            return isGoodBuff;
        }
        
        private void UpdatePrefabValue()
        {
            PlayerPrefs.SetInt("science", _science);
            PlayerStats.NeedsUpdate = true;
        }
    }
}