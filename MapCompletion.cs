using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class MapCompletion : MonoSingleton<MapCompletion>
{
    public const string m_Filename = "completionFox.dat";

    [Serializable]
    private class m_EpisodeWisdom
    {
        public Episode m_Episode;
        public int m_Wisdom;
    }

    [SerializeField] private m_EpisodeWisdom[] completionData;
    public int m_TotalScore { private set;  get; }

    //*-- Unity Events
    private new void Awake()
    {
        base.Awake();
        Saver<m_EpisodeWisdom[]>.TryLoad(m_Filename, ref completionData);
        foreach (var episodeWisdom in completionData)
        {
            m_TotalScore += episodeWisdom.m_Wisdom;
        }
    }
    //--

    public static void SaveEpisodeResult(int levelWisdom)
    {
        if (Instance)
        {
            foreach (var item in Instance.completionData)
            {// Сохранение новых очков прохождения.
                if (item.m_Episode == LevelSequenceController.Instance.CurrentEpisode)
                {
                    if (levelWisdom > item.m_Wisdom)
                    {
                        Instance.m_TotalScore += levelWisdom - item.m_Wisdom;
                        item.m_Wisdom = levelWisdom;
                        Saver<m_EpisodeWisdom[]>.Save(m_Filename, Instance.completionData);
                    }
                }
            }
        }
        else
        {
            //Debug.Log($"Episode complete with score {levelScore}");
        }
    }

    public static void ResetSavedData()
    {
        FileHandler.Reset(m_Filename);
    }

    public int GetEpisodeScore(Episode m_episode)
    {
        foreach (var data in completionData)
        {
            if (data.m_Episode == m_episode)
                return data.m_Wisdom;
        }
        return 0;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
