using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GUIManager : MonoBehaviour
{
    public static GUIManager Instance { get; private set; }
    
    public GameObject homeGUI;
    public GameObject gameGUI;
    public GameObject pauseBox;
    public GameObject gameOverBox;
    public GameObject settingBox;
    public GameObject shopBox;

    private void Awake()
    {
        if(Instance !=null && Instance!=this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    public void showHomeGUI()
    {
        homeGUI.SetActive(true);
        gameGUI.SetActive(false);
    }
    public void showGameGUI()
    {
        homeGUI.SetActive(false);
        gameGUI.SetActive(true);
        pauseBox.SetActive(false);
        gameOverBox.SetActive(false);
        Time.timeScale = 1f;
    }
    public void showPauseBox()
    {
        pauseBox.SetActive(true);
        Time.timeScale = 0f;
    }
    public void showGameOverBox()
    {
        gameOverBox.SetActive(true);
        Time.timeScale = 0f;
    }  
    public void gameReplay()
    {
        showGameGUI();
        SceneManager.LoadScene("SampleScene");
    }
    public void showShopBox()
    {
        shopBox.SetActive(true);
    }
    public void showSettingBox()
    {
        settingBox.SetActive(true);
    }
    public void exitShopBox()
    {
        shopBox.SetActive(false);
    }    
    public void exitSettingBox()
    {
        settingBox.SetActive(false);
    }    
}
