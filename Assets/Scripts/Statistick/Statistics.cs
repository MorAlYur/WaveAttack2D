using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class Statistics : MonoBehaviour
{
    [Inject]
    public Saver _saver;
    public TimeInGameStatistick TimeInGameStatistick;


    private void Start()
    {
        TimeInGameStatistick = new TimeInGameStatistick(_saver);
    }
}
