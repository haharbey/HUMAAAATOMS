using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public GameObject panel; // Assign the panel in the Inspector

    public void ClosePanel()
    {
        if (panel != null)
        {
            panel.SetActive(false); // Deactivate the panel
        }
    }
}
