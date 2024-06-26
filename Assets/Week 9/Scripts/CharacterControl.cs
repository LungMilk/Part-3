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
    public List<Villager> villagerList;
    private void Start()
    {
        if (charcontroller == null) 
        {
            charcontroller = this;
            charcontroller.WhatIsSelectedText.text = "Nothing selected";
        }
    }

    //private void OnMouseDown()
    //{
    //    CharacterControl.SetSelectedVillager(this);
    //    clickingOnSelf = true;
    //}

    public void DropboxSelection(int value)
    {
        CharacterControl.SetSelectedVillager(villagerList[value]);
    }

    public void sizeIncrease(Single value)
    {
        //issue as it returns to its original size after it changes
        SelectedVillager.transform.localScale = new Vector3(value,value,value);
        SelectedVillager.size = value;
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
