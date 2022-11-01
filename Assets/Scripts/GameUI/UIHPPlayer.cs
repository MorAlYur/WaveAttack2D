using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHPPlayer : MonoBehaviour
{
    public ManagerHPPlayer _managerHPPlayer;
    public TextFlyPlayer _textFlyPlayer;

    public Slider _sliderHP;
    public Slider _sliderShild;
    public Text _tHP;
    public float _timeSliderChange;
    private void OnEnable()
    {
        _managerHPPlayer.ChangeHPEvent += ChangeHP;
        _managerHPPlayer.ChangeShildEvent += ChangeShild;
        _managerHPPlayer.MissEvent += Miss;
        _managerHPPlayer.MaxHPEvent += MaxHP;
        _managerHPPlayer.MaxShildEvent += MaxShild;
    }
    private void OnDisable()
    {
        _managerHPPlayer.ChangeHPEvent -= ChangeHP;
        _managerHPPlayer.ChangeShildEvent -= ChangeShild;
        _managerHPPlayer.MissEvent -= Miss;
        _managerHPPlayer.MaxHPEvent -= MaxHP;
        _managerHPPlayer.MaxShildEvent -= MaxShild;
    }
    private void Start()
    {
        
    }

    private void MaxShild(int maxShild,int shild,bool isSetShild)
    {
        _sliderShild.maxValue = maxShild;
        if (isSetShild)
        {
            _sliderShild.value = shild;
        }
    }

    private void MaxHP(int maxHP,int HP,bool isSetHP)
    {
        _sliderHP.maxValue = maxHP;
        if (isSetHP)
        {
            _sliderHP.value = HP;
            _tHP.text = HP.ToString();
        }
    }

    private void Miss()
    {
        _textFlyPlayer.Dodge();
    }

    private void ChangeShild(int change, int newCount, bool isDamage)
    {
        _sliderShild.DOValue(newCount, _timeSliderChange);
        if (isDamage == true)
        {
            _textFlyPlayer.ShildMinus(change);
        }
        else
        {
            _textFlyPlayer.ShildPlus(change);
        }
    }

    private void ChangeHP(int change, int newCount, bool isDamage)
    {
        _sliderHP.DOValue(newCount, _timeSliderChange);
        _tHP.text = newCount.ToString();
        if (isDamage == true)
        {
            _textFlyPlayer.DamageText(change);
        }
        else
        {
            _textFlyPlayer.HealsText(change);
        }
    }
}
