using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface ILevelCondition
{
    bool IsCompleted { get; }
}

public class LevelController : MonoSingleton<LevelController>
{
    [SerializeField] public float m_ReferenceTime;
    public float ReferenceTime => m_ReferenceTime;

    [SerializeField] protected UnityEvent m_EventLevelCompleted;

    private ILevelCondition[] m_Condition;

    private bool m_IsLevelCompleted;

    private float m_LevelTime;
    public float LevelTime => m_LevelTime;

    protected void Start()
    {
        m_Condition = GetComponentsInChildren<ILevelCondition>();
    }

    private void Update()
    {
        if (!m_IsLevelCompleted)
        {
            m_LevelTime += Time.deltaTime;

            CheckLevelConditions();
        }
    }

    private void CheckLevelConditions()
    {
        if (m_Condition == null || m_Condition.Length == 0)
            return;

        int numCompleted = 0;

        foreach (var v in m_Condition)
        {
            if (v.IsCompleted)
                numCompleted++;
        }

        if (numCompleted == m_Condition.Length)
        {
            m_IsLevelCompleted = true;
            m_EventLevelCompleted?.Invoke();

            LevelSequenceController.Instance?.FinishCurrentLevel(true);
        }
    }
}