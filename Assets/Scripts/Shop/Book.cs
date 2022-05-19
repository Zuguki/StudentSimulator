﻿using UnityEngine;

namespace DefaultNamespace.Shop
{
    public class Book : IStatButton
    {
        public StatType StateType => StatType.Shop;
        public string Text => "Учебник";

        private const int BookPrice = 500;

        private int _money;

        public void Buffs()
        {
            _money = PlayerPrefs.GetInt("money");

            if (_money >= BookPrice && !PlayerStats.Items.Contains(typeof(Book)))
            {
                PlayerStats.Items.Add(typeof(Book));
                Debug.Log("Учебник теперь у вас");
            }
            else
            {
                Debug.Log("Денег то нет, ну или ты крутой, учебник уже у тебя");
            }
            
            UpdatePrefabValue();
        }
        
        private void UpdatePrefabValue()
        {
            PlayerPrefs.SetInt("money", _money);
            PlayerStats.NeedsUpdate = true;
        }
    }
}