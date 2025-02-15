using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject enemyPrefab;
    private GameObject[] enemy;
    private float randHeight;

    private float randX;
    private float randZ;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 5; i++)
        {
            if (enemy[i] != null) return;
            else 
            {enemy[i] = Instantiate(enemyPrefab) as GameObject;
            randX = Random.Range(-24.0f, 24.0f);
            randZ = Random.Range(-24.0f, 24.0f);
            enemy[i].transform.position = new Vector3(randX, 5, randZ);
            randHeight = Random.Range(3.0f, 5.0f);
            enemy[i].transform.localScale = new Vector3(2, randHeight, 2);
            float angle = Random.Range(0, 360);
            enemy[i].transform.Rotate(0, angle, 0);
            }

        }
    }
    void Start()
    {
        GameObject player1 = Instantiate(playerPrefab, new Vector3(-2, 5, 0), Quaternion.identity);
        player1.GetComponent<PlayerController>().playerID = 1;
        GameObject player2 = Instantiate(playerPrefab, new Vector3(2, 5, 0), Quaternion.identity);
        player2.GetComponent<PlayerController>().playerID = 2;

        enemy = new GameObject[5];
        for (int i = 0; i < 5; i++)
        {
            enemy[i] = Instantiate(enemyPrefab) as GameObject;
            randX = Random.Range(-24.0f, 24.0f);
            randZ = Random.Range(-24.0f, 24.0f);
            enemy[i].transform.position = new Vector3(randX, 5, randZ);
            randHeight = Random.Range(3.0f, 5.0f);
            enemy[i].transform.localScale = new Vector3(2, randHeight, 2);
            float angle = Random.Range(0, 360);
            enemy[i].transform.Rotate(0, angle, 0);
        }
    }
}
