using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//условие для прохождения уровня по достижению установленной в редакторе позиции
//(желательно области).
public class LevelConditionPosition : MonoBehaviour, ILevelCondition
{
    [SerializeField] private GameObject m_Player;
    private int t = 0;
    private bool m_Reached;

    bool ILevelCondition.IsCompleted
    {
        get
        {
            if (Player.Instance != null)
            {
                if (t == 200)
                {
                    m_Reached = true;
                }
            }
            return m_Reached;
        }
    }

    
private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != m_Player) return;

        else
        {
            t = 200;
        }
    }
}