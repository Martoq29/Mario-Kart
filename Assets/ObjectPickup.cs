using UnityEngine;

public class ObjectPickup : MonoBehaviour
{
    public string itemType;  // Type d'objet à ramasser (par exemple "Mushroom", "Shell", "Banana", "Boost")

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Si le joueur entre en collision avec l'objet, ramasser l'objet
            other.GetComponent<ObjectManager>().PickUpItem(itemType);

            // Détruire l'objet après avoir été ramassé
            Destroy(gameObject);
        }
    }
}
