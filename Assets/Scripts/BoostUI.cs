using UnityEngine;
using UnityEngine.UI;

public class BoostUI : MonoBehaviour
{
    public GameObject mushroomUI;  // Référence à l'objet entier pour le boost (champignon)
    public GameObject bananaUI;   // Référence à l'objet entier pour la banane
    private KartController kart;

    void Start()
    {
        kart = FindObjectOfType<KartController>();
        mushroomUI.SetActive(false);  // Désactive l'UI de boost (champignon) au début
        bananaUI.SetActive(false);   // Désactive l'UI de banane au début
    }

    void Update()
    {
        if (kart != null)
        {
            // Active/désactive l'UI de boost (champignon) en fonction de si le kart a un boost
            mushroomUI.SetActive(kart.HasBoost());

            // Active/désactive l'UI de banane en fonction de si le kart a une banane
            bananaUI.SetActive(kart.HasBanana());
        }
    }
}
