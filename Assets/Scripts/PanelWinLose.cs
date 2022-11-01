using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelWinLose : MonoBehaviour
{
    public GameObject _panelLose;
    public GameObject _panelWin;


    public void Win()
    {
        _panelLose.SetActive(false);
        _panelWin.SetActive(true);
    }
    public void Lose()
    {
        _panelLose.SetActive(true);
        _panelWin.SetActive(false);
    }
}
