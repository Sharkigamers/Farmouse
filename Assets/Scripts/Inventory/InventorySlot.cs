using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    GameObject animal;

    public void AddAnimal(GameObject newAnimal) {
        animal = newAnimal;

        icon.sprite = animal.GetComponent<SpriteRenderer>().sprite;
        icon.enabled = true;
    }

    public void ClearSlot() {
        animal = null;
        icon.sprite = null;
        icon.enabled = false;
    }
}
