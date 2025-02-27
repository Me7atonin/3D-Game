using UnityEngine;

[System.Serializable]
public class Objective
{
    public string description;
    public bool isComplete = false;
    public bool isActive = false;

    public void CompleteObjective()
    {
        isComplete = true;
    }

    public void ActivateObjective()
    {
        isActive = true;
    }
}
