using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardEnemies : Enemies

{
    public override void OnTriggerEnter(Collider other)
    {
        hitPoint = 4;
        base.OnTriggerEnter(other);
    }

}
