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
    public void PopulateEmployees(EmployeeLoaderV2 empLoader)
    {
        availableEmployees = new List<Employee>();
        availableEmployees.AddRange(empLoader.myEmployeeList.employee);
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

    public Employee GetEmployee(int index)
    {
        Employee emp = availableEmployees[index];
        availableEmployees.RemoveAt(index);
        
        return emp;
    }
}
