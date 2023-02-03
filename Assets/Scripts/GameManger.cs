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
    public EmployeeLoaderV2 EmployeeLoader;

    private Player PlayerInfo;

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

    public void HireEmployee(Employee emp, GameObject employeeProfileView)
    {
        Debug.Log("Hiring employee!");
        PlayerInfo.CurrentEmployees.Add(emp);

        // TODO: move to hired employees view instead of destroying
        Destroy(employeeProfileView);
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
        PlayerInfo = new Player();
    }

    public void PopulateHiringUI()
    {
        var employees = EmployeesPool.GetEmployees(HIRING_POOL_SIZE);

        for (int i=0; i< HIRING_POOL_SIZE; ++i)
        {
            var emp = employees[i];

            var employeeProfile = Instantiate(EmployeeProfilePrefab);
            var empView = employeeProfile.GetComponent<EmployeeView>();
            empView.employeeData = emp;
            empView.UpdateView();

            employeeProfile.transform.SetParent(HiringGridUI.transform, false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        EmployeesPool.PopulateEmployees(EmployeeLoader);

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
