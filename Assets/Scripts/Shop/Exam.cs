using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Shop
{
    public class Exam : IStatButton
    {
        public static string Name => "Экзамен";
        
        public StatType StateType => StatType.Shop;
        public string Text => "Экзамен";
        public string NeedPay => $"{ExamPrice}р";

        private const int ExamPrice = 50_000;

        private readonly List<string> _goodEvents = new()
            {"Ну все, можно не переживать по поводу экзаменов", "Богатенький ты студент", "Откуда столько денег?"};

        private readonly List<string> _badEvents = new()
            {"Бедный студент... Совсем отчаялся", "Чет не хотят тебе экзамен продать", "Лол, какой экзамен, иди учись"};
        
        private int _money;

        public void Buffs()
        {
            _money = PlayerPrefs.GetInt("money");

            if (_money >= ExamPrice && !PlayerStats.Items.Contains(typeof(Exam)))
            {
                PlayerStats.Items.Add(typeof(Exam));
                _money -= ExamPrice;
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