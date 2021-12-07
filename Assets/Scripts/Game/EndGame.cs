using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class EndGame : MonoBehaviour
{
    public Text animalNumberText;

    public Transform animalsParent;

    private int animalNumber;

    // Start is called before the first frame update
    void Start()
    {
        animalNumber = animalsParent.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        animalNumber = animalsParent.childCount;
        animalNumberText.text = animalNumber.ToString();
        if (animalNumber <= 0)
            UnitySceneManager.LoadScene("Success Scene");
    }
}
