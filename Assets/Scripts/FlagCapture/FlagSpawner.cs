using UnityEngine;

public class FlagSpawner : MonoBehaviour
{   [SerializeField] private GameObject flagPrefab;
    [SerializeField] private Transform[] spawnPoints;

    public GameObject flag;

    void Awake()
    {
        SpawnFlag();
    }


    void Update()
    {
        if (flag == null)
        {
            SpawnFlag();
        }
    }

    public void SpawnFlag()
    {
        if (flagPrefab != null && spawnPoints.Length > 0)
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            flag = Instantiate(flagPrefab, spawnPoints[randomIndex].position, Quaternion.identity) as GameObject;
        }
    }
}
