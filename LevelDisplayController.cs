using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDisplayController : MonoBehaviour
{
    [SerializeField] private MapLevel[] levels;
    [SerializeField] private BranchLevel[] branchLevels;

    void Start()
    {
        var drawLevel = 0;
        var wisdom = 1;

        while (wisdom != 0 && drawLevel < levels.Length)
        {
            wisdom = levels[drawLevel].Initialise();
            drawLevel += 1;
        }

        for (int i = drawLevel; i < levels.Length; i++)
        {
            levels[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < branchLevels.Length; i++)
        {
            branchLevels[i].TryActivate();
        }
    }
}