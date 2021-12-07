using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUi : MonoBehaviour
{
    public Transform itemsParent;
    Inventory inventory;
    InventorySlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onAnimalChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateUI() {
        for (int i = 0; i < slots.Length; ++i) {
            if (i < inventory.animals.Count) {
                slots[i].AddAnimal(inventory.animals[i]);
            } else {
                slots[i].ClearSlot();
            }
        }
    }
}
