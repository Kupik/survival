using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();


    // Adauga obiecte in inventari
    public Transform ItemContent; // Obiectul si continutul lui
    public GameObject InventoryItem; //Inventariu Nostru

    // scwich remove or no remove
    public Toggle EnableRemove;

    public InventoryItemController[] InventoryItems; // array

    private void Awake() // chemam instance
                        // folosim awake pentru al chema doar odata
    {
        Instance = this;
        
    }

    public void Add(Item item)// adaugam obiectul
    {
        Items.Add(item);
    }

    public void Remove(Item item)// stergem obictul
    {
        Items.Remove(item);

    }



    

    public void ListItems() // lista de Itmes
    {
        foreach (Transform item in ItemContent)
        {
            // curatim obiectul din dinainte sal adaugam pentru a nu avea dublu sau triplu obiecte etc...\
            Destroy(item.gameObject);

        }


        foreach (var item in Items )
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent); // intoarcem obiectele 
            var itemName = obj.transform.Find("ItemName").GetComponent<Text>(); // link Text object
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();// link Image object
            var removeButton = obj.transform.Find("RemoveButton").GetComponent<Button>();

            // ca sa putem vedea obiectul cu num si img
            itemName.text = item.itemName; 
            itemIcon.sprite = item.icon;  

            if(EnableRemove.isOn)
            {
                removeButton.gameObject.SetActive(true);
            }

        }

        SetInventoryItems();
    }

    // facem ca sa apara icon de remove la Obiectele noastre din Inventory
    public void EnableItemsRemove()
    {
        if (EnableRemove.isOn)
        {
            foreach(Transform item in ItemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(true);
            } 
                         
        } 
        else
        {
            foreach (Transform item in ItemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(false);
            }
        } 
    }

    public void SetInventoryItems()
    {
        InventoryItems = ItemContent.GetComponentsInChildren<InventoryItemController>();
       
        for (int i = 0; i < Items.Count; i++)
        {
            InventoryItems[i].AddItem(Items[i]);
        }
    }


}
