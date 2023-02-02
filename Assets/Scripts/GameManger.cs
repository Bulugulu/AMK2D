using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// GAME MANAGER SINGLETON
public class GameManger : MonoBehaviour
{
    private const int DEFAULT_YEAR = 1980;
    private const int DEFAULT_QUARTER = 2;

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
