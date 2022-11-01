using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Zenject;

public class WindowUpgradKachestvo : MonoBehaviour
{
    [Inject]
    private ItemSingolton _itemSingolton;

    [Header("для анимайии")]
    public Animator _animator;
    public GameObject _panel;
    public Image _imageAnimation;
    public float _timeScroling;
    public float _timeDelay;

    public Kuznica _kuznica;
    private Item _itemOld;
    private Item _itemNew;

    public Inventary _inventary;
    public UIViborItemPanel _uiViborItemPanel;

    public GameObject _panelCurent;

    public Image _imageItem;  
    public Text _kacestvo;
    [Header("Панель характеристики текст количество")]
    public Text _TDamage;
    public Text _THeals;
    public Text _TArmor;
    public Text _TMiss;
    public Text _TCritChance;
    public Text _TCritDamage;
    public Text _TAttackSpeed;
    public Text _TMovementSpeed;
    public Text _TMaxLevel;
    [Header("Панель характеристики панели")]
    public GameObject _pDamage;
    public GameObject _pHeals;
    public GameObject _pArmor;
    public GameObject _pMiss;
    public GameObject _pCritChance;
    public GameObject _pCritDamage;
    public GameObject _pAttackSpeed;
    public GameObject _pMovementSpeed;
    public GameObject _pMaxLevel;
    [Header("Панель за улучшения")]
    public Text _TDamagePerLevel;
    public Text _THealsNewLevel;
    public Text _TArmorNewLevel;
    public Text _TMissNewLevel;
    public Text _TCritChanceNewLevel;
    public Text _TCritDamageNewLevel;
    public Text _TAttackSpeedNewLevel;
    public Text _TMovementSpeedNewLevel;
    public Text _TNewMaxLevel;

    [Header("Качество")]
    public GameObject tKacNormal;
    public GameObject tKacUncommon;
    public GameObject tKacUnusual;
    public GameObject tKacEpic;
    public GameObject tKacLegendary;

    [Header("партиклы")]
    public ParticleSystem _particleVan;
    public ParticleSystem _particleFeerverg;
   


    


    public void ViborItem()
    {
       
        
        

        _imageItem.sprite = _itemNew.gameObject.GetComponent<Image>().sprite;

        SetTextKacestvo(_itemNew.kacestvo);
        


        _TDamage.text = $"{(int)_itemOld.damagePesStart}";                          //добавлять сюда 
        _THeals.text = $"{(int)_itemOld.healsPerStart}";
        _TArmor.text = $"{(int)_itemOld.armorPerStart}";
        _TMiss.text = $"{_itemOld.missPerStart}%";
        _TCritChance.text = $"{_itemOld.critChancePerStart}%";
        _TCritDamage.text = $"{_itemOld.critDamagePerStart}%";
        _TAttackSpeed.text = $"{_itemOld.attackSpeedPerStart}%";
        _TMovementSpeed.text = $"{_itemOld.movementSpeedPerStart}";
        _TMaxLevel.text = $"{_itemOld.maxLevel}";
        

        _pDamage.SetActive(ProvercaNaNol(_itemOld.damagePesStart));
        _pHeals.SetActive(ProvercaNaNol(_itemOld.healsPerStart));
        _pArmor.SetActive(ProvercaNaNol(_itemOld.armorPerStart));
        _pMiss.SetActive(ProvercaNaNol(_itemOld.missPerStart));
        _pCritChance.SetActive(ProvercaNaNol(_itemOld.critChancePerStart));
        _pCritDamage.SetActive(ProvercaNaNol(_itemOld.critDamagePerStart));
        _pAttackSpeed.SetActive(ProvercaNaNol(_itemOld.attackSpeedPerStart));
        _pMovementSpeed.SetActive(ProvercaNaNol(_itemOld.movementSpeedPerStart));

        _TDamagePerLevel.text = $"+{(int)(_itemNew.damagePesStart-_itemOld.damagePesStart)}";                          //добавлять сюда 
        _THealsNewLevel.text = $"+{(int)(_itemNew.healsPerStart-_itemOld.healsPerStart)}";
        _TArmorNewLevel.text = $"+{(int)(_itemNew.armorPerStart- _itemOld.armorPerStart)}";
        _TMissNewLevel.text = $"+{_itemNew.missPerStart- _itemOld.missPerStart}%";
        _TCritChanceNewLevel.text = $"+{_itemNew.critChancePerStart- _itemOld.critChancePerStart}%";
        _TCritDamageNewLevel.text = $"+{_itemNew.critDamagePerStart- _itemOld.critDamagePerStart}%";
        _TAttackSpeedNewLevel.text = $"+{_itemNew.attackSpeedPerStart- _itemOld.attackSpeedPerStart}%";
        _TMovementSpeedNewLevel.text = $"+{_itemNew.movementSpeedPerStart- _itemOld.movementSpeedPerStart}";
        _TNewMaxLevel.text = $"+{_itemNew.maxLevel-_itemOld.maxLevel}";

        _TDamagePerLevel.gameObject.SetActive(ProvercaNaNol(_itemNew.damagePesStart));
        _THealsNewLevel.gameObject.SetActive(ProvercaNaNol(_itemNew.healsPerStart));
        _TArmorNewLevel.gameObject.SetActive(ProvercaNaNol(_itemNew.armorPerStart));
        _TMissNewLevel.gameObject.SetActive(ProvercaNaNol(_itemNew.missPerStart));
        _TCritChanceNewLevel.gameObject.SetActive(ProvercaNaNol(_itemNew.critChancePerStart));
        _TCritDamageNewLevel.gameObject.SetActive(ProvercaNaNol(_itemNew.critDamagePerStart));
        _TAttackSpeedNewLevel.gameObject.SetActive(ProvercaNaNol(_itemNew.attackSpeedPerStart));
        _TMovementSpeedNewLevel.gameObject.SetActive(ProvercaNaNol(_itemNew.movementSpeedPerStart));
        SetTextInTime();
    }

    public void InstalNewItem()
    {
        foreach (var it in _itemSingolton.allitems)
        {
            if (it.GetComponent<Item>().id == _itemOld.id + 100)
            {
                _itemNew = it.GetComponent<Item>();
            }
        }
    } 
    public void InstalOldItem(int id)
    {
        foreach (var it in _itemSingolton.allitems)
        {
            if (it.GetComponent<Item>().id == id)
            {
                _itemOld = it.GetComponent<Item>();
            }
        }
        

    }
    public void OpenWindow()
    {
        _panelCurent.SetActive(true);
        _animator.SetTrigger("start");
        InstalOldItem(_kuznica._id);
        InstalNewItem();
        _panel.SetActive(false);
        _imageAnimation.sprite = _itemOld.GetComponent<Image>().sprite;


    }
    public void SetTextInTime()
    {
        if (_pDamage.activeSelf)
        {
            _TDamage.DOText(_itemNew.damagePesStart.ToString(), _timeScroling,true,ScrambleMode.Numerals).SetDelay(_timeDelay);
        }
        if (_pHeals.activeSelf)
        {
            _THeals.DOText(_itemNew.healsPerStart.ToString(), _timeScroling,true,ScrambleMode.Numerals).SetDelay(_timeDelay);
        }
        if (_pArmor.activeSelf)
        {
            _TArmor.DOText(_itemNew.armorPerStart.ToString(), _timeScroling,true,ScrambleMode.Numerals).SetDelay(_timeDelay);
        }
        if (_pMiss.activeSelf)
        {
            _TMiss.DOText(_itemNew.missPerStart.ToString() + "%", _timeScroling,true,ScrambleMode.Numerals).SetDelay(_timeDelay);
        }
        if (_pCritChance.activeSelf)
        {
            _TCritChance.DOText(_itemNew.critChancePerStart.ToString() + "%", _timeScroling,true,ScrambleMode.Numerals).SetDelay(_timeDelay);
        }
        if (_pCritDamage.activeSelf)
        {
            _TCritDamage.DOText(_itemNew.critChancePerStart.ToString() + "%", _timeScroling,true,ScrambleMode.Numerals).SetDelay(_timeDelay);
        }
        if (_pAttackSpeed.activeSelf)
        {
            _TAttackSpeed.DOText(_itemNew.attackSpeedPerStart.ToString()+"%", _timeScroling,true,ScrambleMode.Numerals).SetDelay(_timeDelay);
        }
        if (_pMovementSpeed.activeSelf)
        {
            _TMovementSpeed.DOText(_itemNew.movementSpeedPerStart.ToString(), _timeScroling,true,ScrambleMode.Numerals).SetDelay(_timeDelay);
        }
        if (_pMaxLevel.activeSelf)
        {
            _TMaxLevel.DOText(_itemNew.maxLevel.ToString(), _timeScroling,true,ScrambleMode.Numerals).SetDelay(_timeDelay);
        }

    }
    public void StartVanParticle()
    {
        _particleVan.gameObject.SetActive(true);
        _particleVan.Play();
        
    }
    public void StoptVanParticle()
    {
        _particleVan.Stop();
        _particleVan.gameObject.SetActive(false);
 
    }

    public void StartTwoParticle()
    {
        _particleFeerverg.gameObject.SetActive(true);
        _particleFeerverg.Play();
    }
    public void OpenTwoWindow()
    {
        _panel.SetActive(true);
        ViborItem();
    }
    public void StopTwoParticle()
    {
        _particleFeerverg.Stop();
        _particleFeerverg.gameObject.SetActive(false);
    }
    public void SetItemAnimation()
    {
        _imageAnimation.sprite = _itemNew.GetComponent<Image>().sprite;
    }


    public void ClosePanel()
    {
        _panelCurent.SetActive(false);
        _particleFeerverg.gameObject.SetActive(false);
    }

    public void SkipAnimation()
    {
        if (_panel.activeSelf == false)
        {
            _animator.SetTrigger("stop");
            StopTwoParticle();
            StoptVanParticle();
            OpenTwoWindow();
        }
        else
        {
            ClosePanel();
        }
    }

    private bool ProvercaNaNol(float c)
    {
        return c != 0;
    }
    
    public void SetTextKacestvo(Item.Kacestvo kac)
    {
        tKacNormal.SetActive(false);
        tKacUncommon.SetActive(false);
        tKacUnusual.SetActive(false);
        tKacEpic.SetActive(false);
        tKacLegendary.SetActive(false);

        switch (kac)
        {
            case Item.Kacestvo.normal:
                tKacNormal.SetActive(true);
                break;
            case Item.Kacestvo.uncommon:
                tKacUncommon.SetActive(true);
                break;
            case Item.Kacestvo.unusual:
                tKacUnusual.SetActive(true);
                break;
            case Item.Kacestvo.epic:
                tKacEpic.SetActive(true);
                break;
            case Item.Kacestvo.legendary:
                tKacLegendary.SetActive(true);
                break;     
        }

    }
   


}
