using System.Collections.Generic;
using UnityEngine;

public class LapManager : MonoBehaviour
{
    public int totalLaps = 3;
    private Dictionary<GameObject, int> playerLaps = new Dictionary<GameObject, int>();
    private Dictionary<GameObject, int> playerCheckpointIndex = new Dictionary<GameObject, int>();

    public List<Transform> checkpoints; // Liste des checkpoints (ordre logique du circuit)

    void Start()
    {
        // Initialisation des joueurs
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            playerLaps[player] = 0;
            playerCheckpointIndex[player] = 0;
        }
    }

    public void CheckpointReached(GameObject player, Transform checkpoint)
    {
        if (!playerLaps.ContainsKey(player)) return;

        int currentIndex = playerCheckpointIndex[player];
        int checkpointIndex = checkpoints.IndexOf(checkpoint);

        if (checkpointIndex == -1) return; // Sécurité si le checkpoint n'existe pas

        // Vérifie si le joueur touche bien le checkpoint suivant dans l'ordre
        if (checkpointIndex == (currentIndex + 1) % checkpoints.Count)
        {
            playerCheckpointIndex[player] = checkpointIndex;

            // Si c'est le premier checkpoint et que le joueur a touché tous les autres avant, on valide un tour
            if (checkpointIndex == 0 && currentIndex == checkpoints.Count - 1)
            {
                playerLaps[player]++;

                if (playerLaps[player] >= totalLaps)
                {
                    Debug.Log(player.name + " a fini la course !");
                }
                else
                {
                    Debug.Log(player.name + " a complété un tour !");
                }
            }
        }
    }

    public int GetPlayerLap(GameObject player)
    {
        return playerLaps.ContainsKey(player) ? playerLaps[player] : 0;
    }
}
