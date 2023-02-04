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
