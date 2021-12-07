using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;

    private void Awake() {
        if (instance != null) {
            Debug.LogWarning("More than one instance of Inventory");
            return;
        }
        instance = this;
    }

    #endregion

    public List<string> itemTags;

    public delegate void OnAnimalChanged();
    public OnAnimalChanged onAnimalChangedCallback;

    public int space = 3;
    public List<GameObject> animals = new List<GameObject>();

    public bool Add(GameObject animal) {
        if (itemTags.Contains(animal.tag)) {
            if (animals.Count == 0) {
                animals.Add(animal);
            }
            else if (animals.Count < space && animal.tag == animals[0].tag) {
                animals.Add(animal);
            }
            else
                return false;
            if (onAnimalChangedCallback != null)
                onAnimalChangedCallback.Invoke();
            return true;
        }
        return false;
    }

    public void Remove(GameObject animal) {
        animals.Remove(animal);

        if (onAnimalChangedCallback != null)
                onAnimalChangedCallback.Invoke();
    }
}
