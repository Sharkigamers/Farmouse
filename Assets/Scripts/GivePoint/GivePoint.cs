using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GivePoint : MonoBehaviour
{
    public GameObject animal;

    private void OnTriggerEnter(Collider other) {
        if (animal.tag == other.tag) {
            Inventory.instance.Remove(other.gameObject);
            Destroy(other.gameObject);
        }
    }
}
