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
                Destroy(gameObject); // D�truit l'objet de r�cup�ration apr�s que le joueur l'ait r�cup�r�
            }
        }
    }
}
