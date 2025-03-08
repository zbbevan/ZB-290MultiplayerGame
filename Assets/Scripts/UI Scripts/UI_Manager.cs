using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private TMP_Text[] playerScoreText;
    [SerializeField] private int[] playerScores;

    [SerializeField] private int winScore = 20;

    [SerializeField] private GameObject gameOverText;
    [SerializeField] private GameObject quitButton;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < playerScoreText.Length; i++)
        {
            playerScores[i] = 0;
            playerScoreText[i].text ="P"+ (i+1) + " Score: " + playerScores[i].ToString();
        }


    }

    public void AddPoints(int points, int playerID)
    {

        playerScores[playerID - 1] += points;
        if (playerScores[playerID - 1] < 0)
        {
            playerScores[playerID - 1] = 0;
        }
        playerScoreText[playerID - 1].text ="P"+ (playerID) + "Score: " + playerScores[playerID - 1].ToString();
    }
  


   private void Update()
   {
    for (int i = 0; i < playerScoreText.Length; i++)
    {
        if (playerScores[i] >= winScore)
        {
            gameOverText.SetActive(true);
            quitButton.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            gameOverText.GetComponent<TMP_Text>().text = "Player " + (i + 1) + " Wins!";
            playerScoreText[i].text = "P" + (i + 1) + " Score: " + playerScores[i].ToString();
            playerScoreText[i].color = Color.green;
        }
    }


    for (int i = 0; i < playerScores.Length; i++)
    {
        if (playerScores[i] < 0)
        {
            playerScores[i] = 0;
        }
    }
   }
}
