using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EmployeePool : UnityEngine.Object
{
    public EmployeePool()
    {
    }

    private List<Employee> availableEmployees;
    public void PopulateEmployees()
    {
        availableEmployees = new List<Employee>();
        // TODO: replace with loading employees from JSON files
        for (int i=0; i<10; ++i)
        {
            var emp = new Employee();
            emp.Name = "Employee #" + i;
            emp.ExpectedSalary = Random.Range(10,100);
            emp.CodeRate = Random.Range(1,10);
            emp.BugCreationRate = Random.Range(0,10);
            emp.BugFixRate = Random.Range(0,3);
            emp.ExperienceYears = Random.Range(0,20);
            emp.Openness = (OpennessRating) Random.Range(0,2);
            emp.Conscientiousness = (ConscientiousnessRating) Random.Range(0,2);

            availableEmployees.Add(emp);
        }
    }

    public Employee GetSampleEmployee()
    {
        var emp = new Employee();
        emp.Name = "Sample Employee";
        emp.ExpectedSalary = 10;
        emp.CodeRate = 5;
        emp.BugCreationRate = 100;
        emp.BugFixRate = 1;
        emp.ExperienceYears = 2;
        emp.Openness = OpennessRating.Low;
        emp.Conscientiousness = ConscientiousnessRating.Low;

        return emp;
    }

    public int AvailableEmployeesCount()
    {
        return availableEmployees.Count;
    }

    public List<Employee> GetEmployees(int count)
    {
        var returnedEmployees = new List<Employee>();
        if (count > availableEmployees.Count)
        {
            return null;
        }
        for(int i=0; i < count; ++i)
        {
            Employee emp = null;
            var randEmpIndex = Random.Range(0, availableEmployees.Count-1);
            emp = availableEmployees[randEmpIndex];
            availableEmployees.RemoveAt(randEmpIndex);
            returnedEmployees.Add(emp);
        }
        return returnedEmployees;
    }
}
