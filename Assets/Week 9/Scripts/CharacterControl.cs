using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CharacterControl : MonoBehaviour
{
    public TextMeshProUGUI currentSelection;
    public static CharacterControl Instance;
    public static Villager SelectedVillager { get; private set; }

    private void Start()
    {
        Instance = this;
    }
    public static void SetSelectedVillager(Villager villager)
    {
        if(SelectedVillager != null)
        {
            SelectedVillager.Selected(false);
            //currentSelection.text = "Selected: Nothing";
        }
        SelectedVillager = villager;
        SelectedVillager.Selected(true);
        //currentSelection.text = villager.name;
    }
    
}
