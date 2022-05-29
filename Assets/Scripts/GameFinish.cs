using DefaultNamespace;
using DefaultNamespace.Shop;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameFinish : MonoBehaviour
{
    [SerializeField] private GameObject eventUI;
    [SerializeField] private GameObject player;

    private TextMeshProUGUI _title;
    private TextMeshProUGUI _description;
    private Button _startNew;

    private bool _needsUpdate = true;

    private void Awake()
    {
        _title = eventUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        _description = eventUI.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        _startNew = eventUI.transform.GetChild(2).GetComponent<Button>();
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("time") > 0)
            return;

        if (_needsUpdate)
            Show();
    }

    private void Show()
    {
        _needsUpdate = false;
        if (PlayerWon(out var wonFor))
        {
            _title.text = "Поздравляю";
            _description.text = $"Вы успешно завершили первый семестр, вам помогли ваши: {Parse(wonFor)}";
        }
        else
        {
            _title.text = "Грустненько";
            _description.text = "Ну, не получилось сдать экзамены в этом семестре, тебе следует перепоступить";
        }

        _startNew.onClick.AddListener(UpdateUI);
        eventUI.SetActive(true);
        player.SetActive(false);
    }

    private void UpdateUI()
    {
        eventUI.SetActive(false);
        player.SetActive(true);
        
        SceneUploader.LoadNewGame();
        _needsUpdate = true;
        _startNew.onClick.RemoveAllListeners();
    }

    private static string Parse(StatType wonFor) =>
        wonFor switch
        {
            StatType.Science => "знания",
            StatType.Meet => "друзья",
            StatType.Money => "деньги",
            _ => "Хз, что помогло, 'ХАКЕР'"
        };

    private static bool PlayerWon(out StatType wonFor)
    {
        wonFor = StatType.None;
        if (WonForStat("science", 1000))
            wonFor = StatType.Science;

        if (WonForStat("meet", 1000) && WonForStat("respect", 500))
            wonFor = StatType.Meet;

        if (PlayerStats.Items.Contains(typeof(Exam)))
            wonFor = StatType.Money;

        return wonFor is not StatType.None;
    }

    private static bool WonForStat(string stat, int value) => PlayerPrefs.GetInt(stat) >= value;
}