using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
        experiencePropertyText.text = $"<b>Years of experience:</b> {employeeData.ExperienceYears}";

        var codingRateProperty = gameObject.transform.Find("Property Panel/CodingSpeed");
        var codingRatePropertyText = codingRateProperty.GetComponent<TextMeshProUGUI>();
        codingRatePropertyText.text = $"<b>Code production rate:</b> {employeeData.CodeRate} lines per quarter";

        var conscientiousnessProperty = gameObject.transform.Find("Property Panel/Conscientiousness");
        var conscientiousnessPropertyText = conscientiousnessProperty.GetComponent<TextMeshProUGUI>();
        conscientiousnessPropertyText.text = $"<b>Conscientiousness:</b> {employeeData.Conscientiousness}";

        var creativityProperty = gameObject.transform.Find("Property Panel/Creativity");
        var creativityPropertyText = creativityProperty.GetComponent<TextMeshProUGUI>();
        creativityPropertyText.text = $"<b>Creativity:</b> {employeeData.Openness}";

        var avatar = gameObject.transform.Find("Avatar");
        var avatarImage = Resources.Load<Sprite>($"{employeeData.AvatarPath}");
        avatar.GetComponent<Image>().sprite = avatarImage;
        Debug.Log(avatar);
        Debug.Log(avatarImage);
    }

    public void EmployeeHireClicked()
    {
        GameManger.Instance.HireEmployee(employeeData, gameObject);
    }
}
