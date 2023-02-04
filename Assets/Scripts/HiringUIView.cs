using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HiringUIView : MonoBehaviour
{
    public Player PlayerInfo;
    public GameObject TeamGridUI;

    private List<Employee> RenderedEmployees = new List<Employee>();

    public void UpdateView()
    {
        var currencyStatus = gameObject.transform.Find("Currency Panel/Currency");
        var currencyStatusText = currencyStatus.GetComponent<TextMeshProUGUI>();
        currencyStatusText.text = $"{PlayerInfo.Budget}K USD";

        foreach(Employee emp in PlayerInfo.CurrentEmployees)
        {
            // Only render new hires
            if (RenderedEmployees.Contains(emp) == false)
            {
                var employeeProfile = Instantiate(GameManger.Instance.EmployeeProfilePrefab);
                var empView = employeeProfile.GetComponent<EmployeeView>();
                empView.employeeData = emp;
                empView.UpdateView(true);

                employeeProfile.transform.SetParent(TeamGridUI.transform, false);
                
                RenderedEmployees.Add(emp);
            }
        }

        var salariesStatus = gameObject.transform.Find("Salaries Panel/Salaries");
        var salariesStatusText = salariesStatus.GetComponent<TextMeshProUGUI>();
        salariesStatusText.text = $"Salaries total:\n{PlayerInfo.GetSalariesTotal()}K USD per quarter";
    }

    public void OnContinueButtonClicked()
    {
        GameManger.Instance.FinalizeHiring();
    }
}
