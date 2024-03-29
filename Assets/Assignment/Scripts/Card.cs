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
    public Rigidbody2D rgd2d;

    int cost;
    string cardType;
    int health;
    int damage;

    int offset;

    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        rgd2d = GetComponent<Rigidbody2D>();
        randomization();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log(this.ToString() + " Touched");

        StartCoroutine(selectAnimation());
    }

    public void randomization()
    {
        costText.text = cost.ToString();
        CardTypeText.text = cardType;
        HealthText.text = health.ToString();
        DamageText.text = damage.ToString();
    } 

    IEnumerator selectAnimation()
    {
        while (offset < 1)
        {
            rgd2d.transform.Translate(transform.up * 2 * Time.deltaTime);
            yield return null;
        }
        while (offset > -8)
        {
            rgd2d.transform.Translate(transform.up * 2 * Time.deltaTime);
            yield return null;
        } 
    }
}
