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

    [Header("Bounce Power")]
    [SerializeField] float bounceForce = 1f;
    [SerializeField] float moveSpeed = 1f;

    [Header("Player Colors")]
    [SerializeField] Color[] color;

    bool isGrounded = true;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerBounce();
        ColorSwitcher();
        BasicMovement();
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

    #endregion

    #region Color Mechanics
    void ColorSwitcher()
    {
        int RandomColor = Random.Range(0, color.Length);

        //Will be added to collision handlers later
        //Added just for testing purposes
        if (Input.GetKeyDown(KeyCode.Q))
        {
            sr.color = color[RandomColor];
        }
    }

    #endregion
}
