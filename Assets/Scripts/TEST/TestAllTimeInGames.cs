using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class TestAllTimeInGames : MonoBehaviour
{
    [Inject]
    public Statistics _statistics;
    public Text _text;

    public float _time;
    


    void Start()
    {
       
        _text.text = _statistics.TimeInGameStatistick.GetTime(_statistics.TimeInGameStatistick._allTimeinGame);
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        if (_time >= 1)
        {
            _text.text = _statistics.TimeInGameStatistick.GetTime(_statistics.TimeInGameStatistick._allTimeinGame);
            _time = 0;
        }
    }
}
