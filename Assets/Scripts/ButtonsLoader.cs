using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using DefaultNamespace.Science;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsLoader : MonoBehaviour
{
   [SerializeField] private GameObject buttonPrefab;
   [SerializeField] private GameObject content;
   [SerializeField] private StatType statType;

   private List<GameObject> _items = new();
   private VerticalLayoutGroup _group;
   private List<IStatButton> _stats = new()
   {
      new EventFromUniversity(), new MentorGroupChats(), 
      new AskForNotesFromClassmates(), new EngageInVideoCourse()
   };

   private void Start()
   {
      var rectT = content.GetComponent<RectTransform>();
      _group = GetComponent<VerticalLayoutGroup>();
      SetTitles(rectT);
   }

   private void SetTitles(Component rectT)
   {
      var currentState = _stats.Where(stat => stat.StateType == statType).ToList();
      rectT.transform.localPosition = new Vector3(0f, 0f, 0f);

      if (currentState.Count <= 0) 
         return;
      
      var prefabButton = Instantiate(buttonPrefab, transform);
      var height = prefabButton.GetComponent<RectTransform>().rect.height;
      var rectTransform = GetComponent<RectTransform>();
         
      rectTransform.sizeDelta = new Vector2(rectTransform.rect.width, height * currentState.Count);
         
      Destroy(prefabButton);
      foreach (var statButton in currentState)
      {
         var prefab = Instantiate(buttonPrefab, transform);
         prefab.GetComponentInChildren<Text>().text = statButton.Text;
         _items.Add(prefab);
      }
   }
}
