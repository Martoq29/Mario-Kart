using UnityEngine;

public class ItemCube : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // V�rifie si c'est bien le joueur
        {
            KartController kart = other.GetComponent<KartController>();
            if (kart != null)
            {
                kart.GainBoost(); // Donne un champignon au joueur
                Destroy(gameObject); // Supprime l'objet apr�s utilisation
            }
        }
    }
}
