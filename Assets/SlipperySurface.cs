using UnityEngine;

public class SlipperySurface : MonoBehaviour
{
    public PhysicsMaterial slipperyMaterial;  // Le mat�riau glissant � appliquer
    public string slipperyTag = "SlipperySurface";  // Le tag � appliquer aux objets glissants

    private void OnCollisionEnter(Collision collision)
    {
        // Appliquer le mat�riau glissant quand un objet entre en collision avec le sol
        if (collision.collider.CompareTag(slipperyTag))
        {
            Collider collider = collision.collider;
            // Appliquer le mat�riau glissant au collider du kart
            collider.material = slipperyMaterial;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // R�initialiser le mat�riau au sortir de la surface glissante
        if (collision.collider.CompareTag(slipperyTag))
        {
            Collider collider = collision.collider;
            // R�initialise la friction du kart � la valeur par d�faut
            collider.material = null;  // Ou un autre mat�riau de friction normal
        }
    }
}
