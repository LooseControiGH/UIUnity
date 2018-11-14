using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCredits : MonoBehaviour
{
    public GameObject uiCredits;
    public Text txtPerYear;
    public Text txtNonReturn;
    public Text txtExadition;
    public Text txtProfit;
    public Text txtSeason;
    public Text txtSliderMax;
    public Slider slider;

    private Credits credit;
    // Use this for initialization
    void Start()
    {
        credit = new Credits();
        credit.SetParametrs();
        uiCredits.SetActive(false);
    }

    public void ShowCredit()
    {
        //Show credit window
        credit.SetParametrs();
        txtPerYear.text = credit.PercentPerYear.ToString() + "%";
        txtNonReturn.text = credit.PercentNonReturn.ToString() + "%";
        txtSeason.text = credit.Seasons.ToString();
        slider.value = 1;
        uiCredits.SetActive(!uiCredits.activeSelf);

    }
    
    public void PlusSeasons()
    {
        credit.Seasons++;
        txtSeason.text = credit.Seasons.ToString();
    }

    public void MinusSeasons()
    {
        credit.Seasons--;
        txtSeason.text = credit.Seasons.ToString();
    }

    public void Close()
    {
        uiCredits.SetActive(false);
    }

    public void SliderValue(float _value)
    {
        credit.Debit = _value;
        txtSliderMax.text = credit.Debit.ToString();
        txtExadition.text = credit.Debit.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        SliderValue(slider.value);
        txtProfit.text = credit.SetProfit().ToString();
    }
}


