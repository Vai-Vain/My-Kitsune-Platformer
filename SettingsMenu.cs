using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private GameObject m_MainMenuPanel;
    [SerializeField] private GameObject m_SettingsPanel;


    private void Start()
    {
        m_MainMenuPanel.SetActive(false);
        m_SettingsPanel.SetActive(true);
    }

    public void Save()
    {
        // Сохранение пользовательских настроек.
    }

    public void Reset()
    {
        // Сброс настроек на default.
    }

    public void BackToMainMenu()
    {
        //SceneManager.LoadScene(0);
        m_MainMenuPanel.SetActive(true);

        gameObject.SetActive(false);
    }
}
