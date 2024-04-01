using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artillery : Card
{
    //the sprite is whatever it was set to in the inspector
    public Sprite Sprite;
    public override void randomization()
    {
        //the ranges are different as well as the description text that change with the override
        background.color = Color.red;
        //the values are random between a range which gives more variety
        cost = Random.Range(1, 4);
        cardType = "Artillery";
        health = Random.Range(2, 5);
        damage = Random.Range(4, 8);
        DescriptionText.text = "Range of 5 units";
        Image.sprite = Sprite;
        Image.color = Color.white;
        //having base allows the values to display after they are initialized
        base.randomization();
    }
}
