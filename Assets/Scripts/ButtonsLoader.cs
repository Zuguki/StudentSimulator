using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using DefaultNamespace.Money;
using DefaultNamespace.Respect;
using DefaultNamespace.Science;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsLoader : MonoBehaviour
{
   [SerializeField] private GameObject buttonPrefab;
   [SerializeField] private GameObject content;
   [SerializeField] private StatType statType;

   private readonly List<IStatButton> _stats = new()
   {
      new WriteOffClassmate(), new PrepareYourself(), new PrepareAccordingToTextbooks(),
      new AskForNotesFromClassmates(), new EngageInVideoCourse(), new HireTutor(),
      
      new ShareLiquid(), new OpenDoorNight(), new HelpWithHW(),
      new MakeAnswersBase(), new GoToKillFish(), new OrderFood(),
      
      new EventFromUniversity(), new MentorGroupChats(), new MakeFriendsWithSopras(),
      new GoToTheAlley(), new CookMealInDorm(),
      
      new TakeNeighbourLiquid(), new AskLiquid(), new TakeSoprovsLiquid(),
      
      new FixElectronic(), new SellConspects(), new SellTextBook()
   };

   private void Start()
   {
      var rectT = content.GetComponent<RectTransform>();
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
      }
   }
}
