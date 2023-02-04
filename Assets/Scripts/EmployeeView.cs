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
        employeeSalaryText.text = $"<b>Salary Demands:</b> ${employeeData.ExpectedSalary}";

        var experienceProperty = gameObject.transform.Find("Property Panel/Experience");
        var experiencePropertyText = experienceProperty.GetComponent<TextMeshProUGUI>();
        experiencePropertyText.text = $"Years of experience: {employeeData.ExperienceYears}";

        var codingRateProperty = gameObject.transform.Find("Property Panel/CodingSpeed");
        var codingRatePropertyText = codingRateProperty.GetComponent<TextMeshProUGUI>();
        codingRatePropertyText.text = $"Code production rate: {employeeData.CodeRate} lines per quarter";

        var conscientiousnessProperty = gameObject.transform.Find("Property Panel/Conscientiousness");
        var conscientiousnessPropertyText = conscientiousnessProperty.GetComponent<TextMeshProUGUI>();
        conscientiousnessPropertyText.text = $"Conscientiousness: {employeeData.Conscientiousness}";

        var creativityProperty = gameObject.transform.Find("Property Panel/Creativity");
        var creativityPropertyText = creativityProperty.GetComponent<TextMeshProUGUI>();
        creativityPropertyText.text = $"Creativity: {employeeData.Openness}";
    }

    public void EmployeeHireClicked()
    {
        GameManger.Instance.HireEmployee(employeeData, gameObject);
    }
}
