using System.Collections;
using UnityEngine;

public class KartController : MonoBehaviour
{
    public int playerIndex = 0; // Indice du joueur (0 pour le premier, 1 pour le deuxième, etc.)

    //mapping
    [SerializeField]
    private string AccelerateInput, TurnInput, FireInput, driftInput;

    public GameObject mushroomUI;
    public GameObject bananaUI;
    private bool hasBoost = false;
    private bool hasBanana = false;
    private bool isBoosting = false;

    public float acceleration = 10f;
    public float steering = 50f;
    public float braking = 20f;
    public float maxSpeed = 20f;
    public float decelerationRate = 2f;
    public float driftFactor = 1.5f;
    public float driftSteering = 1.2f;
    public float driftTime = 0.5f;

    public float boostForce = 30f;
    public float boostDuration = 2f;
    public float spinOutDuration = 1f;

    private float currentSpeed = 0f;
    private float turnInput;
    private float accelerationInput;
    private float brakeInput;
    private bool isDrifting = false;
    private float driftDuration = 0f;

    private bool isSpinningOut = false;
    private float spinOutTime = 0f;

    public float spinOutRotationSpeed = 100f;

    public GameObject bananaPrefab;

    private float speedModifier = 1f;  // Vitesse modifiée lorsqu'on roule sur de l'herbe

    void Update()
    {
        // Utilisation de GetAxisRaw pour une meilleure réactivité des entrées
        turnInput = Input.GetAxisRaw(TurnInput);
        accelerationInput = Input.GetAxisRaw(AccelerateInput);
        brakeInput = (accelerationInput < 0) ? 1f : 0f;

        if (Input.GetButtonDown(driftInput) && currentSpeed > 0.5f)
        {
            isDrifting = true;
            driftDuration = driftTime;
        }
        else
        {
            if (driftDuration > 0)
            {
                driftDuration -= Time.deltaTime;
            }
            else
            {
                isDrifting = false;
            }
        }

        // Appliquer l'accélération en tenant compte du modificateur de vitesse
        if (accelerationInput > 0 && !isBoosting)
        {
            currentSpeed += acceleration * Time.deltaTime * speedModifier;  // Vitesse modifiée par le terrain
        }
        else if (brakeInput > 0)
        {
            currentSpeed -= braking * Time.deltaTime;
        }
        else if (!isBoosting)
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, decelerationRate * Time.deltaTime);
        }

        // Appliquer le boost et la banane selon les entrées
        if (hasBoost && Input.GetButtonDown(FireInput))
        {
            StartCoroutine(UseBoost());
        }

        if (hasBanana && Input.GetButtonDown(FireInput))
        {
            DropBanana();
        }

        if (!isBoosting && !isSpinningOut)
        {
            currentSpeed = Mathf.Clamp(currentSpeed, 0f, maxSpeed);
        }

        if (isDrifting)
        {
            float turn = turnInput * steering * Time.deltaTime * driftSteering;
            transform.Rotate(0f, turn, 0f);
            currentSpeed = Mathf.Clamp(currentSpeed - driftFactor * Time.deltaTime, 0f, maxSpeed);
        }
        else
        {
            float turn = turnInput * steering * Time.deltaTime;
            transform.Rotate(0f, turn, 0f);
        }

        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);

        // Gérer le spin-out si le kart est en état de spin-out
        if (isSpinningOut)
        {
            spinOutTime -= Time.deltaTime;
            if (spinOutTime <= 0)
            {
                isSpinningOut = false;
            }
            else
            {
                transform.Rotate(0f, spinOutRotationSpeed * Time.deltaTime, 0f);  // Rotation sur l'axe Y
            }
        }
    }

    public void GainBoost()
    {
        hasBoost = true;
    }

    public void GainBanana()
    {
        hasBanana = true;
        bananaUI.SetActive(true);
    }

    public void DropBanana()
    {
        if (hasBanana)
        {
            hasBanana = false;
            bananaUI.SetActive(false);
            Vector3 dropPosition = transform.position - transform.forward * 2f;
            dropPosition.y = transform.position.y;
            GameObject banana = Instantiate(bananaPrefab, dropPosition, Quaternion.identity);
            banana.GetComponent<BananaItem>().ActivateBanana();
        }
    }

    public bool HasBoost()
    {
        return hasBoost;
    }

    private IEnumerator UseBoost()
    {
        hasBoost = false;
        isBoosting = true;
        float startTime = Time.time;

        while (Time.time < startTime + boostDuration)
        {
            currentSpeed = boostForce;
            yield return null;
        }

        isBoosting = false;
    }

    public bool HasBanana()
    {
        return hasBanana;
    }

    public void SpinOut()
    {
        isSpinningOut = true;
        spinOutTime = spinOutDuration;
        currentSpeed = 0f;
    }

    // Méthode pour changer la vitesse en fonction du terrain (herbe ou normal)
    public void SetSpeedModifier(float modifier)
    {
        speedModifier = modifier;  // Modifie le multiplicateur de vitesse (par exemple, 0.5 pour ralentir)
    }
}