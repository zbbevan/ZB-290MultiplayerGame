using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    void Start()
    {
        GameObject player1 = Instantiate(playerPrefab, new Vector3(-2, 5, 0), Quaternion.identity);
        player1.GetComponent<PlayerController>().playerID = 1;
        GameObject player2 = Instantiate(playerPrefab, new Vector3(2, 5, 0), Quaternion.identity);
        player2.GetComponent<PlayerController>().playerID = 2;
    }
}
