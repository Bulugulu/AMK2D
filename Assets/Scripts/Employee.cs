using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// T Serializable makes this class able to be serialized, for use in Json. Uses the "System" assembly.
[Serializable] 
public class Employee : UnityEngine.Object
{
    public string Name;
    public string AvatarPath;
    public int ExpectedSalary; // K USD
    public int CodeRate; // K Lines per Q
    public int ExperienceYears;
    public int BugFixRate; // per Q
    public int BugCreationRate; // Per 10K code lines
    public ConscientiousnessRating Conscientiousness;
    public OpennessRating Openness;
}

[Serializable]
public enum ConscientiousnessRating {
    Low = 0,
    Medium = 1,
    High = 2
}

[Serializable]
public enum OpennessRating {
    Low = 0,
    Medium = 1,
    High = 2
}