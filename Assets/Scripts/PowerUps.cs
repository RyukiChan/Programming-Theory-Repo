using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public GameObject pickup;
    public GameObject pickupSound;
    private int destroyBoundary = -5;
    private Renderer objectRend;
    private PlayerController playerControllerScript;


    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        objectRend = GetComponent<Renderer>();
        StartCoroutine(CycleColor());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * Speed());
        if (transform.position.y < destroyBoundary)
        {
         Destroy(gameObject);
        }
    }
    public virtual int Speed()
    {
        return 2;
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("player"))
        {
            Instantiate(pickup, transform.position, transform.rotation);
            Instantiate(pickupSound);
            playerControllerScript.PowerUpPickedUp();
            Destroy(gameObject);
            

        }
    }

    IEnumerator CycleColor()

    {
        while (true)
        {
            //Debug.Log("Start While Loop");
                    // Do while i is smaller than 120
                    for (int i = 0; i < 255; i++)
                {
                    //Debug.Log("Cyling:" + i);
                    yield return new WaitForSeconds(.01f);
                    //Max 120 for Blue Channel
                    objectRend.material.color = new Color32(0, 255, (byte)i, 255);
                }
                // Do while i is greater than 0
                for (int i = 255; i > 0; i--)
                {
                    //Debug.Log("2nd Cyling:" + i);
                    yield return new WaitForSeconds(.01f);
                    //Max 120 for Blue Channel
                    objectRend.material.color = new Color32(0, 255, (byte)i, 255);
                }
        }

    }
}
