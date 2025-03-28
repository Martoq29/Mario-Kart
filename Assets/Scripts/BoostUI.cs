using UnityEngine;
using UnityEngine.UI;

public class BoostUI : MonoBehaviour
{
    public GameObject mushroomUI;  // R�f�rence � l'objet entier pour le boost (champignon)
    public GameObject bananaUI;   // R�f�rence � l'objet entier pour la banane
    private KartController kart;

    void Start()
    {
        kart = FindObjectOfType<KartController>();
        mushroomUI.SetActive(false);  // D�sactive l'UI de boost (champignon) au d�but
        bananaUI.SetActive(false);   // D�sactive l'UI de banane au d�but
    }

    void Update()
    {
        if (kart != null)
        {
            // Active/d�sactive l'UI de boost (champignon) en fonction de si le kart a un boost
            mushroomUI.SetActive(kart.HasBoost());

            // Active/d�sactive l'UI de banane en fonction de si le kart a une banane
            bananaUI.SetActive(kart.HasBanana());
        }
    }
}
