using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    public Item Item;
    void Pickup()
    {
        InventoryManager.Instance.Add(Item);//luam obiectul
        Destroy(gameObject); // il distrugem dupa ce il luam si il vom vedea in inventari
    }

    private void OnMouseDown() // apasind pe mouse click singa vom lua obiectul
    {
        Pickup();
    }

}
