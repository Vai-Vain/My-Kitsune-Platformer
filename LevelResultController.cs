using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


    /// <summary>
    /// Панель результатов уровня. Должна лежать в каждом уровне без галочки DoNotDestroyOnLoad.
    /// </summary>
    public class LevelResultController : MonoSingleton<LevelResultController>
    { 

    [SerializeField] private GameObject m_PanelShowResults;
    
    [SerializeField] private Text m_LevelTime;
    //[SerializeField] private Text m_TotalPlayTime;
    [SerializeField] private Text m_TotalWisdom;
    //[SerializeField] private Text m_TotalCritter;

    [SerializeField] private Button m_ButtonNext;
    [SerializeField] private Button m_ButtonRestart;

    private bool m_Success;

    /// <summary>
    /// Показываем окошко результатов. Выставляем нужные кнопочки в зависимости от успеха.
    /// TODO: надо перенести метод в ShowResults
    /// </summary>
    /// <param name="result"></param>
    public void Show(bool result)
    {
        /*  m_PanelSuccess?.gameObject.SetActive(result);
        m_PanelFailure?.gameObject.SetActive(!result);*/

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

        m_PanelShowResults?.gameObject.SetActive(result);
    }

    public void ShowResults(PlayerStatistics levelResults, bool success)
    {
    gameObject.SetActive(true);

    m_Success = success;

    Time.timeScale = 0;

        UpdateCurrentLevelStats();
        UpdateVisualStats();
        Show(success);
        ResetPlayerStats();

    //m_Critter.text = "Critters : " + levelResults.numCritter.ToString();
    //m_TotalWisdom.text = "Wisdom : " + levelResults.wisdom.ToString();
    //m_LevelTime.text = "Time : " + levelResults.time.ToString();
    }

    public class Stats
    {
        public int numCritter;
        public float time;
        public int wisdom;
    }

    /// <summary>
    /// Общая статистика за эпизод.
    /// </summary>
    public static Stats TotalStats { get; private set; } = new Stats();

    /// <summary>
    /// Сброс общей статистики за эпизод. Вызывается перед началом эпизода.
    /// </summary>
    public static void ResetPlayerStats()
    {
        TotalStats = new Stats();
    }

    /// <summary>
    /// Собирает статистику по текущему уровню.
    /// </summary>
    /// <returns></returns>
    private void UpdateCurrentLevelStats()
    {
        TotalStats.numCritter += Player.Instance.NumCritter;
        TotalStats.time += LevelController.Instance.LevelTime;
        TotalStats.wisdom += Player.Instance.Wisdom;

        // бонус за время прохождения.
        //int timeBonus = (int) (LevelController.Instance.ReferenceTime - LevelController.Instance.LevelTime);

        //if(timeBonus > 0)
        //    TotalStats.wisdom += timeBonus;
    }

    /// <summary>
    /// Метод обновления статов уровня.
    /// </summary>
    private void UpdateVisualStats()
    {
        m_LevelTime.text = System.Convert.ToInt32(LevelController.Instance.LevelTime).ToString();
        m_TotalWisdom.text = TotalStats.wisdom.ToString();
        //m_TotalPlayTime.text = System.Convert.ToInt32(TotalStats.time).ToString();
        //m_TotalCritter.text = TotalStats.numCritter.ToString();
    }
}