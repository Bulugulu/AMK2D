using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// GAME MANAGER SINGLETON
public class GameManger : MonoBehaviour
{
    private const int DEFAULT_YEAR = 2023;
    private const int DEFAULT_QUARTER = 1;
    private const int HIRING_POOL_SIZE = 4;


    public GameObject HiringUI;
    public GameObject QuarterReportUI;

    public GameObject EmployeeProfilePrefab;
    public GameObject HiringGridUI;
    public EmployeeLoaderV2 EmployeeLoader;

    public AudioSource btnSFX;
    public AudioSource profitSFX;
    public AudioSource lossSFX;
    public AudioSource musicLoop;

    private Player PlayerInfo;

    private GameManger() {
        Reset();
    }

    private static GameManger _instance;

    public static GameManger Instance { get { return _instance; } }

    public string CurrentTimeString
    {
        get {return $"{CurrentYear}Q{CurrentQuarter}";}
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

    public bool TryHireEmployee(Employee emp, GameObject employeeProfileView)
    {
        if (PlayerInfo.GetRemainingBudget() < emp.ExpectedSalary)
        {
            // Can't hire this employee :(
            return false;
        }

        PlayerInfo.CurrentEmployees.Add(emp);
        Destroy(employeeProfileView);

        var hiringView = HiringUI.GetComponent<HiringUIView>();
        hiringView.UpdateView();

        return true;
    }

    public void NextTurn()
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
        
        // move to hiring screen
        QuarterReportUI.SetActive(false);
        HiringUI.SetActive(true);

        PopulateHiringUI();
    }

    public void FinalizeHiring()
    {
        var newQuarterResults = BigNumbersMachine.CrunchNumbers(PlayerInfo);

        // play audio feedback based on result difference
        musicLoop.volume = 0.05f;
        if (PlayerInfo.Budget < newQuarterResults.NewBudget)
        {
            profitSFX.Play();
        } else {
            lossSFX.Play();
        }

        PlayerInfo.Budget = newQuarterResults.NewBudget;
        PlayerInfo.BugCount = newQuarterResults.NewBugCount;

        // move to quarter report
        HiringUI.SetActive(false);
        QuarterReportUI.SetActive(true);

        var QRView = QuarterReportUI.GetComponent<QuarterReportView>();
        QRView.Year = CurrentYear;
        QRView.Quarter = CurrentQuarter;
        QRView.CompanyName = PlayerInfo.CompanyName;
        QRView.CurrentResults = newQuarterResults;
        QRView.UpdateView();

        Debug.Log($"Current budget is {PlayerInfo.Budget}");
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
        var hiringView = HiringUI.GetComponent<HiringUIView>();
        hiringView.PlayerInfo = PlayerInfo;
        hiringView.UpdateView();

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

    public void PlayBtn2SFX() {
        btnSFX.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        EmployeesPool.PopulateEmployees(EmployeeLoader);
        PlayerInfo.CurrentEmployees.Add(EmployeesPool.GetEmployee(2));

        // we start with a quarter report
        HiringUI.SetActive(false);
        QuarterReportUI.SetActive(true);

        var QRView = QuarterReportUI.GetComponent<QuarterReportView>();
        QRView.Year = CurrentYear;
        QRView.Quarter = CurrentQuarter;
        QRView.CompanyName = PlayerInfo.CompanyName;
        QRView.CurrentResults = new QuarterResults();
        QRView.CurrentResults.NewBudget = PlayerInfo.Budget;
        QRView.CurrentResults.PreviousBudget = PlayerInfo.Budget+150; // start at a loss of 150K
        QRView.CurrentResults.NewBugCount = PlayerInfo.BugCount;
        QRView.UpdateView();
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
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
