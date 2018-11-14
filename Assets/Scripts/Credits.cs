using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{

    private const float CREDIT_PROFIT_FROM = 0.3f;
    private const float CREDIT_PROFIT_TO = 0.7f;
    private const int CREDIT_DURATION_FROM = 3;
    private const int CREDIT_DURATION_TO = 5;
    private const float CREDIT_DEBT_FROM = 0.1f;
    private const float CREDIT_DEBT_TO = 0.2f;

    private int seasons;
    private float debit;
    private float percentNonReturn;
    private float percentPerYear;
    private float  profit;

    public int Seasons
    {
        get
        {
            return seasons;
        }

        set
        {
            if (value >= 0)
                seasons = value;
        }
    }

    //Процент получаемой прибыли за год. Случайная величина из диапазона CREDIT_PROFIT_FROM...CREDIT_PROFIT_TO.
    public float PercentPerYear
    {
        get
        {
            return percentPerYear;
        }

        set
        {
            percentPerYear = value;
        }
    }
    //Процент невозврата.Случайная величина из диапазона CREDIT_DEBT_FROM...CREDIT_DEBT_TO
    public float PercentNonReturn
    {
        get
        {
            return percentNonReturn;
        }

        set
        {
            percentNonReturn = value;
        }
    }
    /*Длительность кредитования. Доступный диапазон генерируется следующим образом:
      Минимальное время кредитования - случайная величина от 1 до CREDIT_DURATION_FROM
      Максимальное время - случайная величина от CREDIT_DURATION_FROM до CREDIT_DURATION_TO*/
    private int minCreditTimes;
    private int maxCreditTimes;

    /* Итоговая прибыль. profit = debt*(1+credit_profit*turns)*(1-credit_debt), где
      profit - итоговая прибыль, которую получит игрок
      debt - сумма, которую пользователь выдает в долг
      credit_profit - процент прибыли по кредиту за один ход
      turns - количество ходов. на которое выдается кредит
      credit_debt - % невозврата по кредиту*/

    public float Profit
    {
        get
        {
            return profit;
        }

    }


    public float Debit
    {
        get
        {
            return debit;
        }

        set
        {
            debit = value;
        }
    }


    public Credits()
    {

    }

    //set parametrs 
    public void SetParametrs()
    {
        percentPerYear = ((int)(Random.Range(CREDIT_PROFIT_FROM, CREDIT_PROFIT_TO) * 100)) / 100f;
        percentNonReturn = ((int)(Random.Range(CREDIT_DEBT_FROM, CREDIT_DEBT_TO) * 100)) / 100f;
        minCreditTimes = Random.Range(1, CREDIT_DURATION_FROM);
        maxCreditTimes = Random.Range(CREDIT_DURATION_FROM, CREDIT_DURATION_TO);
        Seasons = Random.Range(minCreditTimes, maxCreditTimes);
       
    }
    //calculate profit
    public float SetProfit()
    {
       return profit = debit * (1 + PercentPerYear * System.Convert.ToSingle(seasons)) * (1 - PercentNonReturn);
    }

}
