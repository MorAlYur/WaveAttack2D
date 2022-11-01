using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class FPSTarget : MonoBehaviour
{
    [SerializeField] private int _fps;

    private bool _isActiv;
    [SerializeField] private RectTransform _panel;
    [SerializeField] private float _durAnim;
    [SerializeField] private Text _label;

    [SerializeField] private Slider _slider;
    [SerializeField] private Text _textValueSlider;
    [SerializeField] private RectTransform _panel2;

    private void Start()
    {
        SetFpsVSyncs();
    }

    public void SetFps(int fps)
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = fps;
    }
    public void SetFpsVSyncs()
    {
        QualitySettings.vSyncCount = 1;
    }

    public void ActivateDeactivate()
    {
        if (_isActiv == true)
        {
            _isActiv = false;
            _label.text = "Показыть";
            _panel.DOAnchorPosY(200, _durAnim);
           
        }
        else
        {
            _isActiv = true;
            _label.text = "Скрыть";
            _panel.DOAnchorPosY(0, _durAnim);
           
        }
    }

    public void SetFpsIsSlider()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate =(int) _slider.value;
    }
     
    public void SetTextValueSlider2(float newValue)
    {
        _textValueSlider.text = newValue.ToString();
    }

    public void EntePanel2()
    {
        _panel2.DOAnchorPosY(-200, _durAnim);
    }
    public void ExitPanel2()
    {
        _panel2.DOAnchorPosY(0, _durAnim);
    }

    public void SetSvoiFps() 
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate =(int) _slider.value;
        ExitPanel2();
    }
}
