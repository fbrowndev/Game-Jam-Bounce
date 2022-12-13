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

    [Header("Bounce Power")]
    [SerializeField] float bounceForce = 1f;

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerBounce();
    }


    #region Player Movement Methods
    void PlayerBounce()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
        }
    }

    #endregion
}
