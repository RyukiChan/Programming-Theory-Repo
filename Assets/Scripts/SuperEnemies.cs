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
        if (other.CompareTag("bullet") || other.CompareTag("forcefield"))
        {
            hitPoint = 7;
            count = count + 1;

            if (count == hitsToKill || other.CompareTag("forcefield"))
            {
                base.OnTriggerEnter(other);
            }
            else
            {
                if (other.CompareTag("bullet"))
                {
                    Destroy(other.gameObject);
                    Instantiate(boom);
                }

            }
        }




    }
}
