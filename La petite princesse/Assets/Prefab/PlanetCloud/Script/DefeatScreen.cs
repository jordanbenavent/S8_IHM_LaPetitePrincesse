using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DefeatScreen : MonoBehaviour {
    private bool isDefeatScreenActive = false;

    private static bool instantiated = false;

    private void Awake()
    {
        if (!instantiated)
        {
            DontDestroyOnLoad(gameObject);
            instantiated = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        gameObject.SetActive(false);
        PlayerMovement.PlayerOutOfScreen += OnPlayerOutOfScreen;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

     void Update()
    {
        if (isDefeatScreenActive)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                // Reload the scene
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                isDefeatScreenActive = false;
                gameObject.SetActive(false);
            }
        }
    }

    public void OnPlayerOutOfScreen(object sender, PlayerOutOfScreenEventArgs e)
    {
        Time.timeScale = 0;
        isDefeatScreenActive = true;
        gameObject.SetActive(true);
        TextMeshProUGUI altitudeText = gameObject.transform.Find("DefeatPanel/AltitudeText").GetComponent<TextMeshProUGUI>();
        if (altitudeText != null)
        {
            altitudeText.text = "Altitude: " + Mathf.RoundToInt(e.Altitude);
        }
    }
}
