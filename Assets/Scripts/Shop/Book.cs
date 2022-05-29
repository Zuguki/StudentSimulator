using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Shop
{
    public class Book : IStatButton
    {
        public static string Name => "Учебник";
        
        public StatType StateType => StatType.Shop;
        public string Text => "Учебник";
        public string NeedPay => $"{BookPrice}р";

        private const int BookPrice = 500;

        private int _money;

        private readonly List<string> _goodEvents = new()
            {"Учебник теперь у вас", "Круто, вы купили учебник", "Поздравляю с новеньким учебником"};

        private readonly List<string> _badEvents = new()
            {"Деньжат подкопи", "Может ты крутой и у тебя уже есть учебник?", "Чет тебе не хотят продавать"};

        public void Buffs()
        {
            _money = PlayerPrefs.GetInt("money");

            if (_money >= BookPrice && !PlayerStats.Items.Contains(typeof(Book)))
            {
                _money -= BookPrice;
                PlayerStats.Items.Add(typeof(Book));
                PlayerStats.EventText = _goodEvents[Random.Range(0, _goodEvents.Count)];
            }
            else
                PlayerStats.EventText = _badEvents[Random.Range(0, _badEvents.Count)];
            
            UpdatePrefabValue();
        }
        
        private void UpdatePrefabValue()
        {
            PlayerPrefs.SetInt("money", _money);
            PlayerStats.NeedsUpdate = true;
        }
    }
}