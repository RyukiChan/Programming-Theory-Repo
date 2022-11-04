using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public int hitToKill = 1;
    public float speed;
    private Rigidbody enemyRb;
    public Material[] theMaterial;
    private Renderer enemyRend;
    private float destroyBoundary = -5;
    private GameManager gameManagerScript;
    public int hitPoint = 1;
    public int missPoint = -1;
    public ParticleSystem explode;
    public GameObject boom;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        // Move and Spin
        enemyRb.AddForce(Vector3.down * speed,ForceMode.Impulse);
        enemyRb.AddTorque (new Vector3(RandomForce(), RandomForce(), RandomForce()));
        enemyRend = GetComponent<Renderer>();
        enemyRend.material = theMaterial[Random.Range(0,theMaterial.Length)];
                
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < destroyBoundary)
        {
            gameManagerScript.UpdateScore(missPoint);
            Destroy(gameObject);
        }
    }
    // Create Random float between 0 and 1
    private float RandomForce()
    {
        return Random.Range(0f, 2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bullet"))
        {

            Instantiate(boom);
            gameManagerScript.UpdateScore(hitPoint);
            Instantiate(explode,transform.position,transform.rotation);
             Destroy(gameObject);
              Destroy(other.gameObject);
        }



        
        
    }
}
