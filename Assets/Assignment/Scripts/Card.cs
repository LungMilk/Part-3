using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Card : MonoBehaviour
{
    public TextMeshProUGUI costText;
    public TextMeshProUGUI CardTypeText;
    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI DamageText;
    public TextMeshProUGUI DescriptionText;
    SpriteRenderer spr;
    Rigidbody2D rgd2d;

    int cost;
    string cardType;
    int health;
    int damage;



    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        rgd2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log(this.ToString() + " Touched");
    }
}
