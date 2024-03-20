using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

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
        if (firstObjroutine != null)
        {
            StopCoroutine(ObjIncrease(firstObj));
        }
        firstObjroutine = StartCoroutine(ObjIncrease(firstObj));
    }

    // Update is called once per frame
    void Update()
    {
        interpolation += Time.deltaTime * 1;
        interpolation = interpolation % 50;

        if (firstObj.localScale == endSize && secondObjroutine == null)
        {
            secondObjroutine = StartCoroutine(ObjIncrease(secondObj));
        }

        if (secondObj.localScale == endSize && thirdObjroutine == null)
        {
            thirdObjroutine = StartCoroutine(ObjIncrease(thirdObj));
        }

        if (thirdObj.localScale == endSize)
        {
            StopAllCoroutines();
        }
        //need to change the size depending on the time of each object
        //size of hte object is gameobject.trasfomr.scale and is a vector 3 although each number should be consistent
        //the scale of hte object must incrate over a linear interval to have a constant increase and should do one at a time

    }
    //current issue is that once this is done it does not go to the next one
    //elegant idea could be to pass it the object 
    IEnumerator ObjIncrease(Transform objectToTransform)
    {
        interpolation = 0;
        while (objectToTransform.localScale != endSize)
        {
            objectToTransform.localScale = Vector3.Lerp(startSize, endSize, interpolation);
            yield return null;
        }
    }
}
