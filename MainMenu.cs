using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject m_SettingsPanel;
    [SerializeField] private GameObject m_EpisodeSelection;
    [SerializeField] private GameObject m_MainMenuPanel;

    [SerializeField] private Button continueButton;

    private void Start()
    {
        m_MainMenuPanel.SetActive(true);
        m_SettingsPanel.SetActive(false);
        continueButton.interactable = FileHandler.HasFile(MapCompletion.m_Filename);
    }

    public void NewGame()
    {
    SceneManager.LoadScene(1);
    //m_EpisodeSelection.gameObject.SetActive(true);

    //gameObject.SetActive(false);
}

    public void Settings()
    {
        m_SettingsPanel.SetActive(true);

        gameObject.SetActive(false);
    }

    public void Continue()
    {
        SceneManager.LoadScene(2);
    }

    public void Quit()
    {
        Application.Quit();
    }

}