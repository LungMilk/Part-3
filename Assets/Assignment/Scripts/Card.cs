using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.U2D.IK;


public class Card : MonoBehaviour
{
    //public objects of the different text objects
    public TextMeshProUGUI costText;
    public TextMeshProUGUI CardTypeText;
    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI DamageText;
    public TextMeshProUGUI DescriptionText;
    //sprite renderers for the image on the card and background for more visual distinction between units
    public SpriteRenderer background;
    public SpriteRenderer Image;
    //rigidbody is needed to move the card in an animation
    public Rigidbody2D rgd2d;

    Coroutine anim;
    //protected allows its children access but not visible to other scripts,inspector, ect...
    protected int cost;
    protected string cardType;
    protected int health;
    protected int damage;


    public AnimationCurve animationCurve;
    public float lerpTimer;
    public float interpolation;

    // Start is called before the first frame update
    public void Start()
    {
        background = GetComponent<SpriteRenderer>();
        rgd2d = GetComponent<Rigidbody2D>();
        //calling the randomization function has each of the children call the function and change their information
        randomization();
    }
    //once the mouse collides with the card object
    private void OnMouseDown()
    {
        //Debug.Log(this.ToString() + " Touched");
        //it checks the public objects variable if its null which if true that means a card was selected and it is not able to be selected.
        if (CardController.selectedCard == null)
        {
            //this animation is a coroutine animation that moves the card offscreen as a signifier to the player which was picked
            anim = StartCoroutine(selectAnimation());
            //this has the card that was selected saved by the controller so it can be referenced by the UI text 
            CardController.cardSelected(this);
        }
        //CardSelectedText.text = this.ToString();
    }
    //this function displays all the values of each card
    public virtual void randomization()
    {
        //display the variables to the text
        costText.text = "Cost: " + cost.ToString();
        CardTypeText.text = "Unit Type: " + cardType;
        HealthText.text = "Health: " + health.ToString();
        DamageText.text = "Damage: " + damage.ToString();
        //without this if statement anim is null which causes the text to not display so this allows it to stop it only if it exists
        //this happened because the ones that were not selected had no coroutine running causing a null return
        if (anim != null)
        {
            StopCoroutine(anim);
            //reset lerp timer
            lerpTimer = 0;
        }
        //this resets it to the default position, since only x is altered it is the only thing reset as well it allows each to retain their offsets
        rgd2d.transform.position = new Vector3(rgd2d.transform.position.x, 0, rgd2d.transform.position.z);
    } 
    //coroutine for hte animation
    IEnumerator selectAnimation()
    {
        //setting the start and end position
        Vector3 startPosition = new Vector3(rgd2d.transform.position.x, 0f, rgd2d.transform.position.z);
        Vector3 endPosition = new Vector3(rgd2d.transform.position.x, -10f, rgd2d.transform.position.z);
        //the coroutine runs till it reaches the end positon
        while (rgd2d.transform.position != endPosition)
        {
            //using a cool animation curve to give more flow with time for the animation instead of the previous rigid movement
            interpolation = animationCurve.Evaluate(lerpTimer);
            //the position values are increasing at the interpolaiton depending on the time the coroutine is running having small smooth movement changes
            //lerpunclamped allows the values in the inspector to go beyond 0 or 1 giving me the option to overshoot and have the desired elastic effect
            transform.position = Vector3.LerpUnclamped(startPosition, endPosition, interpolation);
            lerpTimer += Time.deltaTime;
            yield return null;
        }
        //old coroutine animation
        ////this gives it a little bump then it goes down
        //while (rgd2d.transform.position.y <= 1)
        //{
        //    rgd2d.transform.Translate(transform.up * 2 * Time.deltaTime);
        //    yield return null;
            
        //}
        ////-10 allows it to go offscreen
        //while (rgd2d.transform.position.y >= -10)
        //{
        //    rgd2d.transform.Translate(transform.up  * -3 * Time.deltaTime);
        //    yield return null;
        //} 
    }
}
