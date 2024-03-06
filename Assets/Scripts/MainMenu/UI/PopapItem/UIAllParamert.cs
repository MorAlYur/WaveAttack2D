using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Zenject;

public class UIAllParamert : MonoBehaviour
{
    [Inject]
    public ItemSingolton _itemSingolton;
    public Text _bHP;
    public Text _bDamage;
    public Text _bArmor;
    public Text _bShild;
    public Text _bMiss;
    public Text _bCritShanse;
    public Text _bCritDamage;
    public Text _bAttacSpeed;
    public Text _bHPPlusisLevel;
    public Text _bGoldBonus;

    private void OnEnable()
    {
        _itemSingolton.OnChangeParametrEvent += SetParamentHaracterictic;
    }
    private void OnDisable()
    {
        _itemSingolton.OnChangeParametrEvent -= SetParamentHaracterictic;
    }
    private void Start()
    {
        SetParamentHaracterictic();
    }
    public void SetParamentHaracterictic()
    {
        _bHP.text = _itemSingolton._allHeals.ToString();
        _bDamage.text = _itemSingolton._allDamage.ToString();
        _bArmor.text = _itemSingolton._allArmor.ToString();
        _bShild.text = _itemSingolton._allShild.ToString();
        _bMiss.text = _itemSingolton._allMiss.ToString() + "%";
        _bCritShanse.text = _itemSingolton._allCritChance.ToString() + "%";
        _bCritDamage.text = _itemSingolton._allCritDamage.ToString() + "%";
        _bAttacSpeed.text = _itemSingolton._allAttackSpeed.ToString();
        _bHPPlusisLevel.text = _itemSingolton._allHealPerLevel.ToString();
        _bGoldBonus.text = _itemSingolton._allBonusGold.ToString() + "%";

    }
}
