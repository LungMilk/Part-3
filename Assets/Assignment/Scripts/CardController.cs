using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardController : MonoBehaviour
{
    //cards should not control this
    public TextMeshProUGUI CardSelectedText;
    public static CardController cc;
    //
    private void Start()
    {
        if (cc == null)
        {
            cc = this;
        }
    }

    public static Card selectedCard { get; private set;}
    public static void cardSelected(Card card)
    {
        selectedCard = card;
        cc.CardSelectedText.text = selectedCard.ToString();
    }
}
