﻿using System.Collections;using System.Collections.Generic;using UnityEngine;using UnityEngine.UI;using UnityEngine.SceneManagement;public class ResetProgress : MonoBehaviour{    public void YesReset()    {        FileHandler.Reset(MapCompletion.m_Filename);        //FileHandler.Reset(Upgrades.filename);        SceneManager.LoadScene(2);    }    public void NoReset()    {        SceneManager.LoadScene(0);    }}