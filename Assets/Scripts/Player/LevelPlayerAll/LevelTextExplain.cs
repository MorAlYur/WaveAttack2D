using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class LevelTextExplain : MonoBehaviour
{
    private float time;
    public float timeTextActive;
    public GameObject _panel;
    public TextMeshProUGUI _shortSpecification;
    public TextMeshProUGUI _fullSpecification;


    private void Update()
    {
        time += Time.deltaTime;
        if (time >= timeTextActive)
        {
            DeactivateBonText();
        }
    }
    public void ActivateBonText(string shortSpec,string fullSpec)
    {
        _panel.SetActive(true);
        time = 0f;
        _shortSpecification.text = shortSpec;
        _fullSpecification.text = fullSpec;
    }
    public void DeactivateBonText()
    {
        _panel.SetActive(false);
    }
    public void SetActiveFalse()
    {
        _panel.SetActive(false);
    }



}