using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.IO;

public class EmployeeLoader : MonoBehaviour
{

    [SerializeField]
    private string employeePath;

    private Employee employee;

    void start()
    {
        Debug.Log("EmployeeLoader started");
        LoadEmployees();

    }



    [ContextMenu("Load Employees")]
    // This function loads employees from Json
    private void LoadEmployees()
    {
        Debug.Log("LoadEmployees Started");

        using (StreamReader stream = new StreamReader(employeePath))
        {
            string json = stream.ReadToEnd();
            employee = JsonUtility.FromJson<Employee>(json);

            Debug.Log("Employees Loaded: " + employee.Name);
            FindObjectOfType<Text>().text = employee.ToString();

        }


        if (employee = null)
        {
            Debug.LogError("Json path invalid");

        }

    }

}
