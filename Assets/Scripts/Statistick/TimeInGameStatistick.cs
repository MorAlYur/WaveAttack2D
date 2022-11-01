using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class TimeInGameStatistick 
{
    //[Inject]
    private Saver _saver;
    public long _allTimeinGame;
    public long _menuTimeinGame;
    public long _gamplayTimeinGame;
    private double _timeAdd =1d;
    private DateTime _defoldData = new DateTime();
    private DateTime _curentData = new DateTime();

    public TimeSpan _timeSpan = new TimeSpan();

    private int _indexScene = 0;

    public TimeInGameStatistick(Saver saver)
    {
        _saver = saver;
        Start();
    }

    public void Start()
    {
        _allTimeinGame = _saver._saveData._allTimeinGame;
        _menuTimeinGame = _saver._saveData._menuTimeinGame;
        _gamplayTimeinGame = _saver._saveData._gamplayTimeinGame;

        TimerCallback tm = new TimerCallback(Update);
        Timer timer = new Timer(tm, null, 0, 1000);
        
        SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;

    }

    private void SceneManager_activeSceneChanged(Scene arg0, Scene activeSctne)
    {
        _indexScene = activeSctne.buildIndex;
    }

    public void Update(object obj)
    {
        _curentData = _curentData.AddSeconds(_timeAdd);
        TimeSpan changeTimeSpan = new TimeSpan((_curentData - _defoldData).Ticks);
        _allTimeinGame += changeTimeSpan.Ticks;
        _saver._saveData._allTimeinGame = _allTimeinGame;
        _curentData = _defoldData;
        

        if (_indexScene == 0)
        {
            _menuTimeinGame += changeTimeSpan.Ticks;
            _saver._saveData._menuTimeinGame = _menuTimeinGame;
        }
        else
        {
            _gamplayTimeinGame += changeTimeSpan.Ticks;
            _saver._saveData._gamplayTimeinGame = _gamplayTimeinGame;
        }
    }
    public string GetTime(long timeTick)
    {
        TimeSpan elapsedSpan = new TimeSpan(timeTick);
        int h = (int)elapsedSpan.TotalHours;
        string text1 = elapsedSpan.TotalHours.ToString("f0");
        string hour = h.ToString("d2");
        string text = h.ToString("d2") + ":" + elapsedSpan.Minutes.ToString("d2") + ":" + elapsedSpan.Seconds.ToString("d2");
        return text;
    }
}
