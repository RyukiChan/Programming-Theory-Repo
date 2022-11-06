using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    public bool hasPowerUp = false;
    public GameObject powerUpIndicator;
    public GameObject explodeEnemy;
    public ParticleSystem explode;
    public GameObject powerupTitle;
    public GameObject powerupTitleObject;
    public TextMeshProUGUI powerupTimer;


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
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            Instantiate(bullet, new Vector3(transform.position.x, bulletY, bulletZ), bullet.transform.rotation);
            laser.Play();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            if (hasPowerUp)
            {
                //Destroy(other.gameObject);
                //Instantiate(explodeEnemy);
                //Instantiate(explode, transform.position, transform.rotation);
            }
            else
            {
        Destroy(other.gameObject);
        Instantiate(playerDie,transform.position + new Vector3(0, 1, -2), playerDie.transform.rotation);
        Destroy(gameObject);
        Instantiate(boom);
        gameManagerScript.GameOver();
            }

        }

    }
    public void PowerUpPickedUp()
    {
        hasPowerUp = true;
        powerUpIndicator.SetActive(true);
        powerupTitle.SetActive(true);
        powerupTitleObject.SetActive(true);
        
        
        //StartCoroutine(PowerUpCountdown());
        StartCoroutine(PowerUpCountdown());
    }

    
    IEnumerator PowerUpCountdown(float TimerTick = 1.0f)
    {
        var reviveTime = 9.0f;
        powerupTimer.text = "" + reviveTime;
        while (reviveTime > 0)
        {
            reviveTime -= TimerTick; //...Time.deltaTime;

            powerupTimer.text = "" + reviveTime;
            yield return new WaitForSeconds(TimerTick); //...WaitForEndOfFrame();
        }
        // ... revival code here
        powerUpIndicator.SetActive(false);
        hasPowerUp = false;
        powerupTitle.SetActive(false);
        powerupTitleObject.SetActive(false);
    }
}
