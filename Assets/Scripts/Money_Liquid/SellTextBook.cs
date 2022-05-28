using System.Collections.Generic;
using DefaultNamespace.Shop;
using UnityEngine;

namespace DefaultNamespace.Money
{
    public class SellTextBook : IStatButton
    {
        public StatType StateType => StatType.Money;
        public string Text => "Продать учебники";
        public string NeedPay => "Учебник";

        private int _money;

        private readonly List<string> _goodEvents = new()
        {
            "Ты считаешь учиться больше не надо? Ну ладно", "Да, купить, позаниматься, продать", "Ну, деньги тоже нужны"
        };

        private readonly List<string> _badEvents = new()
            {"АЙМ СОРИ, какой еще учебник?", "Купи сначала", "Ой, не могу найти"};

        public void Buffs()
        {
            _money = PlayerPrefs.GetInt("money");

            if (PlayerStats.Items.Contains(typeof(Book)))
            {
                _money += 250;
                PlayerStats.Items.Remove(typeof(Book));
                PlayerStats.EventText = _goodEvents[Random.Range(0, _goodEvents.Count)];
            }
            else
                PlayerStats.EventText = _badEvents[Random.Range(0, _badEvents.Count)];

            UpdatePrefabValues();
        }

        private void UpdatePrefabValues()
        {
            PlayerPrefs.SetInt("money", _money);
            PlayerStats.NeedsUpdate = true;
        }
    }
}