using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class InventoryItem : MonoBehaviour
{
    
    [Header("UI")]
    public Image image;
    
    [HideInInspector] public Item item;
    
     public void InitialiseItem(Item newItem)
     {
         item = newItem;
         image.sprite = newItem.image; 
     }
     
}
  