using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardController : MonoBehaviour
{
    //UI text
    public TextMeshProUGUI CardSelectedText;
    //list allows it to iterate and call eaches randomize funciton
    public List<Card> cards;
    //this public static object allows it to reference the selected text to change the variable in the card selected function as well as other card objects can reference if a card was selected
    public static CardController cc;
    private void Start()
    {
        if (cc == null)
        {
            //declares the card controller object
            cc = this;
        }
        //sets default text
        cc.CardSelectedText.text = "Pick a Unit";
    }
    //this function is called by the reshuffle button
    public void reshuffle()
    {
        //resets the selected card to null
        selectedCard = null;
        cc.CardSelectedText.text = "Pick a Unit";
        //goes through the amount of cards displayed and calls eaches randomization function
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].randomization();
        }
    }

    //the static card variable is whatever was selected and can be referenced through the public object
    public static Card selectedCard { get; private set;}
    //the function changes the ui text and fills the selected card variable
    public static void cardSelected(Card card)
    {
        selectedCard = card;
        //cannot make it cardtype for some reason
        cc.CardSelectedText.text = selectedCard.ToString();
    }
}
