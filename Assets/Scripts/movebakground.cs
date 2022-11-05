using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Applied to all Scene Backgrounds
public class movebakground : MonoBehaviour
{   [Range(-1f, 1f)]
    private float scrollSpeed = 0.5f;
    private float offset;
    private Material mat;


    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offset += (Time.deltaTime* scrollSpeed) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector3(0, -offset));

    }
}
