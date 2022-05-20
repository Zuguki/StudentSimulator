using DefaultNamespace.Shop;
using UnityEngine;

namespace DefaultNamespace.Money
{
    public class SellTextBook : IStatButton
    {
        public StatType StateType => StatType.Money;
        public string Text => "Продать учебники";
        public string NeedPay => "";

        private int _money;

        public void Buffs()
        {
            _money = PlayerPrefs.GetInt("money");

            if (PlayerStats.Items.Contains(typeof(Book)))
            {
                _money += 250;
                PlayerStats.Items.Remove(typeof(Book));
                PlayerStats.EventText = "Учебник продан";
            }
            else
                PlayerStats.EventText = "У вас не учебника";

            UpdatePrefabValues();
        }

        private void UpdatePrefabValues()
        {
            PlayerPrefs.SetInt("money", _money);
            PlayerStats.NeedsUpdate = true;
        }
    }
}