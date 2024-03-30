using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardController : MonoBehaviour
{
    //cards should not control this
    public TextMeshProUGUI CardSelectedText;
    public List<Card> cards;
    public static CardController cc;
    //
    private void Start()
    {
        if (cc == null)
        {
            cc = this;
        }
        cc.CardSelectedText.text = "Pick a Unit";
    }
    public void reshuffle()
    {
        selectedCard = null;
        cc.CardSelectedText.text = "Pick a Unit";
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].randomization();
        }
    }
    //how can all cards reset?
    //have a list of all cards that calls each of the cards randomize function
    public static Card selectedCard { get; private set;}
    public static void cardSelected(Card card)
    {
        selectedCard = card;
        cc.CardSelectedText.text = selectedCard.ToString();
    }
}
