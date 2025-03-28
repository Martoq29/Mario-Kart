using UnityEngine;

public class BananaPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            KartController kart = other.GetComponent<KartController>();
            if (kart != null)
            {
                kart.GainBanana(); // Donne une banane au joueur
                Destroy(gameObject); // Détruit l'objet de récupération après que le joueur l'ait récupéré
            }
        }
    }
}
