using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private LapManager lapManager;

    void Start()
    {
        lapManager = FindObjectOfType<LapManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lapManager.CheckpointReached(other.gameObject, transform);
        }
    }
}
