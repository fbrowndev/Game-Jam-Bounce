using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Basic Controls for Play Character
/// </summary>
public class PlayerController : MonoBehaviour
{
    #region Player Variables
    Rigidbody2D rb;
    SpriteRenderer sr;

    GameController gameController;

    [Header("Bounce Power")]
    [SerializeField] float bounceForce = 1f;
    [SerializeField] float moveSpeed = 1f;

    [Header("Player Colors")]
    [SerializeField] Color[] color;
    //container for all the tags
    string[] colorHolder = { "Red", "Green", "Blue", "Yellow" };

    bool isGrounded = true;

    int playerPoints = 2;
    int playerLivesRemaining = 3;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        ColorSwitcher();

        //Gaining access to the script
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerBounce();
        BasicMovement();
        GameOverChecker();
    }


    #region Player Movement Methods
    void PlayerBounce()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    void BasicMovement()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        Vector2 Movement = Vector2.right * horizontalMovement * moveSpeed;

        transform.Translate(Movement * Time.deltaTime);
    }

    #endregion

    #region Collision Handlers
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Checking if the collision tag and color match
        if (collision.gameObject.tag == "Red" && sr.color == color[1])
        {
            gameController.AddScore(playerPoints);
            Debug.Log("Working");
        }
        else if (collision.gameObject.tag == "Blue" && sr.color == color[0])
        {
            gameController.AddScore(playerPoints);
            Debug.Log("Working");
        }
        else if (collision.gameObject.tag == "Green" && sr.color == color[2])
        {
            gameController.AddScore(playerPoints);
            Debug.Log("Working");
        }
        else if (collision.gameObject.tag == "Yellow" && sr.color == color[3])
        {
            gameController.AddScore(playerPoints);
            Debug.Log("Working");
        }
        else
        {
            playerLivesRemaining -= 1;
            Debug.Log(playerLivesRemaining + "Lives Remaining");
        }
    }


    void OnTriggerExit2D(Collider2D collision)
    {
        //Doing a color check
        for (int i = 0; i < colorHolder.Length; i++)
        {
            if (collision.gameObject.tag == colorHolder[i])
            {
                ColorSwitcher();
            }
        }
    }

    #endregion

    #region Color Mechanics
    /// <summary>
    /// Color switcher will be handled from collision handlers
    /// </summary>
    void ColorSwitcher()
    {
        int RandomColor = Random.Range(0, color.Length);

        sr.color = color[RandomColor];
    }

    #endregion

    #region Game Mechanics
    void GameOverChecker()
    {
        if(playerLivesRemaining <= 0)
        {
            gameController.GameOver();
        }
    }

    #endregion
}
