using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles movement for the beam
/// </summary>
public class BeamMover : MonoBehaviour
{
    #region Beam Variables
    [Header("Beam Speed")]
    public float beamMoveSpeed = 3f;


    #endregion

    // Update is called once per frame
    void Update()
    {
        BackwardMovement();
        BeamDestroyer();
    }

    #region Movement Methods
    /// <summary>
    /// Basic movement for beams
    /// </summary>
    void BackwardMovement()
    {
        transform.Translate(Vector2.left * beamMoveSpeed * Time.deltaTime);
    }
    #endregion

    #region Destroy Methods
    /// <summary>
    /// Destroy method for Beams
    /// </summary>
    void BeamDestroyer()
    {
        if(transform.position.x <= -20)
        {
            Destroy(gameObject);
        }
    }

    #endregion

}
