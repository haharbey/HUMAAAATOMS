using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
    public List<string> tasks = new List<string> { "Move to Point A", "Move to Point B", "Move to Point C" };
    public GameObject checklistUI; // Assign the Checklist UI Panel
    private int currentTask = 0;

    void Start()
    {
        UpdateChecklist();
    }

    public void CompleteTask()
    {
        if (currentTask < tasks.Count)
        {
            // Mark task as completed
            checklistUI.transform.GetChild(currentTask).GetComponent<Text>().text = "✔ " + tasks[currentTask];

            currentTask++; // Move to next task
            UpdateChecklist();
        }
    }

    void UpdateChecklist()
    {
        for (int i = 0; i < checklistUI.transform.childCount; i++)
        {
            Text taskText = checklistUI.transform.GetChild(i).GetComponent<Text>();
            taskText.text = (i < currentTask) ? "✔ " + tasks[i] : "• " + tasks[i]; // Mark completed with ✔
        }
    }
}
