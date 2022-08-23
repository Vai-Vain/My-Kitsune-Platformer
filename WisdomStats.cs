using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WisdomStats : MonoBehaviour
{
    [SerializeField] private Text m_Text;

    private int m_LastWisdom;

    private void Update()
    {
        UpdateScore();
    }

    private void UpdateScore()
    {
        if (Player.Instance != null)
        {
            int currentWisdom = Player.Instance.Wisdom;

            if(m_LastWisdom != currentWisdom)
            {
                m_LastWisdom = currentWisdom;

                m_Text.text = "Wisdom : " + m_LastWisdom.ToString();
            }
        }
    }
}
