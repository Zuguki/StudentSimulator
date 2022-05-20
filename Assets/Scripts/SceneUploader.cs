using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneUploader : MonoBehaviour
{
    private Button _back;
    private Button _stats;
    private Button _sciences;
    private Button _respect;
    private Button _meet;
    private Button _money;
    private Button _shop;

    private void Awake()
    {
        if (IsCurrentScene("Start"))
            return;
        
        _back = gameObject.transform.GetChild(0).GetComponent<Button>();
        _stats = gameObject.transform.GetChild(1).GetComponent<Button>();
        _sciences = gameObject.transform.GetChild(2).GetComponent<Button>();
        _respect = gameObject.transform.GetChild(3).GetComponent<Button>();
        _meet = gameObject.transform.GetChild(4).GetComponent<Button>();
        _money = gameObject.transform.GetChild(5).GetComponent<Button>();
        _shop = gameObject.transform.GetChild(6).GetComponent<Button>();
    }

    private void Start()
    {
        if (IsCurrentScene("Start"))
            return;
        
        _back.onClick.AddListener(LoadMainScene);
        _stats.onClick.AddListener(LoadStatsScene);
        _sciences.onClick.AddListener(LoadSciencesScene);
        _respect.onClick.AddListener(LoadRespectScene);
        _meet.onClick.AddListener(LoadMeetScene);
        _money.onClick.AddListener(LoadMoneyScene);
        _shop.onClick.AddListener(LoadShopScene);
    }

    private static void LoadStatsScene() => SceneManager.LoadScene("Stats");
    
    private static void LoadMainScene() => SceneManager.LoadScene("Start");

    private static void LoadMoneyScene() => SceneManager.LoadScene("Money");

    private static void LoadSciencesScene() => SceneManager.LoadScene("Scines");

    private static void LoadRespectScene() => SceneManager.LoadScene("Respect");

    private static void LoadMeetScene() => SceneManager.LoadScene("Meet");

    private static void LoadShopScene() => SceneManager.LoadScene("Shop");

    private bool IsCurrentScene(string name) => SceneManager.GetActiveScene() == SceneManager.GetSceneByName(name);
}
