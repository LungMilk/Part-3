using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Transform firstObj;
    public Transform secondObj;
    public Transform thirdObj;

    public Vector3 startSize;
    public Vector3 endSize;
    float interpolation;

    Coroutine firstObjroutine;
    Coroutine secondObjroutine;
    Coroutine thirdObjroutine;

    void Start()
    {
        firstObjroutine = StartCoroutine(firstObjIncrease());
        secondObjroutine = StartCoroutine(secondObjIncrease());
        thirdObjroutine = StartCoroutine(thirdObjIncrease());
    }

    // Update is called once per frame
    void Update()
    {
        interpolation += Time.deltaTime * 1;
        if (thirdObj.localScale ==endSize)
        {
            StopAllCoroutines();
        }
        //need to change the size depending on the time of each object
        //size of hte object is gameobject.trasfomr.scale and is a vector 3 although each number should be consistent
        //the scale of hte object must incrate over a linear interval to have a constant increase and should do one at a time

    }
    IEnumerator firstObjIncrease()
    {
        while (firstObj.localScale !=endSize)
        {
            firstObj.localScale = Vector3.Lerp(startSize, endSize, interpolation);
            yield return null;
        }
    }

    IEnumerator secondObjIncrease()
    {
        //better if the while loop is related to conditionals that interupt the coroutine
        while (firstObj.localScale == endSize && secondObj.localScale != endSize)
        {
            secondObj.localScale = Vector3.Lerp(startSize, endSize, interpolation);
            yield return null;
        }
    }
    IEnumerator thirdObjIncrease()
    {
        while (secondObj.localScale != endSize)
        { 
            yield return null;
        }
        thirdObj.localScale = Vector3.Lerp(startSize, endSize, interpolation);
    }
}
