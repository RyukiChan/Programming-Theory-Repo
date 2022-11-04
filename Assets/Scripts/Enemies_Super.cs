using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies_Super : Enemies
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Inherited from Enemies. Speed =:" + speed); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
