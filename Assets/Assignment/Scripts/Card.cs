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
    //cards should not control this
    public TextMeshProUGUI CardSelectedText;
    public SpriteRenderer background;
    public SpriteRenderer Image;
    public Rigidbody2D rgd2d;

    protected int cost;
    protected string cardType;
    protected int health;
    protected int damage;

    // Start is called before the first frame update
    public void Start()
    {
        background = GetComponent<SpriteRenderer>();
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
        CardSelectedText.text =this.ToString();
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
        while (rgd2d.transform.position.y <= 1)
        {
            rgd2d.transform.Translate(transform.up * 2 * Time.deltaTime);
            yield return null;
            
        }
        while (rgd2d.transform.position.y >= -10)
        {
            rgd2d.transform.Translate(transform.up  * -3 * Time.deltaTime);
            yield return null;
        } 
    }
}
