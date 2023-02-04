using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuarterReportView : MonoBehaviour
{
    public QuarterResults CurrentResults;
    public int Year;
    public int Quarter;
    public string CompanyName;
    
    public void UpdateView()
    {
        var titleObject = gameObject.transform.Find("Quarterly Report Popup/Top Panel/Title Background/Title");
        var titleObjectText = titleObject.GetComponent<TextMeshProUGUI>();
        titleObjectText.text = $" {CompanyName}\n Financial Results";

        var quarterObject = gameObject.transform.Find("Quarterly Report Popup/Top Panel/Quarter Background/Quarter Text");
        var quarterObjectText = quarterObject.GetComponent<TextMeshProUGUI>();
        quarterObjectText.text = $"Q{Quarter}";
    }


    public void OnContinueButtonClicked()
    {
        GameManger.Instance.NextTurn();
    }
}
