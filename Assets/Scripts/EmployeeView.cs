using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EmployeeView : MonoBehaviour
{
    public Employee employeeData;

    public void UpdateView(bool hired = false)
    {
        var employeeName = gameObject.transform.Find("Name Panel/Name");
        var employeeNameText = employeeName.GetComponent<TextMeshProUGUI>();
        employeeNameText.text = employeeData.Name;

        var employeeSalary = gameObject.transform.Find("Name Panel/Salary");
        var employeeSalaryText = employeeSalary.GetComponent<TextMeshProUGUI>();
        employeeSalaryText.text = $"<b>Salary Demands:</b> ${employeeData.ExpectedSalary}K per quarter";

        var experienceProperty = gameObject.transform.Find("Property Panel/Experience");
        var experiencePropertyText = experienceProperty.GetComponent<TextMeshProUGUI>();
        experiencePropertyText.text = $"<b>Years of experience:</b> {employeeData.ExperienceYears}";

        var codingRateProperty = gameObject.transform.Find("Property Panel/CodingSpeed");
        var codingRatePropertyText = codingRateProperty.GetComponent<TextMeshProUGUI>();
        codingRatePropertyText.text = $"<b>Code production rate:</b> {employeeData.CodeRate}K lines per quarter";

        var conscientiousnessProperty = gameObject.transform.Find("Property Panel/Conscientiousness");
        var conscientiousnessPropertyText = conscientiousnessProperty.GetComponent<TextMeshProUGUI>();
        conscientiousnessPropertyText.text = $"<b>Conscientiousness:</b> {employeeData.Conscientiousness}";

        var creativityProperty = gameObject.transform.Find("Property Panel/Creativity");
        var creativityPropertyText = creativityProperty.GetComponent<TextMeshProUGUI>();
        creativityPropertyText.text = $"<b>Creativity:</b> {employeeData.Openness}";

        var avatar = gameObject.transform.Find("Avatar");
        var avatarImage = Resources.Load<Sprite>($"{employeeData.AvatarPath}");
        avatar.GetComponent<Image>().sprite = avatarImage;
        
        if (hired)
        {
            gameObject.transform.Find("Hire Button").gameObject.SetActive(false);
            var backgroundImage = gameObject.transform.Find("Background").GetComponent<Image>();
            backgroundImage.color = Color.gray;
        }
    }

    public void EmployeeHireClicked()
    {
        GameManger.Instance.HireEmployee(employeeData, gameObject);
        GameManger.Instance.PlayBtn2SFX();
    }
}
