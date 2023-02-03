using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.IO;

public class EmployeeLoaderV2 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private TextAsset JSON;

    [Serializable]
    public class EmployeeList
    {
        public Employee[] employee;
    }

    public EmployeeList myEmployeeList = new EmployeeList();

    void Start()
    {
        myEmployeeList = JsonUtility.FromJson<EmployeeList>(JSON.text);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
