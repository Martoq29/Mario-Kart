using UnityEngine;

public class KartDrift : MonoBehaviour
{
    [SerializeField]
    private string driftInput;
    public float driftFactor = 2f;
    private float normalTurnSpeed;
    public float turnSpeed = 50f;
    private float currentTurnSpeed;

    void Start()
    {
        normalTurnSpeed = turnSpeed;
        currentTurnSpeed = normalTurnSpeed;
    }

    void Update()
    {
        if (Input.GetButtonDown(driftInput))
        {
            currentTurnSpeed = turnSpeed * driftFactor;
        }
        else
        {
            currentTurnSpeed = normalTurnSpeed;
        }
    }

    public float GetTurnSpeed()
    {
        return currentTurnSpeed;
    }
}
