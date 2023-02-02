using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// YOU CAN TEST SHIT HERE.
public class Playground : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var pool = new EmployeePool();
        var twoEmps = pool.GetEmployees(2);
        var threeEmps = pool.GetEmployees(3);
        var fiveEmps = pool.GetEmployees(5);

        Debug.Log($"Two employees named: {twoEmps[0].Name}, {twoEmps[1].Name}");
        Debug.Log($"Three employees named: {threeEmps[0].Name}, {threeEmps[1].Name}, {threeEmps[2].Name}");
        Debug.Log($"Five employees named: {fiveEmps[0].Name}, {fiveEmps[1].Name}, {fiveEmps[2].Name}, {fiveEmps[3].Name}, {fiveEmps[4].Name}");

        Debug.Log($"Current Time: {GameManger.Instance.CurrentTimeString}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
