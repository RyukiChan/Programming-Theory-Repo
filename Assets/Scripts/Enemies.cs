using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    //Variables - Declarations
    private Rigidbody enemyRb;
    public Material[] theMaterial;
    private Renderer enemyRend;
    private float destroyBoundary = -5;
    private GameManager gameManagerScript;

    private int protected_hitPoint = 1;
    public int hitPoint
    {
        get { return protected_hitPoint; }
        set {

            if (value < 0.0f)
            {
                Debug.Log("Negative value for a kill? I don't think so");
            }
            else
            {
            protected_hitPoint = value; }
            }
         
    }
    
    public int missPoint = -1;
    public ParticleSystem explode;
    public GameObject boom;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        // Move
        enemyRb.AddForce(Vector3.down * Speed(), ForceMode.Impulse);
        //Spin
        enemyRb.AddTorque(new Vector3(RandomForce(), RandomForce(), RandomForce()));
        //Change Material
        enemyRend = GetComponent<Renderer>();
        enemyRend.material = theMaterial[Random.Range(0, theMaterial.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < destroyBoundary)
        {
            // minus points for missed target
            if (gameManagerScript.gameRunning)
            {
            gameManagerScript.UpdateScore(missPoint);
            }
            
            Destroy(gameObject);
        }
    }
    // Create Random float for Spin
    private float RandomForce()
    {
        return Random.Range(0f, 2f);
    }
    // What happens when bullets hit target (Can be Overridden)
    public virtual void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("bullet") || other.CompareTag("forcefield"))
        {
            //Update Score
            gameManagerScript.UpdateScore(protected_hitPoint);
            //Make explosion and sound
            Instantiate(boom);
            Instantiate(explode, transform.position, transform.rotation);
            //Break bullet and target
            Destroy(gameObject);
            if (other.CompareTag("bullet"))
            {
            Destroy(other.gameObject);
            }
            
        }
    }

    // Speed that Enemy Travels (Can be Overridden)
    public virtual int Speed()
    {
        return 2;
    }
}
