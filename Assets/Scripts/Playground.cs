using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// YOU CAN TEST SHIT HERE.
public class Playground : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var player = new Player();
        var pool = new EmployeePool();
        var twoEmps = pool.GetEmployees(2);
        var threeEmps = pool.GetEmployees(3);
        var fiveEmps = pool.GetEmployees(5);

        Debug.Log($"Two employees named: {twoEmps[0].Name}, {twoEmps[1].Name}");
        Debug.Log($"Three employees named: {threeEmps[0].Name}, {threeEmps[1].Name}, {threeEmps[2].Name}");
        Debug.Log($"Five employees named: {fiveEmps[0].Name}, {fiveEmps[1].Name}, {fiveEmps[2].Name}, {fiveEmps[3].Name}, {fiveEmps[4].Name}");

        Debug.Log($"Current Time: {GameManger.Instance.CurrentTimeString}");
        Debug.Log($"Next Turn!: {GameManger.Instance.NextTurn()}");
        Debug.Log($"Next Turn!: {GameManger.Instance.NextTurn()}");
        Debug.Log($"Next Turn!: {GameManger.Instance.NextTurn()}");
        Debug.Log($"Next Turn!: {GameManger.Instance.NextTurn()}");
        Debug.Log($"Next Turn!: {GameManger.Instance.NextTurn()}");

        player.HireEmployee(twoEmps[0]);
        player.HireEmployee(twoEmps[1]);
        Debug.Log($"Hired two employees named: {player.CurrentEmployees[0].Name}, {player.CurrentEmployees[1].Name}");
        player.FireEmployee(player.CurrentEmployees[0]);
        Debug.Log($"Fired someone. Now we have: {player.CurrentEmployees[0].Name}");
        player.FireEmployee(player.CurrentEmployees[0]);
        Debug.Log($"Fired everyone.");
        player.HireEmployee(pool.GetSampleEmployee());
        Debug.Log($"Hired sample employee. Now we have: {player.CurrentEmployees[0].Name}");
        
        var qResult = BigNumbersMachine.CrunchNumbers(player);
        Debug.Log($"Your quarterly report - {qResult}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
