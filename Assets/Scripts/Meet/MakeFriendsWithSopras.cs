using UnityEngine;

namespace DefaultNamespace
{
    public class MakeFriendsWithSopras : IStatButton
    {
        public StatType StateType => StatType.Meet;
        
        public string Text => "Скорешиться с сопрами";

        private const int NeedsRespectStat = 5000;

        private int _meet;
        private int _respect;
        private int _science;
        
         public void Buffs()
         {
             _meet = PlayerPrefs.GetInt("meet");
             _respect = PlayerPrefs.GetInt("respect");
             _science = PlayerPrefs.GetInt("science");
 
             if (TryGetGoodBuff(out var buffValue))
             {
                 Debug.Log("Ты затусил с сопрами, теперь у тебя больше знакомых");
                 _meet += buffValue;
             }
             else
             {
                 Debug.Log($"Тебя обосрали, в другой раз повезет, " +
                           $"уважение должно быть больше {NeedsRespectStat}");
                 _meet -= _meet - buffValue > 0 ? buffValue : _meet;
                 _respect -= _respect - buffValue > 0 ? buffValue : _respect;
                 _science -= _science - buffValue > 0 ? buffValue : _science;
             }
             
             UpdatePrefabValue();
         }
         
         
         private bool TryGetGoodBuff(out int buffValue)
         {
             var isGoodBuff = _respect > NeedsRespectStat && Random.Range(0, 100) > 20;
             
             buffValue = isGoodBuff ? Random.Range(200, 300) : Random.Range(400, 600);
             return isGoodBuff;
         }
         
         private void UpdatePrefabValue()
         {
             PlayerPrefs.SetInt("meet", _meet);
             PlayerPrefs.SetInt("respect", _respect);
             PlayerPrefs.SetInt("science", _science);
             PlayerStats.NeedsUpdate = true;
         }       
    }
}