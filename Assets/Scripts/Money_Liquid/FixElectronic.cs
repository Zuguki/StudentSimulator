using UnityEngine;

namespace DefaultNamespace.Money
{
    public class FixElectronic : IStatButton
    {
        public StatType StateType => StatType.Money;
        public string Text => "Починить подик знакомому";
        public string NeedPay => $"{NeedsScience} знаний, {NeedsMeet} знакомств";

        private const int NeedsMeet = 1000;
        private const int NeedsScience = 1000;

        private int _meet;
        private int _science;
        private int _respect;
        private int _money;

        public void Buffs()
        {
            _meet = PlayerPrefs.GetInt("meet");
            _science = PlayerPrefs.GetInt("science");
            _respect = PlayerPrefs.GetInt("respect");
            _money = PlayerPrefs.GetInt("money");

            if (TryGetGoodBuff(out var buffValue))
            {
                PlayerStats.EventText = "О, теперь мы делаем бизнес";
                _money += buffValue;
            }
            else
            {
                PlayerStats.EventText = "Так, ну тут, либо заказов нет, либо знаний нет, либо срукожопил где то";
                _meet -= _meet - buffValue > 0 ? buffValue : _meet;
                _science -= _science - buffValue > 0 ? buffValue : _science;
                _respect -= _respect - buffValue > 0 ? buffValue : _respect;
            }
            
            UpdatePrefabValue();
        }
        
        private bool TryGetGoodBuff(out int buffValue)
        {
            var isGoodBuff = _meet > NeedsMeet && _science > NeedsScience && Random.Range(0, 100) > 10;
            
            buffValue = Random.Range(100, 500);
            return isGoodBuff;
        }
        
        private void UpdatePrefabValue()
        {
            PlayerPrefs.SetInt("meet", _meet);
            PlayerPrefs.SetInt("science", _science);
            PlayerPrefs.SetInt("respect", _respect);
            PlayerPrefs.SetInt("money", _money);
            PlayerStats.NeedsUpdate = true;
        }
    }
}