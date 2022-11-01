using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFlyPlayer : MonoBehaviour
{
    public GameObject _goDamageText;
    public Text _tDamage;
    public GameObject _goHealsText;
    public Text _tHeals;
    public GameObject _goShildPlusText;
    public Text _tShildPlus;
    public GameObject _goShildMinusText;
    public Text _tShildMinus;
    public GameObject _goDodgeText;

    public void DamageText(int damage)
    {
        _tDamage.text = damage.ToString();
        _goDamageText.SetActive(true);
    }

    public void HealsText(int heals)
    {
        _tHeals.text = heals.ToString();
        _goHealsText.SetActive(true);
    }
    public void ShildPlus(int value)
    {
        _tShildPlus.text = value.ToString();
        _goShildPlusText.SetActive(true);
    }
    public void ShildMinus(int value)
    {
        _tShildMinus.text = value.ToString();
        _goShildMinusText.SetActive(true);
    }
    public void Dodge()
    {
        _goDodgeText.SetActive(true);
    }
}
