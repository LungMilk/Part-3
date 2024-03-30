using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armour : Card
{
    public Sprite Sprite;
    public override void randomization()
    {
        background.color = Color.blue;
        cost = Random.Range(2, 4);
        cardType = "Armour";
        health = Random.Range(3, 8);
        damage = Random.Range(2, 3);
        DescriptionText.text = "-1 to incoming damage";
        Image.sprite = Sprite;
        Image.color = Color.white;
        base.randomization();
    }
}
