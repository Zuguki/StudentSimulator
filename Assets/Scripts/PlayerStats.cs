using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static List<Type> Items = new();

    public static bool NeedsUpdate;
    public static string EventText;
    public static bool IsNewGame;
    public static bool HackSystem;

    private const float EventTime = 2f;

    [SerializeField] private GameObject statObject;
    [SerializeField] private GameObject eventPrefab;

    private TextMeshProUGUI _scienceStat;
    private TextMeshProUGUI _meetingStat;
    private TextMeshProUGUI _respectStat;
    private TextMeshProUGUI _moneyStat;
    private TextMeshProUGUI _liquidStat;
    private TextMeshProUGUI _timeStat;

    private TextMeshProUGUI _eventText;

    private int _science;
    private int _meet;
    private int _respect;
    private int _money;
    private int _liquid;
    private int _time;

    private int _previousItemsCount;
    private bool _needsSerialize = true;

    private readonly Color _defaultColor = Color.black;
    private readonly Color _upgradeColor = Color.blue;
    private readonly Color _downgradeColor = Color.red;


    private void Awake()
    {
        var statTransform = statObject.transform;

        _scienceStat = statTransform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>();
        _meetingStat = statTransform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>();
        _respectStat = statTransform.GetChild(2).GetComponentInChildren<TextMeshProUGUI>();
        _moneyStat = statTransform.GetChild(3).GetComponentInChildren<TextMeshProUGUI>();
        _liquidStat = statTransform.GetChild(4).GetComponentInChildren<TextMeshProUGUI>();
        _timeStat = statTransform.GetChild(5).GetComponentInChildren<TextMeshProUGUI>();

        _eventText = eventPrefab.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        if (IsNewGame)
            SetDefaultValues();
        if (HackSystem)
            SetHackValues();

        UpdateStatsText();
    }

    private static void SetHackValues()
    {
        PlayerPrefs.SetInt("science", 100000);
        PlayerPrefs.SetInt("meet", 100000);
        PlayerPrefs.SetInt("respect", 100000);
        PlayerPrefs.SetInt("money", 100000);
        PlayerPrefs.SetInt("liquid", 100000);
        PlayerPrefs.SetInt("time", 100000);

        HackSystem = false;
    }

    private static void SetDefaultValues()
    {
        PlayerPrefs.SetInt("science", 0);
        PlayerPrefs.SetInt("meet", 0);
        PlayerPrefs.SetInt("respect", 0);
        PlayerPrefs.SetInt("money", 0);
        PlayerPrefs.SetInt("liquid", 0);
        PlayerPrefs.SetInt("time", 365);

        Items = new List<Type>();
        if (File.Exists("items.txt"))
            File.Delete("items.txt");
        
        IsNewGame = false;
    }

    private void Update()
    {
        if (!NeedsUpdate)
            return;

        ShowEvent();
        ChangeTime();
        UpdateStatsText();
        StatsManager.SetLiquidPrice();
    }

    private void ShowEvent()
    {
        StopAllCoroutines();
        StartCoroutine(ShowEventCoroutine());
    }

    private IEnumerator ShowEventCoroutine()
    {
        _eventText.text = EventText;
        eventPrefab.SetActive(true);

        yield return new WaitForSeconds(EventTime);
        eventPrefab.SetActive(false);
    }

    private void ChangeTime()
    {
        _time = PlayerPrefs.GetInt("time", _time);
        _time--;
        PlayerPrefs.SetInt("time", _time);
    }

    private void UpdateStatsText()
    {
        SetNewStats();

        UpdateStats(_scienceStat, _science);
        UpdateStats(_meetingStat, _meet);
        UpdateStats(_respectStat, _respect);
        UpdateStats(_moneyStat, _money);
        UpdateStats(_liquidStat, _liquid);
        UpdateStats(_timeStat, _time);

        if (_previousItemsCount != Items.Count)
            UpdateData();

        if (_needsSerialize)
            UpdateItems();

        _needsSerialize = false;
        NeedsUpdate = false;
    }

    private void UpdateItems()
    {
        if (!File.Exists("items.txt"))
            return;
        
        using var fs = new FileStream("items.txt", FileMode.Open);
        var bf = new BinaryFormatter();
        Items = (List<Type>) bf.Deserialize(fs);
    }

    private void UpdateData()
    {
        using var fs = new FileStream("items.txt", FileMode.OpenOrCreate);
        _previousItemsCount = Items.Count;
        var bf = new BinaryFormatter();
        bf.Serialize(fs, Items);

        _needsSerialize = true;
    }

    private void SetNewStats()
    {
        _science = PlayerPrefs.GetInt("science");
        _meet = PlayerPrefs.GetInt("meet");
        _respect = PlayerPrefs.GetInt("respect");
        _money = PlayerPrefs.GetInt("money");
        _liquid = PlayerPrefs.GetInt("liquid");
        _time = PlayerPrefs.GetInt("time");
    }

    private void UpdateStats(TMP_Text stat, int value)
    {
        var good = int.TryParse(stat.text, out var statValue);
        if (!good || statValue == value)
        {
            stat.text = value.ToString();
            return;
        }

        StartCoroutine(ChangeColor(int.Parse(stat.text) < value, stat));
        stat.text = value.ToString();
    }

    private IEnumerator ChangeColor(bool isUpgrade, Graphic stat)
    {
        stat.color = isUpgrade ? _upgradeColor : _downgradeColor;

        yield return new WaitForSeconds(EventTime);
        stat.color = _defaultColor;
    }
}