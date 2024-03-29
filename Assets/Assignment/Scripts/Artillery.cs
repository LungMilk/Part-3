using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artillery : Card
{
    public Sprite Sprite;
    private void Start()
    {
        setValues();
        base.Start();
    }
    public void setValues()
    {
        background.color = Color.red;
        cost = Random.Range(1, 4);
        cardType = "Artillery";
        health = Random.Range(2, 5);
        damage = Random.Range(4, 8);
        DescriptionText.text = "Range of 5 units";
        Image.sprite = Sprite;
        Image.color = Color.white;
    }
}
