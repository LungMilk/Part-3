using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Infantry : Card
{
    public Sprite Sprite;
    private void Start()
    {
        setValues();
        base.Start();
    }
    public void setValues()
    {
        background.color = Color.green;
        cost = Random.Range(0, 3);
        cardType = "Infantry";
        health = Random.Range(1,3);
        damage = Random.Range(1,2);
        DescriptionText.text = "+1 to movement";
        Image.sprite = Sprite;
        Image.color = Color.black;
    }
}
