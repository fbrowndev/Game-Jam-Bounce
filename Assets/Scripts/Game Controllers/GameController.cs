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

    [Header("Score Text")]
    [SerializeField] TMP_Text scoreText;

    [HideInInspector]
    public bool isGameOver;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(score);
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

    #endregion
}
