using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Archer : Villager
{
    public GameObject arrowPrefab;
    public Transform spawnpoint;

    protected override void Attack()
    {
        destination = transform.position;
        base.Attack();
        Instantiate(arrowPrefab,spawnpoint.position,spawnpoint.rotation);
    }

    public override ChestType CanOpen()
    {
        return ChestType.Archer;
    }
}
