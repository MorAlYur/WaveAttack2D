using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Zenject;

public class UIViborItemPanel : MonoBehaviour
{
    [Inject]
    private Bank _bank;
    public Inventary inventary;
    public Animator anim;
    public GameObject ViborItemsPanel;
    [Header ("Кнопка улучшить")]
    public Button upgradeB;
    public Text upgradeText;
    public Text upgradeTextUpgrade;
    public GameObject upgradeTextMaxLevel;
    public int saleText;
    public GameObject TakeOff;
    public GameObject TakeOn;
    public GameObject imGoldUpdate;
    
    

    public bool isActiv;
    public Image image;
    public Text itemName;
    public Text level;
    [Header("Панель характеристики текст количество")]
    public Text _TDamage;
    public Text _THeals;
    public Text _TArmor;
    public Text _TMiss;
    public Text _TCritChance;
    public Text _TCritDamage;
    public Text _TAttackSpeed;
    public Text _TMovementSpeed;
    [Header("Панель характеристики панели")]
    public GameObject _pDamage;
    public GameObject _pHeals;
    public GameObject _pArmor;
    public GameObject _pMiss;
    public GameObject _pCritChance;
    public GameObject _pCritDamage;
    public GameObject _pAttackSpeed;
    public GameObject _pMovementSpeed;
    [Header("Панель за улучшения")]
    public Text _TDamagePerLevel;
    public Text _THealsPerLevel;
    public Text _TArmorPerLevel;
    public Text _TMissPerLevel;
    public Text _TCritChancePerLevel;
    public Text _TCritDamagePerLevel;
    public Text _TAttackSpeedPerLevel;
    public Text _TMovementSpeedPerLevel;

    [Header("Качество")]
    public GameObject tKacNormal;
    public GameObject tKacUncommon;
    public GameObject tKacUnusual;
    public GameObject tKacEpic;
    public GameObject tKacLegendary;
    [Header("Все остальное")]
    public InventaryPart _inventaryPart;
    public Image _imagePart;
    public Text _tPart;
    public Slider _sliderPart;

    public Color _colorUpgradeButtonTextInteractableON;
    public Color _colorUpgradeButtonTextInteractableOFF;

    

    [Header("Цвет качеста айтемов ")]
    public Color _colorNormal;
    public Color _colorUncommon;
    public Color _colorUnusual;
    public Color _colorEpic;
    public Color _colorLegendary;

    [Header("Панель наноматериала")]
    public GameObject _panelNanomaterial;
    public TMP_Text _tNanomaterialCount;

    private void Awake()
    {
       
    }
    private void OnEnable()
    {
       
        inventary.ClosePanelViborItemEvent += Inventary_ClosePanelViborItem;
        //Item.NoviiEvent += ViborItemPanel;
    }

    

    private void OnDisable()
    {
        inventary.ClosePanelViborItemEvent -= Inventary_ClosePanelViborItem;
       // Item.NoviiEvent -= ViborItemPanel;
    }


    private void Inventary_ClosePanelViborItem()
    {
        ClosePanelIsAnimation();
    }



    public void ViborItemPanel(Item item)
    {
        if (inventary.isKuznjaActive)
            return;

        if (ViborItemsPanel.activeSelf)
        {
            ClosePanel();
        }
        ViborItemsPanel.SetActive(true);

        _imagePart.sprite = _inventaryPart.GetImage(item.partID).sprite;
        _tPart.text = $"{_inventaryPart.GetCount(item.partID)}/{_inventaryPart.GetCountPartPerLevel(item.level)}";
        _sliderPart.maxValue = _inventaryPart.GetCountPartPerLevel(item.level);
        if (_inventaryPart.GetCount(item.partID) >= _inventaryPart.GetCountPartPerLevel(item.level)||                              //если хватает материала
            _inventaryPart.GetCount(item.partID)+_inventaryPart.GetCount(999) < _inventaryPart.GetCountPartPerLevel(item.level)) // или не хватает материала + наноматериала
        {
            _tPart.text = $"{_inventaryPart.GetCount(item.partID)}/{_inventaryPart.GetCountPartPerLevel(item.level)}";           //материал/нужный материал
            _sliderPart.value = _inventaryPart.GetCount(item.partID);                                                            
            _panelNanomaterial.SetActive(false);
        }
        else if(_inventaryPart.GetCount(item.partID) < _inventaryPart.GetCountPartPerLevel(item.level) &&                           //если не хватает материала
            _inventaryPart.GetCount(item.partID) + _inventaryPart.GetCount(999) >= _inventaryPart.GetCountPartPerLevel(item.level)) // но хватает с наноматериалам
        {
            _tPart.text = $"{_inventaryPart.GetCountPartPerLevel(item.level)}/{_inventaryPart.GetCountPartPerLevel(item.level)}";   //100/100
            _sliderPart.value = _inventaryPart.GetCountPartPerLevel(item.level);
            _panelNanomaterial.SetActive(true);
            int count = (_inventaryPart.GetCountPartPerLevel(item.level) - _inventaryPart.GetCount(item.partID));
            int maxCount = _inventaryPart.GetCount(999);
            _tNanomaterialCount.text = LocalizationManager.Localize("ViborItem.IsUsedFrom", count,maxCount);
        }


        image.sprite = item.gameObject.GetComponent<Image>().sprite;
        itemName.text = item.GetItemName();
        SetTextKacestvo(item.kacestvo);
        level.text = $"{LocalizationManager.Localize("Menu.ViborItem.Level")} {item.level}";
         

        _TDamage.text = $"{(int)item.damage}";                          //добавлять сюда 
        _THeals.text = $"{(int)item.heals}";
        _TArmor.text = $"{(int)item.armor}";
        _TMiss.text = $"{item.miss}%";
        _TCritChance.text = $"{item.critChance}%";
        _TCritDamage.text = $"{item.critDamage}%";
        _TAttackSpeed.text = $"{item.attackSpeed}%";
        _TMovementSpeed.text = $"{item.shild}";

        _pDamage.SetActive(ProvercaNaNol(item.damage));
        _pHeals.SetActive(ProvercaNaNol(item.heals));
        _pArmor.SetActive(ProvercaNaNol(item.armor));
        _pMiss.SetActive(ProvercaNaNol(item.miss));
        _pCritChance.SetActive(ProvercaNaNol(item.critChance));
        _pCritDamage.SetActive(ProvercaNaNol(item.critDamage));
        _pAttackSpeed.SetActive(ProvercaNaNol(item.attackSpeed));
        _pMovementSpeed.SetActive(ProvercaNaNol(item.shild));

        _TDamagePerLevel.text = $"+{(int)item.damagePerLevel}";                          //добавлять сюда 
        _THealsPerLevel.text = $"+{(int)item.healsPerLevel}";
        _TArmorPerLevel.text = $"+{(int)item.armorPerLevel}";
        _TMissPerLevel.text = $"+{item.missPerLevel}%";
        _TCritChancePerLevel.text = $"+{item.critChancePerLevel}%";
        _TCritDamagePerLevel.text = $"+{item.critDamagePerLevel}%";
        _TAttackSpeedPerLevel.text = $"+{item.attackSpeedPerLevel}%";
        _TMovementSpeedPerLevel.text = $"+{item.movementSpeedPerLevel}";

        _TDamagePerLevel.gameObject.SetActive(ProvercaNaNol(item.damagePerLevel));
        _THealsPerLevel.gameObject.SetActive(ProvercaNaNol(item.healsPerLevel));
        _TArmorPerLevel.gameObject.SetActive(ProvercaNaNol(item.armorPerLevel));
        _TMissPerLevel.gameObject.SetActive(ProvercaNaNol(item.missPerLevel));
        _TCritChancePerLevel.gameObject.SetActive(ProvercaNaNol(item.critChancePerLevel));
        _TCritDamagePerLevel.gameObject.SetActive(ProvercaNaNol(item.critDamagePerLevel));
        _TAttackSpeedPerLevel.gameObject.SetActive(ProvercaNaNol(item.attackSpeedPerLevel));
        _TMovementSpeedPerLevel.gameObject.SetActive(ProvercaNaNol(item.movementSpeedPerLevel));


        upgradeText.text = (item.level * 200).ToString();                          // текст стоимости улучшеня и активность кнопки
        upgradeB.interactable = _bank.IsEnaughtGold(item.level * 200) && item.level < item.maxLevel&&
            _inventaryPart.GetCountPartPerLevel(item.level)<= _inventaryPart.GetCount(item.partID)+_inventaryPart.GetCount(999);

        if (upgradeB.IsInteractable() == true)
        {
            upgradeText.color = _colorUpgradeButtonTextInteractableON;
            upgradeTextUpgrade.color = _colorUpgradeButtonTextInteractableON;
            imGoldUpdate.SetActive(true);
        }
        else
        {
            upgradeText.color = _colorUpgradeButtonTextInteractableOFF;
            upgradeTextUpgrade.color = _colorUpgradeButtonTextInteractableOFF;
           
            
        }
        if (item.level == item.maxLevel)
        {
            upgradeText.gameObject.SetActive(false);
            upgradeTextUpgrade.gameObject.SetActive(false);
            upgradeTextMaxLevel.SetActive(true);
            imGoldUpdate.SetActive(false);

        }
        else
        {
            upgradeText.gameObject.SetActive(true);
            upgradeTextUpgrade.gameObject.SetActive(true);
            upgradeTextMaxLevel.SetActive(false);
            imGoldUpdate.SetActive(true);
        }

        if (item.isActiv == true)
        {
            TakeOff.SetActive(true);
            TakeOn.SetActive(false);
        }
        else
        {
            TakeOff.SetActive(false);
            TakeOn.SetActive(true);
        }

        if (item.level == 1)                                  //Текст стоимости продажи 
            saleText= 50;
        else
            saleText = (int)(((0.5 * (item.level - 1) * (item.level)) * 200)*0.5);
        


    }

    private bool ProvercaNaNol(float c)
    {
        return c != 0;
    }
    public void ClosePanelIsAnimation()
    {
        anim.SetTrigger("CloseAnimTriger");
    }
    public void ClosePanel()
    {
        
        ViborItemsPanel.SetActive(false);
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
