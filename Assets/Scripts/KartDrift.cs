using UnityEngine;

public class KartDrift : MonoBehaviour
{
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
        if (Input.GetKey(KeyCode.LeftShift))
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
