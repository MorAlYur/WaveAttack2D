using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EnemyHPBar : MonoBehaviour
{
    private RectTransform _rectTransform;

    [SerializeField] private EmenyHPManager _emenyHPManager;
    [SerializeField] private Image _max;
    [SerializeField] private Image _change;
    [SerializeField] private Image _curent;
    [SerializeField] private float _durotavn;

   
    private void OnEnable()
    {
        _emenyHPManager.HPBarEvent += OnCangeBar;
    }
    private void OnDisable()
    {
        _emenyHPManager.HPBarEvent -= OnCangeBar;
    }
    private void Start()
    {
       // _rectTransform = gameObject.GetComponent<RectTransform>();
        _max.fillAmount = 1;
        _change.fillAmount = 1;
        _curent.fillAmount = 1;
    }

    private void OnCangeBar(float value)
    {
        _curent.DOFillAmount(value,0);
        _change.DOFillAmount(value, _durotavn);
    }
    public void Rot()
    {
        //_rectTransform.localScale.x = -_rectTransform.localScale.x;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}
