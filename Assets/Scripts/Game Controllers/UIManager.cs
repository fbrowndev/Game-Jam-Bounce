using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Handling all UI Buttons
/// </summary>
public class UIManager : MonoBehaviour
{
    #region UI Varialbes
    GameObject gameOverScreen;

    GameController gameController;

    #endregion



    // Start is called before the first frame update
    void Start()
    {
        //gaining access to the game controller
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        //gaining access to the gaveOverScreen in the canvas
        gameOverScreen = GameObject.Find("Canvas").transform.GetChild(1).gameObject;
        gameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        GameOverDisplay();
    }

    #region UI Methods
    public void GameOverDisplay()
    {
        if(gameController.isGameOver == true)
        {
            gameOverScreen.SetActive(true);
        }
    }


    #endregion

    #region Scene Management Methods
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenuLoad()
    {
        SceneManager.LoadScene(0);
    }

    #endregion
}
