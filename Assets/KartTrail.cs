using UnityEngine;

public class KartTrail : MonoBehaviour
{
    public GameObject trailPrefab;
    public float spawnInterval = 0.1f;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnTrail();
            timer = 0f;
        }
    }

    void SpawnTrail()
    {
        Vector3 spawnPosition = transform.position - transform.forward * 1f;
        Quaternion spawnRotation = Quaternion.identity;

        GameObject trail = Instantiate(trailPrefab, spawnPosition, spawnRotation);
        Destroy(trail, 1f);
    }
}
