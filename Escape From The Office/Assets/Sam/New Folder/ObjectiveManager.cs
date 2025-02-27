using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectiveManager : MonoBehaviour
{
    public List<Objective> objectives = new List<Objective>();
    public TextMeshProUGUI objectiveText; // Reference to the HUD Text UI

    void Start()
    {
        // Start with some initial objectives
        AddObjective("Explore the area.");
    }

    public void AddObjective(string description)
    {
        // Check if the objective already exists to avoid duplicates
        if (!objectives.Exists(obj => obj.description == description))
        {
            Objective newObjective = new Objective();
            newObjective.description = description;
            newObjective.ActivateObjective();
            objectives.Add(newObjective);
            UpdateObjectiveDisplay();
        }
    }

    public void CompleteObjective(string description)
    {
        Objective objective = objectives.Find(obj => obj.description == description);
        if (objective != null && !objective.isComplete)
        {
            objective.CompleteObjective();
            UpdateObjectiveDisplay();
        }
    }

    public void UpdateObjectiveDisplay()
    {
        string objectivesDisplay = "";
        foreach (Objective obj in objectives)
        {
            if (obj.isActive)
            {
                objectivesDisplay += obj.description + "\n";
            }
        }

        objectiveText.text = objectivesDisplay; // Update the UI
    }

    public void RemoveObjective(string description)
    {
        Objective objective = objectives.Find(obj => obj.description == description);
        if (objective != null)
        {
            objectives.Remove(objective);
            UpdateObjectiveDisplay();
        }
    }
}
