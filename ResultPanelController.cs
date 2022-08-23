using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultPanelController : MonoSingleton<ResultPanelController>
{
    //[SerializeField] private Text m_Critter;
    [SerializeField] private Text m_Wisdom;
    [SerializeField] private Text m_Time;

    [SerializeField] private Text m_Result;

    [SerializeField] private Button m_ButtonNext;
    [SerializeField] private Button m_ButtonRestart;

    private bool m_Success;

    private void Start()
    {
        //gameObject.SetActive(false);
    }

    /*public void ShowResults(PlayerStatistics levelResults, bool success)
    {
        //gameObject.SetActive(true);

        if (Player.Instance.Wisdom >= 1)
        {
            m_ButtonNext.gameObject.SetActive(true);
            m_ButtonRestart.gameObject.SetActive(false);
        }
        else
        {
            m_ButtonNext.gameObject.SetActive(false);
            m_ButtonRestart.gameObject.SetActive(true);
        }

        m_Success = success;

        //m_Result.text = success ? "Win" : "Lose";
        //m_ButtonNextText.text = success ? "Next" : "Restart";

        //TODO: "next" "restart"


        Time.timeScale = 0;

        //m_Critter.text = "Critters : " + levelResults.numCritter.ToString();
        m_Wisdom.text = "Wisdom : " + levelResults.wisdom.ToString();
        m_Time.text = "Time : " + levelResults.time.ToString();
    }*/


    /// <summary>
    /// Запускаем следующий уровен. Дергается эвентом с кнопки play next.
    /// </summary>
    public void OnButtonNextAction()
    {
        gameObject.SetActive(false);

        Time.timeScale = 1;

        if (Player.Instance.Wisdom >= 1)
        {
            LevelSequenceController.Instance.AdvanceLevel();
        }
        else
        {
            //уровень проигран, код для рестарта
            LevelSequenceController.Instance.RestartLevel();
        }
    }

    /// <summary>
    /// Рестарт уровня. Дергается эвентом с кнопки restart в случае фейла уровня.
    /// </summary>
    public void OnButtonRestartLevel()
    {
        gameObject.SetActive(false);

        Time.timeScale = 1;

        LevelSequenceController.Instance.RestartLevel();
    }


    public void OnMenu()
    {
        LevelSequenceController.Instance.OnMenu();
    }
}