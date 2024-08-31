using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    Item item;
    // stergem obiectul din inventory

    public Button RemoveButton;

    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(item);

        Destroy(gameObject);
    }

    
    public void AddItem(Item newItem)
    {
        item = newItem;
    }


    public void UseItem(Item item)
    {
  

    switch (item.itemType) {

         case Item.ItemType.Potion:
                DamageDeathScript.Instance.HealthHero(item.value);
              break;            
        }
    
        RemoveItem();
    }

   
}
