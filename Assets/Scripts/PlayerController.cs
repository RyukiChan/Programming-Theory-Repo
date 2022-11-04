using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontal;
    public float speed;
    public GameObject bullet;
    public float bulletY;
    public float bulletZ;
    private AudioSource laser;
    public GameObject playerDie;
    private GameManager gameManagerScript;
    public GameObject boom;
    private float playerBoundaryX = 6.2f;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        laser = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal"); 
        transform.Translate(Vector3.up * Time.deltaTime * speed * horizontal);
        if (transform.position.x < -playerBoundaryX)
        {
            transform.position = new Vector3(-playerBoundaryX, transform.position.y, transform.position.z);
        }

        if (transform.position.x > playerBoundaryX)
        {
            transform.position = new Vector3(playerBoundaryX, transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet,new Vector3(transform.position.x, bulletY, bulletZ),bullet.transform.rotation);
            laser.Play();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        Instantiate(playerDie,transform.position,playerDie.transform.rotation);
        Destroy(gameObject);
        Instantiate(boom);
        gameManagerScript.GameOver();
    }
}
