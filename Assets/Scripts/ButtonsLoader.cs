using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsLoader : MonoBehaviour
{
   [SerializeField] private string[] titles;

   [SerializeField] private GameObject buttonPrefab;
   [SerializeField] private GameObject content;

   private List<GameObject> _items = new();
   private VerticalLayoutGroup _group;
   private List<IStatButton> _stats = new() {new EventFromUniversity(), new MentorGroupChats()};

   private void Start()
   {
      var rectT = content.GetComponent<RectTransform>();
      _group = GetComponent<VerticalLayoutGroup>();
      SetTitles(rectT);
   }

   private void SetTitles(RectTransform rectT)
   {
      rectT.transform.localPosition = new Vector3(0f, 0f, 0f);
      if (titles.Length > 0)
      {
         var prefabButton = Instantiate(buttonPrefab, transform);
         var height = prefabButton.GetComponent<RectTransform>().rect.height;
         var rectTransform = GetComponent<RectTransform>();
         
         rectTransform.sizeDelta = new Vector2(rectTransform.rect.width, height * _stats.Count);
         
         Destroy(prefabButton);
         foreach (var statButton in _stats)
         {
            var prefab = Instantiate(buttonPrefab, transform);
            prefab.GetComponentInChildren<Text>().text = statButton.Text;
            _items.Add(prefab);
         }
      }
   }
}
