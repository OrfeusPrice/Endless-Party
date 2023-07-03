using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject menu;
    public GameObject menuButton;
    public GameObject AIPlayButton;
    public GRMove CatPL;
    public GameObject HelpMenu;

    private void Awake()
    {
        Time.timeScale = 0f;
    }

    private void Update()
    {
        if (menu.activeInHierarchy || HelpMenu.activeInHierarchy || CatPL.DonatePanel.activeInHierarchy) { menuButton.SetActive(false); }
        else { menuButton.SetActive(true); }
    }
    public void PauseMenu()
    {
        Time.timeScale = 0f;
        menu.SetActive(true);
    }

    public void StartMenu()
    {
        Time.timeScale = 1f;
        menu.SetActive(false);
    }
    public void AIPlayStart()
    {
        AIPlayButton.SetActive(false);
        CatPL._AIPlay = true;
        StartMenu();
        if (CatPL._AIPlay)
        {
            Invoke("AIPlayClose", 20);
        }
    }

    public void AIPlayClose()
    {
        CatPL._AIPlay = false;
        SceneManager.LoadScene(0);
        CancelInvoke("AIPlayClose");
    }

    public void Help()
    {
        HelpMenu.SetActive(true);
        menu.SetActive(false);
    }

    public void HelpExit()
    {
        HelpMenu.SetActive(false);
        menu.SetActive(true);
    }

    public void NoDonate()
    {
        SceneManager.LoadScene(0);
    }
}
