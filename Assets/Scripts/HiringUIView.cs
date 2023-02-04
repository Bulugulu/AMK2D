using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HiringUIView : MonoBehaviour
{
    public Player PlayerInfo;

    public void UpdateView()
    {
        var currencyStatus = gameObject.transform.Find("Currency Panel/Currency");
        var currencyStatusText = currencyStatus.GetComponent<TextMeshProUGUI>();
        currencyStatusText.text = $"{PlayerInfo.Budget}K USD";
    }

    public void OnContinueButtonClicked()
    {
        GameManger.Instance.FinalizeHiring();
    }
}
