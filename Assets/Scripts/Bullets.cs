using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public float speed;
    public Renderer bulletRend;
    
    public float destroyBulletBoundary = 7;
    // Start is called before the first frame update
    void Start()
    {
        bulletRend = GetComponent<Renderer>();
        bulletRend.material.color = new Color(1, 1, RandomZeroOne());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);

        if (transform.position.y > destroyBulletBoundary)
        {
            Destroy(gameObject);
        }
    }
    private float RandomZeroOne()
    {
        return Random.Range(0f, 1f);
    }
}
