using UnityEngine;

public class BananaItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            KartController kart = other.GetComponent<KartController>();
            if (kart != null)
            {
                kart.SpinOut(); // Fait tourner le kart sur lui-m�me
            }
            Destroy(gameObject); // D�truit la banane apr�s qu'elle ait fait son effet
        }
    }

    public void ActivateBanana()
    {
        // Tu peux ajouter des effets visuels ici si tu veux que la banane soit visible avant d'�tre d�clench�e.
        transform.localScale = new Vector3(0.5f, 0.2f, 0.5f);
    }
}
