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
    //
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
    private void OnMouseDown()
    {
        Debug.Log(this.ToString() + " Touched");

        StartCoroutine(selectAnimation());
        CardSelectedText.text =this.ToString();
    }

    public virtual void randomization()
    {
        costText.text = "Cost: " + cost.ToString();
        CardTypeText.text = "Unit Type: " + cardType;
        HealthText.text = "Health: " + health.ToString();
        DamageText.text = "Damage: " + damage.ToString();
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
