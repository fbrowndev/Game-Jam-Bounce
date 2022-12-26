using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Game Controls and Score System
/// </summary>
public class GameController : MonoBehaviour
{
    #region Game Variables
    int score;
    int livesRemaining;

    [Header("Screen Text")]
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text lifeText;


    [HideInInspector]
    public bool isGameOver;

    PlayerController playerController;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Bounce").GetComponent<PlayerController>();
        livesRemaining = playerController.playerLivesRemaining;

        score = 0;
        scoreText.text = "Score: " + score;
        lifeText.text = "Lives: " + livesRemaining;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(score);
        PlayerLiveCheck();
        
    }


    #region Game Methods
    /// <summary>
    /// Useable method for adding points
    /// </summary>
    /// <param name="points"></param>
    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }

    /// <summary>
    /// GameOver - Turn off all scripts
    /// </summary>
    public void GameOver()
    {
        isGameOver = true;
        Debug.Log("Game is Over");
    }

    void PlayerLiveCheck()
    {
        livesRemaining = playerController.playerLivesRemaining;
        lifeText.text = "Lives: " + livesRemaining;
    }

    #endregion
}
