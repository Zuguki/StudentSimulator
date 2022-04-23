using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class EventFromUniversity : IStatButton
    {
        public StatType StateType => StatType.Meet;
        public string Text => "Участвовать в ивенте от вуза";

        public void Buffs()
        { }
    }
}