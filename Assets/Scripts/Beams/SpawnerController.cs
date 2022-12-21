using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles spawning
/// </summary>
public class SpawnerController : MonoBehaviour
{
    #region Spawn Variables
    [Header("Spawnable Objects")]
    [SerializeField] GameObject[] beams;

    [Header("Spawn Settings")]
    [SerializeField] float spawnTime = 2f;
    [SerializeField] float spawnSpeed = 3f;

    //Starting location
    [SerializeField] Vector2 spawnPosition = new Vector2(20, 0);

    //accessing script
    GameController gameController;

    #endregion



    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();

        InvokeRepeating("BeamSpawn", spawnTime, spawnSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Spawn Methods
    void BeamSpawn()
    {
        if(gameController.isGameOver == false)
        {
            int RandomBeam = Random.Range(0, beams.Length);

            Instantiate(beams[RandomBeam], spawnPosition, Quaternion.identity);
        } 
    }


    #endregion
}
