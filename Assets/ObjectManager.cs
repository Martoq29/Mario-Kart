using UnityEngine;
using System.Collections.Generic;

public class ObjectManager : MonoBehaviour
{
    public List<string> inventory = new List<string>();  // Liste d'objets que le joueur a ramassés
    public int maxItems = 3;  // Limite du nombre d'objets que le joueur peut avoir à la fois

    public float currentSpeed = 10f;  // Vitesse actuelle du kart
    public float boostSpeed = 30f;    // Vitesse du kart pendant le boost
    public float boostDuration = 3f;  // Durée du boost
    private bool isBoosting = false;  // Indicateur si le boost est actif

    void Update()
    {
        // Utilisation de l'objet en appuyant sur la touche E
        if (Input.GetKeyDown(KeyCode.E) && inventory.Contains("Boost") && !isBoosting)
        {
            UseBoost();
        }

        // Si le boost est activé, décrémenter le temps restant
        if (isBoosting)
        {
            boostDuration -= Time.deltaTime;
            if (boostDuration <= 0)
            {
                StopBoost();
            }
        }

        // Applique le mouvement du kart
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
    }

    // Fonction pour ramasser un objet
    public void PickUpItem(string item)
    {
        if (inventory.Count < maxItems)
        {
            inventory.Add(item);
            Debug.Log("Objet ramassé : " + item);
        }
        else
        {
            Debug.Log("Inventaire plein !");
        }
    }

    // Fonction pour utiliser le boost
    void UseBoost()
    {
        isBoosting = true;
        currentSpeed = boostSpeed;  // Augmenter la vitesse du kart
        Debug.Log("Boost activé !");
        inventory.Remove("Boost");  // Retirer l'objet Boost de l'inventaire
    }

    // Fonction pour désactiver le boost
    void StopBoost()
    {
        isBoosting = false;
        currentSpeed = 10f;  // Revenir à la vitesse normale
        Debug.Log("Boost désactivé !");
    }
}
