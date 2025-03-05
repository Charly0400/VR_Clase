using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Item
{
    public int ID = 0;

    public override void OnPickUp()
    {

        Debug.Log("You got a key");
        Inventory.SaveItem(this);
        Level_Manager.SendToPool(this.gameObject);
        gameObject.SetActive(false);    


    }


}
