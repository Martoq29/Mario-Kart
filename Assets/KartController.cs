using UnityEngine;

public class KartController : MonoBehaviour
{
    public float acceleration = 10f;
    public float steering = 50f;
    public float braking = 20f;
    public float maxSpeed = 20f;
    public float decelerationRate = 2f;
    public float driftFactor = 1.5f;  // Facteur de drift qui contrôle l'intensité du dérapage
    public float driftSteering = 1.2f;  // Facteur de rotation pendant le drift
    public float driftTime = 0.5f;  // Durée du drift

    private float currentSpeed = 0f;
    private float turnInput;
    private float accelerationInput;
    private float brakeInput;

    private bool isDrifting = false;
    private float driftDuration = 0f;

    void Update()
    {
        // Récupère l'input du joueur pour la direction et l'accélération
        turnInput = Input.GetAxis("Horizontal");  // A et D ou Flèches gauche/droite
        accelerationInput = Input.GetAxis("Vertical");  // W et S ou Flèches haut/basa
        brakeInput = (accelerationInput < 0) ? 1f : 0f; // Freinage si on recule

        // Si la touche Shift est enfoncée, activer le drift
        if (Input.GetKey(KeyCode.LeftShift) && currentSpeed > 0.5f)
        {
            isDrifting = true;
            driftDuration = driftTime;
        }
        else
        {
            // Sinon, on désactive le drift après un certain temps
            if (driftDuration > 0)
            {
                driftDuration -= Time.deltaTime;
            }
            else
            {
                isDrifting = false;
            }
        }

        // Applique l'accélération ou le freinage
        if (accelerationInput > 0)
        {
            currentSpeed += acceleration * Time.deltaTime;
        }
        else if (brakeInput > 0)
        {
            currentSpeed -= braking * Time.deltaTime;
        }
        else
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, decelerationRate * Time.deltaTime);
        }

        // Limite la vitesse
        currentSpeed = Mathf.Clamp(currentSpeed, 0f, maxSpeed);

        // Si le joueur est en drift, modifie la rotation et applique un effet de drift
        if (isDrifting)
        {
            // Rotation augmentée pendant le drift
            float turn = turnInput * steering * Time.deltaTime * driftSteering;
            transform.Rotate(0f, turn, 0f);

            // Applique une accélération latérale pour le drift
            currentSpeed = Mathf.Clamp(currentSpeed - driftFactor * Time.deltaTime, 0f, maxSpeed);
        }
        else
        {
            // Rotation normale lorsque le joueur n'est pas en drift
            float turn = turnInput * steering * Time.deltaTime;
            transform.Rotate(0f, turn, 0f);
        }

        // Applique le mouvement en avant
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
    }
}
