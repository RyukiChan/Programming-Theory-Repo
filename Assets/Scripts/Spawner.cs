using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemy;
    private float spawnxBoundary = 6;
    private GameManager gameManagerScript;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        StartCoroutine(Interval());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Interval()
    {

        float intervalTime = 1;  // start with 5 seconds
        while (true)   // endless loop
        {
            yield return new WaitForSeconds(intervalTime);

            // this is first done 5 seconds after start.
            // move it before yield return to start the action immediately
            //print(Time.time);
            if (gameManagerScript.gameRunning)
            {

                int enemyIndex = RandomEnemy();
                if (enemy[enemyIndex].CompareTag("powerup") && GameObject.FindGameObjectsWithTag("powerup").Length > 0)
                {
                    //Debug.Log("Already a powerup in the game");
                }
                else if (enemy[enemyIndex].CompareTag("powerup") && playerControllerScript.hasPowerUp == true)
                {
                    //Debug.Log("Already have a powerup enabled");
                }

                else
                {
                Instantiate(enemy[enemyIndex], RandomSpawnPos(), enemy[enemyIndex].transform.rotation);
                // change interval
                intervalTime = intervalTime - .001f;
                //Debug.Log(intervalTime);
                }

               
            }



        }


    }



    //Generate random X position to Spawn Enemy
    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-spawnxBoundary, spawnxBoundary), 7, -1);
    }

    private int RandomEnemy()
    {
        return Random.Range(0, enemy.Length);
    }
}
