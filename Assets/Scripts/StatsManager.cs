using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class StatsManager : MonoBehaviour
{

    private TextMeshProUGUI _scienceText, _meetText, _respectText, _moneyText, _liquidText, _timeText, _shopItemsText;

    private int _science, _meet, _respect, _money, _liquid, _time;

    public void UpdateValues()
    {
        _scienceText.text = _science.ToString();
        _meetText.text = _meet.ToString();
        _respectText.text = _respect.ToString();
        _moneyText.text = _money.ToString();
        _liquidText.text = _liquid.ToString();
        _timeText.text = _liquid.ToString();
        _shopItemsText.text = ParseShopItemsText();
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

    private void Start()
    {
        _scienceText = transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
        _meetText = transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>();
        _respectText = transform.GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>();
        _moneyText = transform.GetChild(3).GetChild(1).GetComponent<TextMeshProUGUI>();
        _liquidText = transform.GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>();
        _timeText = transform.GetChild(5).GetChild(1).GetComponent<TextMeshProUGUI>();
        _shopItemsText = transform.GetChild(6).GetChild(1).GetComponent<TextMeshProUGUI>();

        _science = PlayerPrefs.GetInt("science");
        _meet = PlayerPrefs.GetInt("meet");
        _respect = PlayerPrefs.GetInt("respect");
        _money = PlayerPrefs.GetInt("money");
        _liquid = PlayerPrefs.GetInt("liquid");
        _time = PlayerPrefs.GetInt("time");
        
        UpdateValues();
    }
}
