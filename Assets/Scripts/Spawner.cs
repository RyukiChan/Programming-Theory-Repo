using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public float spawnxBoundary = 6;
    private GameManager gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
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
                Instantiate(enemy, RandomSpawnPos(), enemy.transform.rotation);
                // change interval
                intervalTime = intervalTime - .001f;
                //Debug.Log(intervalTime);
            }



        }


    }



    //Generate random X position to Spawn Enemy
    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-spawnxBoundary, spawnxBoundary), 7, -1);
    }
}
