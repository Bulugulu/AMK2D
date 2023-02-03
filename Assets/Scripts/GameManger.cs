using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// GAME MANAGER SINGLETON
public class GameManger : MonoBehaviour
{
    private const int DEFAULT_YEAR = 1980;
    private const int DEFAULT_QUARTER = 2;
    private const int HIRING_POOL_SIZE = 3;

    public GameObject EmployeeProfilePrefab;
    public GameObject HiringGridUI;


    private GameManger() {
        Reset();
    }

    private static GameManger _instance;

    public static GameManger Instance { get { return _instance; } }


    public string CurrentTimeString
    {
        get {return $"{CurrentYear}-Q{CurrentQuarter}";}
    }

    public int CurrentYear
    {
        get;
        protected set;
    }

    public int CurrentQuarter
    {
        get;
        protected set;
    }

    public EmployeePool EmployeesPool
    {
        get;
        protected set;
    }

    public string NextTurn()
    {
        if (CurrentQuarter == 4)
        {
            CurrentQuarter = 1;
            ++CurrentYear;
        }
        else
        {
            ++CurrentQuarter;
        }
        
        return CurrentTimeString;
    }

    public void Reset ()
    {
        CurrentYear = DEFAULT_YEAR;
        CurrentQuarter = DEFAULT_QUARTER;
        EmployeesPool = new EmployeePool();
    }

    public void PopulateHiringUI()
    {
        var employees = EmployeesPool.GetEmployees(HIRING_POOL_SIZE);

        for (int i=0; i< HIRING_POOL_SIZE; ++i)
        {
            var employeeProfile = Instantiate(EmployeeProfilePrefab);
            
            var employeeName = employeeProfile.transform.Find("Name Panel/Name");
            var employeeNameText = employeeName.GetComponent<TextMeshProUGUI>();
            employeeNameText.text = employees[i].Name;

            var employeeSalary = employeeProfile.transform.Find("Name Panel/Salary");
            var employeeSalaryText = employeeSalary.GetComponent<TextMeshProUGUI>();
            employeeSalaryText.text = $"Salary Demands: {employees[i].ExpectedSalary}";

            var experienceProperty = employeeProfile.transform.Find("Property Panel/Property 1");
            var experiencePropertyText = experienceProperty.GetComponent<TextMeshProUGUI>();
            experiencePropertyText.text = $"Years of experience: {employees[i].ExperienceYears}";

            var codingRateProperty = employeeProfile.transform.Find("Property Panel/Property 2");
            var codingRatePropertyText = codingRateProperty.GetComponent<TextMeshProUGUI>();
            codingRatePropertyText.text = $"Code production rate: {employees[i].CodeRate}K lines per quarter";

            employeeProfile.transform.SetParent(HiringGridUI.transform, false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        EmployeesPool.PopulateEmployees();

        PopulateHiringUI();
    }

    private void Awake()
    {
        if (Instance == null)
            _instance = this;
        else if (Instance != this)
            Destroy(gameObject.GetComponent(Instance.GetType()));
        DontDestroyOnLoad(gameObject);
    }
}
