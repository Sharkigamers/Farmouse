using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class GameManager : MonoBehaviour
{
    [Range(1, 3540)]
    public float maxTimer = 120;
    public Text timerText;

    private float currentTime;
    private float skyboxIncrement;
    private float skyboxCurrentAtmosphereValue = 1;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = maxTimer;
        RenderSettings.skybox.SetFloat("_AtmosphereThickness", skyboxCurrentAtmosphereValue);
        RenderSettings.skybox.SetFloat("_Exposure", 1f);
        skyboxIncrement = 4 / maxTimer;
        UpdateTimerText();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSkybox();
        UpdateTimer();
        UpdateTimerText();
        if (currentTime == 0) {
            UnitySceneManager.LoadScene("Defeat Scene");
        }
    }

    void UpdateSkybox() {
        skyboxCurrentAtmosphereValue += skyboxIncrement * Time.deltaTime;
        if (skyboxCurrentAtmosphereValue > 5)
            skyboxCurrentAtmosphereValue = 5;
        RenderSettings.skybox.SetFloat("_AtmosphereThickness", skyboxCurrentAtmosphereValue);
    }

    void UpdateTimer() {
        currentTime -= 1 * Time.deltaTime;
        if (currentTime < 0) {
            currentTime = 0;
        }
    }

    void UpdateTimerText() {
        double hour = Mathf.Floor(currentTime / 60);;
        double minutes = Mathf.Round(currentTime % 60);
        timerText.text = hour.ToString("00") + ":" + minutes.ToString("00");
    }
}
