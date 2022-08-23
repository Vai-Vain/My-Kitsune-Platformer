using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MapLevel : MonoBehaviour
{
    [SerializeField] private Episode m_Episode;
    [SerializeField] private Text text;

    //[SerializeField] private RectTransform m_ResultPanel;
    //[SerializeField] private Image[] m_ResultImages;

    public bool IsComplete { get { return 
                gameObject.activeSelf /*&& m_ResultPanel.gameObject.activeSelf*/; } }

    public int Initialise()
    {
        var score = MapCompletion.Instance.GetEpisodeScore(m_Episode);
        /*m_ResultPanel.gameObject.SetActive(score > 0);
        for (int i = 0; i < score; i++)
        {
            m_ResultImages[i].color = Color.black;
        }*/
        return score;
    }

    //    [SerializeField] private Text text;
    public void LoadLevel()
    {
    Debug.Log("Boom!");
        LevelSequenceController.Instance.StartEpisode(m_Episode);
    }

    public void SetLevelData(Episode episode, int wisdom)
    {
        m_Episode = episode;
        text.text = $"{wisdom}/10";
    }
}