using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Merchant : Villager
{
    public override ChestType CanOpen()
    {
        return ChestType.Merchant;
    }
}
