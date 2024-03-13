using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Theif : Villager
{
    public GameObject DaggerPrefab;
    public Transform spawnpoint;

    protected override void Attack()
    {
        destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        base.Attack();
        for (int i = 0; i < 2; i++) 
        {
            Debug.Log("Whoosh");
            Instantiate(DaggerPrefab, spawnpoint.position, spawnpoint.rotation); 
        }
    }
    public override ChestType CanOpen()
    {
        return ChestType.Thief;
    }
}
