using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Theif : Villager
{
    public GameObject DaggerPrefab;
    public Transform spawnpoint;
    public float dashspeed = 7;
    //float timer;
    //float dashTime = 2;
    //bool isDashing;
    protected override void Attack()
    {
        StartCoroutine(dash());
    }

    IEnumerator dash()
    {
        destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        speed = 7;

        while (speed > 3)
        { 
            yield return null;
        }
        base.Attack();
        yield return new WaitForSeconds(0.1f);
        Instantiate(DaggerPrefab, spawnpoint.position, spawnpoint.rotation);
        yield return new WaitForSeconds(0.1f);
        Instantiate(DaggerPrefab, spawnpoint.position, spawnpoint.rotation);

    }
    public override ChestType CanOpen()
    {
        return ChestType.Thief;
    }
}
