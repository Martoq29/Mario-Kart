using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text inventoryText;  // Text UI pour afficher les objets
    public ObjectManager objectManager;

    void Update()
    {
        UpdateInventoryUI();
    }

    // Met � jour l'interface pour afficher l'inventaire
    void UpdateInventoryUI()
    {
        inventoryText.text = "Objets: ";
        foreach (string item in objectManager.inventory)
        {
            inventoryText.text += item + " ";
        }
    }
}
