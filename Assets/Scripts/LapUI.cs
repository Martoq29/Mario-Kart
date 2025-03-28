using UnityEngine;
using UnityEngine.UI;

public class LapUI : MonoBehaviour
{
    public Text lapText;
    public LapManager lapManager;
    public GameObject player;

    void Update()
    {
        if (lapManager != null && player != null)
        {
            int currentLap = lapManager.GetPlayerLap(player);
            int totalLaps = lapManager.totalLaps;
            lapText.text = "Tour : " + currentLap + " / " + totalLaps;
        }
    }
}
