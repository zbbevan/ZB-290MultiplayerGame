using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player1Prefab;
    [SerializeField] private GameObject player2Prefab;
    [SerializeField] private GameObject enemyPrefab;

    public GameObject[] players;
    private GameObject[] enemy;
    private float randHeight;
    private FlagSpawner flagSpawner;
    public GameObject flag;

    private int playerToAdd;

    private UI_Manager uI_Manager;

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
            enemy[i].transform.position = new Vector3(randX, 3, randZ);
            randHeight = Random.Range(3.0f, 5.0f);
            enemy[i].transform.localScale = new Vector3(2, randHeight, 2);
            float angle = Random.Range(0, 360);
            enemy[i].transform.Rotate(0, angle, 0);
            }

        }




    }
    void Start()
    {
        uI_Manager = GameObject.Find("UI_Manager").GetComponent<UI_Manager>();
        flagSpawner = GetComponent<FlagSpawner>();
        flag = flagSpawner.flag;
        players = new GameObject[2];

        GameObject player1 = Instantiate(player1Prefab, new Vector3(-2, 3, 0), Quaternion.identity);
        player1.GetComponent<PlayerController>().playerID = 1;
        GameObject player2 = Instantiate(player2Prefab, new Vector3(2, 3, 0), Quaternion.identity);
        player2.GetComponent<PlayerController>().playerID = 2;

        players[0] = player1;
        players[1] = player2;


        enemy = new GameObject[5];
        for (int i = 0; i < 5; i++)
        {
            enemy[i] = Instantiate(enemyPrefab) as GameObject;
            randX = Random.Range(-24.0f, 24.0f);
            randZ = Random.Range(-24.0f, 24.0f);
            enemy[i].transform.position = new Vector3(randX, 3, randZ);
            randHeight = Random.Range(3.0f, 5.0f);
            enemy[i].transform.localScale = new Vector3(2, randHeight, 2);
            float angle = Random.Range(0, 360);
            enemy[i].transform.Rotate(0, angle, 0);
        }

    }


    public IEnumerator GainPoints()
    {
        if (flag.gameObject.GetComponent<Flag>().myHolder != null)
        {
            playerToAdd = flag.gameObject.GetComponent<Flag>().myHolder.GetComponent<PlayerController>().playerID;
            uI_Manager.AddPoints(1, playerToAdd);
        }
        yield return new WaitForSeconds(2); 
        StartCoroutine(GainPoints());

    }


}
