using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : Object
{
    public Transform dropPoint;
    public int rateDrop;

    public override void DropItem()
    {
        base.DropItem();

        int randomRate = Random.Range(0, 100);
        int index = Random.Range(0, itemDrops.Length);

        if (randomRate < rateDrops[index])
        {
            Instantiate(itemDrops[index], dropPoint.position, Quaternion.identity);
        }
    }
}
