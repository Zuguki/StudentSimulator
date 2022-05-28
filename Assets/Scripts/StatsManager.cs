using System;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class StatsManager : MonoBehaviour
{
    private TextMeshProUGUI _scienceText, _meetText, _respectText, _moneyText, _liquidText, _timeText, _shopItemsText;

    private TextMeshProUGUI _textConverter;
    private TextMeshProUGUI _textLiquid;
    private Slider _slider;
    private Button _buyButton;
    private Button _sellButton;

    private int _science, _meet, _respect, _money, _liquid, _time;

    private int _liquidPrice;

    private void UpdateValues()
    {
        SetStats();

        _scienceText.text = _science.ToString();
        _meetText.text = _meet.ToString();
        _respectText.text = _respect.ToString();
        _moneyText.text = _money.ToString();
        _liquidText.text = _liquid.ToString();
        _timeText.text = _time.ToString();
        _shopItemsText.text = ParseShopItemsText();

        _liquidPrice = Random.Range(1, 25);
    }

    private static string ParseShopItemsText()
    {
        if (PlayerStats.Items.Count == 0)
            return "-";

        var sb = new StringBuilder();
        for (var index = 0; index < PlayerStats.Items.Count; index++)
        {
            var propValue = PlayerStats.Items[index].GetProperty("Name")?.GetValue(PlayerStats.Items[index]);

            sb.Append(index == 0 ? "" : ", ");
            sb.Append(propValue);
        }

        return sb.ToString();
    }

    private void Awake()
    {
        _scienceText = transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
        _meetText = transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>();
        _respectText = transform.GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>();
        _moneyText = transform.GetChild(3).GetChild(1).GetComponent<TextMeshProUGUI>();
        _liquidText = transform.GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>();
        _timeText = transform.GetChild(5).GetChild(1).GetComponent<TextMeshProUGUI>();
        _shopItemsText = transform.GetChild(6).GetChild(1).GetComponent<TextMeshProUGUI>();

        _textConverter = transform.GetChild(7).GetChild(0).GetComponent<TextMeshProUGUI>();
        _textLiquid = transform.GetChild(7).GetChild(1).GetComponent<TextMeshProUGUI>();
        _slider = transform.GetChild(7).GetChild(2).GetComponent<Slider>();
        _buyButton = transform.GetChild(7).GetChild(3).GetComponent<Button>();
        _sellButton = transform.GetChild(7).GetChild(4).GetComponent<Button>();
    }

    private void Start()
    {
        _textConverter.text = "Конвертер жижи";
        _slider.minValue = 0;
        _slider.maxValue = 100;

        _buyButton.onClick.RemoveAllListeners();
        _sellButton.onClick.RemoveAllListeners();

        _buyButton.onClick.AddListener(BuyLiquid);
        _sellButton.onClick.AddListener(SellLiquid);

        UpdateValues();
    }

    private void Update() => _textLiquid.text = $"{_slider.value}мл/{_liquidPrice}р";

    private void SetStats()
    {
        _science = PlayerPrefs.GetInt("science");
        _meet = PlayerPrefs.GetInt("meet");
        _respect = PlayerPrefs.GetInt("respect");
        _money = PlayerPrefs.GetInt("money");
        _liquid = PlayerPrefs.GetInt("liquid");
        _time = PlayerPrefs.GetInt("time");
    }

    private void BuyLiquid()
    {
        SetStats();
        if (_slider.value > _money)
            return;

        _liquid += (int) _slider.value;
        _money -= _liquidPrice * (int) _slider.value;

        Debug.Log($"SliderValue: {_slider.value}");

        PlayerPrefs.SetInt("money", _money);
        PlayerPrefs.SetInt("liquid", _liquid);
        PlayerStats.NeedsUpdate = true;
    }

    private void SellLiquid()
    {
        SetStats();
        if (_slider.value > _liquid)
            return;

        _liquid -= (int) _slider.value;
        _money += _liquidPrice * (int) _slider.value;

        PlayerPrefs.SetInt("money", _money);
        PlayerPrefs.SetInt("liquid", _liquid);
        PlayerStats.NeedsUpdate = true;
    }
}