using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EmployeeView : MonoBehaviour
{
    public Employee employeeData;

    public void UpdateView()
    {
        var employeeName = gameObject.transform.Find("Name Panel/Name");
        var employeeNameText = employeeName.GetComponent<TextMeshProUGUI>();
        employeeNameText.text = employeeData.Name;

        var employeeSalary = gameObject.transform.Find("Name Panel/Salary");
        var employeeSalaryText = employeeSalary.GetComponent<TextMeshProUGUI>();
        employeeSalaryText.text = $"Salary Demands: {employeeData.ExpectedSalary}";

        var experienceProperty = gameObject.transform.Find("Property Panel/Property 1");
        var experiencePropertyText = experienceProperty.GetComponent<TextMeshProUGUI>();
        experiencePropertyText.text = $"Years of experience: {employeeData.ExperienceYears}";

        var codingRateProperty = gameObject.transform.Find("Property Panel/Property 2");
        var codingRatePropertyText = codingRateProperty.GetComponent<TextMeshProUGUI>();
        codingRatePropertyText.text = $"Code production rate: {employeeData.CodeRate}K lines per quarter";
    }

    public void EmployeeHireClicked()
    {
        GameManger.Instance.HireEmployee(employeeData, gameObject);
    }
}
