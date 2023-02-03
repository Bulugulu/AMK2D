using UnityEngine;

public class BigNumbersMachine : MonoBehaviour
{
    public static readonly int REVENUE_MULTI = 2;
    public static readonly int BUG_LOSS_MULTI = 1;
    public static QuarterResults CrunchNumbers(Player player)
    {
        var results = new QuarterResults();
        results.PreviousBudget = player.Budget;

        int newBudget = player.Budget;
        int newBugCount = player.BugCount;

        foreach(Employee emp in player.CurrentEmployees)
        {
            // substract salary from budget
            newBudget -= emp.ExpectedSalary;

            // calculate bug production
            float actualBugCreationRate = emp.BugCreationRate - emp.ExperienceYears / 2;
            actualBugCreationRate = actualBugCreationRate < 0.0f ? 0.0f : actualBugCreationRate;
            float bugs = actualBugCreationRate * emp.CodeRate / 10.0f;
            int bugFixes = emp.BugFixRate + (int) emp.Conscientiousness;

            newBugCount += Mathf.FloorToInt(bugs); // We ignore "partial" bugs, rounded down.
            newBugCount -= bugFixes;

            // code production
            int codeQuality = (int)emp.Openness + emp.ExperienceYears;
            int employeeRevenue = emp.CodeRate * codeQuality * REVENUE_MULTI;

            newBudget += employeeRevenue;
        }

        // Process bugs
        if (newBugCount < 0)
        {
            newBugCount = 0;
        }
        else
        {
            // bugs cause losses
            newBudget -= newBugCount * BUG_LOSS_MULTI;
        }

        results.NewBudget = newBudget;
        results.NewBugCount = newBugCount;

        return results;
    }
}

public class QuarterResults: UnityEngine.Object
{
    public int PreviousBudget;
    public int NewBudget;
    public int NewBugCount;

    public override string ToString()
    {
        return $"Previous Budget:{PreviousBudget}, New Budget: {NewBudget}, Bug Count: {NewBugCount}";
    }
}