using UnityEngine;

public class GrassSurfaceController : MonoBehaviour
{
    public float grassSpeedModifier = 0.5f;  // Modificateur de vitesse pour l'herbe

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Vérifie si l'objet est un kart
        {
            KartController kartController = other.GetComponent<KartController>();
            if (kartController != null)
            {
                kartController.SetSpeedModifier(grassSpeedModifier);  // Applique le modificateur de vitesse sur l'herbe
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))  // Vérifie si l'objet est un kart
        {
            KartController kartController = other.GetComponent<KartController>();
            if (kartController != null)
            {
                kartController.SetSpeedModifier(1f);  // Restaure la vitesse normale en quittant l'herbe
            }
        }
    }
}
