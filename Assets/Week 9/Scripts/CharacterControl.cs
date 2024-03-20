using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class CharacterControl : MonoBehaviour
{
    public TextMeshProUGUI WhatIsSelectedText;
    public static CharacterControl charcontroller;
    private void Start()
    {
        if (charcontroller == null) 
        {
            charcontroller = this;
            charcontroller.WhatIsSelectedText.text = "Nothing selected";
        }
    }

    public static Villager SelectedVillager { get; private set; }
    public static void SetSelectedVillager(Villager villager)
    {
        if(SelectedVillager != null)
        {
            SelectedVillager.Selected(false);
        }
        charcontroller.WhatIsSelectedText.text = villager.CanOpen().ToString();
        SelectedVillager = villager;
        SelectedVillager.Selected(true);
    }
    
}
