using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : UnityEngine.Object
{
    public Player()
    {
        CurrentEmployees = new List<Employee>();
        Budget = 100;
        BugCount = 0;
    }

    public readonly string CompanyName = "AMK Inc.";

    public int Budget // K USD
    {
        get;
        set;
    }
    public int BugCount
    {
        get;
        set;
    }
    public List<Employee> CurrentEmployees 
    {
        get;
        protected set;
    }

    public int GetSalariesTotal()
    {
        int salaryTotal = 0;

        foreach(Employee emp in CurrentEmployees)
        {
            salaryTotal += emp.ExpectedSalary;
        }

        return salaryTotal;
    }

    public int GetRemainingBudget()
    {
        return Budget - GetSalariesTotal();
    }

    public void HireEmployee(Employee emp)
    {
        CurrentEmployees.Add(emp);
    }

    public void FireEmployee(Employee emp)
    {
        CurrentEmployees.Remove(emp);
    }
}
