using UnityEngine;
using System.Collections;

public class BoostZone : MonoBehaviour
{
    public float boostMultiplier = 1.5f;  // Multiplicateur de vitesse
    public float boostDuration = 3f;      // Durée du boost

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Vérifie si c'est le joueur
        {
            KartController kart = other.GetComponent<KartController>();
            if (kart != null)
            {
                StartCoroutine(ApplyBoost(kart));
            }
        }
    }

    private IEnumerator ApplyBoost(KartController kart)
    {
        float originalMaxSpeed = kart.maxSpeed; // Stocke la vitesse de base
        kart.maxSpeed *= boostMultiplier; // Augmente la vitesse

        yield return new WaitForSeconds(boostDuration); // Attends la durée du boost

        kart.maxSpeed = originalMaxSpeed; // Rétablit la vitesse
    }
}
