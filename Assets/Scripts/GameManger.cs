using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// GAME MANAGER SINGLETON
public class GameManger : MonoBehaviour
{
    private GameManger() {
        CurrentYear = 2023;
        CurrentQuarter = 2;
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

   private void Awake()
    {
        if (Instance == null)
            _instance = this;
        else if (Instance != this)
            Destroy(gameObject.GetComponent(Instance.GetType()));
        DontDestroyOnLoad(gameObject);
    }
}
