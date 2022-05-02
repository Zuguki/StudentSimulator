using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static bool NeedsUpdate;
    
    [SerializeField] private GameObject statObject;
    [SerializeField] private bool isNewGame;

    private TextMeshProUGUI _scienceStat;
    private TextMeshProUGUI _meetingStat;
    private TextMeshProUGUI _respectStat;
    private TextMeshProUGUI _moneyStat;
    private TextMeshProUGUI _liquidStat;

    private int _science;
    private int _meet;
    private int _respect;
    private int _money;
    private int _liquid;

    private void Awake()
    {
        var statTransform = statObject.transform;
        
        _scienceStat = statTransform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>();
        _meetingStat = statTransform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>();
        _respectStat = statTransform.GetChild(2).GetComponentInChildren<TextMeshProUGUI>();
        _moneyStat = statTransform.GetChild(3).GetComponentInChildren<TextMeshProUGUI>();
        _liquidStat = statTransform.GetChild(4).GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        if (isNewGame)
            SetDefaultValues();
        
        UpdateStatsText();
    }

    private void SetDefaultValues()
    {
        PlayerPrefs.SetInt("science", 0);
        PlayerPrefs.SetInt("meet", 0);
        PlayerPrefs.SetInt("respect", 0);
        PlayerPrefs.SetInt("money", 0);
        PlayerPrefs.SetInt("liquid", 0);
    }

    private void Update()
    {
        if (NeedsUpdate)
            UpdateStatsText();
    }

    private void UpdateStatsText()
    {
        GetNewStats();

        _scienceStat.text = _science.ToString();
        _meetingStat.text = _meet.ToString();
        _respectStat.text = _respect.ToString();
        _moneyStat.text = _money.ToString();
        _liquidStat.text = _liquid.ToString();

        NeedsUpdate = false;
    }

    private void GetNewStats()
    {
        _science = PlayerPrefs.GetInt("science", 0);
        _meet = PlayerPrefs.GetInt("meet", 0);
        _respect = PlayerPrefs.GetInt("respect", 0);
        _money = PlayerPrefs.GetInt("money", 0);
        _liquid = PlayerPrefs.GetInt("liquid", 0);
    }
}
