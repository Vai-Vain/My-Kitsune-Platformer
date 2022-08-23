using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelConditionWisdom : MonoBehaviour, ILevelCondition
{
    [SerializeField] private int wisdom;

    private bool m_Reached;

    bool ILevelCondition.IsCompleted
    {
        get
        {
            if (Player.Instance != null)
            {
                if (Player.Instance.Wisdom >= wisdom)
                {
                    m_Reached = true;
                }
            }
            return m_Reached;
        }
    }

}