using UnityEngine;

namespace DefaultNamespace.Money
{
    public class TakeSoprovsLiquid : IStatButton
    {
        public StatType StateType => StatType.Liquid;
        public string Text => "Забрать жижу у сопров";

        private const int NeedRespect = 5000;

        private int _respect;
        private int _science;
        private int _liquid;

        public void Buffs()
        {
            _respect = PlayerPrefs.GetInt("respect");
            _science = PlayerPrefs.GetInt("science");
            _liquid = PlayerPrefs.GetInt("liquid");

            if (TryGetGoodBuff(out var buffValue))
            {
                Debug.Log("Вау, красавец, не думал, что у тебя получится");
                _liquid += buffValue;
            }
            else
            {
                Debug.Log("Ну, в другой, раз, ты весь день извинялся, теперь у тебя нет жижи," +
                          " меньше уважения и уровень подготовки");
                _respect -= _respect - buffValue > 0 ? buffValue : _respect;
                _science -= _science - buffValue > 0 ? buffValue : _science;
                _liquid = 0;
            }
            
            UpdatePrefabValue();
        }
        
        
        private bool TryGetGoodBuff(out int buffValue)
        {
            var isGoodBuff = _respect > NeedRespect && Random.Range(0, 100) > 25;
            
            buffValue = isGoodBuff ? Random.Range(0, 100) : Random.Range(100, 200);
            return isGoodBuff;
        }
        
        private void UpdatePrefabValue()
        {
            PlayerPrefs.SetInt("respect", _respect);
            PlayerPrefs.SetInt("science", _science);
            PlayerPrefs.SetInt("liquid", _liquid);
            PlayerStats.NeedsUpdate = true;
        }
    }
}