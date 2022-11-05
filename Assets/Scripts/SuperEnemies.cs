using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperEnemies : Enemies
{
    public int speed;
    private int count = 0;
    public int hitsToKill;

    public override int Speed()
    {
        return speed;
    }

    public override void OnTriggerEnter(Collider other)
    {
        count = count + 1;
     
        if (count == hitsToKill)
        {
            base.OnTriggerEnter(other);
        }
        else
        {
        Destroy(other.gameObject);
        Instantiate(boom);
        }

        
    }
}
