using UnityEngine;

namespace DefaultNamespace
{
    public class GoToTheAlley : IStatButton
    {
        public StatType StateType => StatType.Meet;

        public string Text => "Пить на аллейкe";
        public string NeedPay => $"{DrinkPrice}р";

        private const int DrinkPrice = 500;

        private int _meet;
        private int _money;
        
        public void Buffs()
        {
            _meet = PlayerPrefs.GetInt("meet");
            _money = PlayerPrefs.GetInt("money");

            if (TryGetGoodBuff(out var buffValue))
            {
                Debug.Log("Ты потусил на аллейке и вас не поймали, теперь у тебя больше знакомых");
                _meet += buffValue;
                _money -= DrinkPrice;
            }
            else
            {
                Debug.Log($"У тебя нет денег на выпивку, нужно: {DrinkPrice}");
            }
            
            UpdatePrefabValue();
        }
        
        private bool TryGetGoodBuff(out int buffValue)
        {
            var isGoodBuff = _money > DrinkPrice && Random.Range(0, 100) > 10;
            
            buffValue = isGoodBuff ? Random.Range(100, 150) : 0;
            return isGoodBuff;
        }
        
        private void UpdatePrefabValue()
        {
            PlayerPrefs.SetInt("meet", _meet);
            PlayerPrefs.SetInt("money", _money);
            PlayerStats.NeedsUpdate = true;
        }
    }
}