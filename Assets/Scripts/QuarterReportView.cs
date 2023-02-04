using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuarterReportView : MonoBehaviour
{
    public QuarterResults CurrentResults;
    public int Year;
    public int Quarter;
    public string CompanyName;
    
    public void UpdateView()
    {
        var timeString = GameManger.Instance.CurrentTimeString;
        var titleObject = gameObject.transform.Find("Quarterly Report Popup/Top Panel/Title Background/Title");
        var titleObjectText = titleObject.GetComponent<TextMeshProUGUI>();
        titleObjectText.text = $" {CompanyName}\n {timeString} Financial Results";

        var quarterObject = gameObject.transform.Find("Quarterly Report Popup/Top Panel/Quarter Background/Quarter Text");
        var quarterObjectText = quarterObject.GetComponent<TextMeshProUGUI>();
        quarterObjectText.text = $"Q{Quarter}";

        var budgetObject = gameObject.transform.Find("Quarterly Report Popup/Profit Panel/Budget Data");
        var budgetObjectText = budgetObject.GetComponent<TextMeshProUGUI>();
        budgetObjectText.text = $"{CurrentResults.NewBudget}K USD";

        var profitResultObject = gameObject.transform.Find("Quarterly Report Popup/Profit Panel/Financial Data");
        var profitResultObjectText = profitResultObject.GetComponent<TextMeshProUGUI>();

        var profit = CurrentResults.NewBudget - CurrentResults.PreviousBudget;

        var bugObject = gameObject.transform.Find("Quarterly Report Popup/Media Panel/News Panel/Bugs");
        var bugObjectText = bugObject.GetComponent<TextMeshProUGUI>();
        bugObjectText.text = $"Reviews are in! {CurrentResults.NewBugCount} new bugs were found.";

        var codeObject = gameObject.transform.Find("Quarterly Report Popup/Media Panel/News Panel/LinesofCode");
        var codeObjectText = codeObject.GetComponent<TextMeshProUGUI>();
        codeObjectText.text = $"Source code leaked! {CurrentResults.NewCodeTotal},000 lines of code were found online.";

        if (CurrentResults.NewCodeTotal == 0)
        {
            codeObjectText.text = "";

        }

        if (profit > 0)
        {
            profitResultObjectText.text = $"Profits are up!\nWe made {profit}K USD!";
        }
        else
        {
            profitResultObjectText.text = $"Profits are down!\nYou lost {-profit}K USD!";
        }

        // DEMO MODE - only support Q1-Q2
        if (Quarter >= 2)
        {
            var buttonObject = gameObject.transform.Find("Button");
            var actualButton = buttonObject.GetComponent<Button>();
            actualButton.interactable = false;
        }
    }


    public void OnContinueButtonClicked()
    {
        GameManger.Instance.NextTurn();
    }
}
