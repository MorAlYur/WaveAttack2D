using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UpgradePersInMenu : MonoBehaviour
{
    [Inject]
    public ItemSingolton _itemSingolton;
    [Header("для светяющихся переходов")]

    public Image image;
    private Color colorStart;
    public Color Color;
    //public Button[] _button;
    public Image[] images;
    public int kolvoMaxPerebor;
    public int kolvoPerebor;
    public float timeSvetPerebor;
    public float plusTimeSvetPerebor;
    public int r;
    public int kolvoMaxMiganie;
    public int kolvoMiganie;
    public float timeSvetMiganie;


    [Header("Характеристики")]
    public float damage;
    public float heals;
    public float armor;
    public float miss;
    public float critChance;
    public float critDamage;
    public float attackSpeed;
    public float shild;
    public float healPesLevel;
    public float goldBonus;

    public float damagePerLevel;
    public float healsPerLevel;
    public float armorPerLevel;
    public float missPerLevel;
    public float critChancePerLevel;
    public float critDamagePerLevel;
    public float attackSpeedPerLevel;
    public float shildPerLevel;
    public float healPerLevelPerLevel;
    public float goldBonusPerLevel;

    public int damageLevel;
    public int healsLevel;
    public int armorLevel;
    public int missLevel;
    public int critChanceLevel;
    public int critDamageLevel;
    public int attackSpeedLevel;
    public int shildLevel;
    public int healPerLevelLevel;
    public int goldBonusLevel;
    [Header(" ")]
    public Text TDamageLevel;
    public Text THealsLevel;
    public Text TArmorLevel;
    public Text TMissLevel;
    public Text TCritChanseLevel;
    public Text TCritDamageLevel;
    public Text TAttackSpeedLevel;
    public Text TMovementkSpeedLevel;
    public Text THealPerLevelLevel;
    public Text TGoldBonusLevel;

    public Text TDamageCount;
    public Text THealsCount;
    public Text TArmorount;
    public Text TMissCount;
    public Text TCritChanseCount;
    public Text TCritDamageCount;
    public Text TAttackSpeedCount;
    public Text TShildCount;
    public Text THealPerLevelCount;
    public Text TGoldBonusCount;

    private string tDamageCount;
    private string tHealsCount;
    private string tArmorount;
    private string tMissCount;
    private string tCritChanseCount;
    private string tCritDamageCount;
    private string tAttackSpeedCount;
    private string tShildCount;
    private string tHealPerLevelCount;
    private string tGoldBonusCount;



    public int allPointsUpgrade;

    [Header("Все остальное")]
    public GameObject _anticlicerAll;
    public Text _tAllpointUpgrade;
    public Button _bUpgrade;
    public Text _tPriceUpgrade;


    private int _priceUpgrade;

    public event Action<int> UpgradePersEvent;

    public SaveLoadUpgradeMenu _saveLocal;
    [Inject]
    public Saver _saver;
    [Inject]
    public Bank _bank;
    private void Awake()
    {

    }
    public void Start()
    {
        _saveLocal = new SaveLoadUpgradeMenu();
        colorStart = image.color;
        //SetTextCoun();


    }
  
   
    public void Zapusk()
    {
        allPointsUpgrade++;
        StartCoroutine(Perebor());
        _bank.SpendGold(_priceUpgrade);
        SetPriceUpgrade();
        _anticlicerAll.SetActive(true);
    }

    public IEnumerator Perebor()
    {
        var t = timeSvetPerebor;
        for (kolvoPerebor=0; kolvoPerebor < kolvoMaxPerebor; kolvoPerebor++)
        {
            var x = r;
            while (x==r)
            {
                r = UnityEngine.Random.Range(0, images.Length);
            }
            
            images[r].color = Color;
            yield return new WaitForSeconds(t);
            images[r].color = colorStart;
            t += plusTimeSvetPerebor;
        }
        StartCoroutine(Miganie());
    }
    public IEnumerator Miganie()
    {
        for (kolvoMiganie = 0;  kolvoMiganie< kolvoMaxMiganie; kolvoMiganie++)
        {
            images[r].color = Color;
            yield return new WaitForSeconds(timeSvetMiganie);
            if (kolvoMaxMiganie - kolvoMiganie == 1)
            {
                Upgrade(r);
            }
            images[r].color = colorStart;
            yield return new WaitForSeconds(timeSvetMiganie);

        }
    }

    public void GetInteractableButtonUpgrade()
    {
        _bUpgrade.interactable = _bank.IsEnaughtGold(_priceUpgrade);
    }
    public void SetPriceUpgrade()
    {
        _priceUpgrade = 100 + (100 * allPointsUpgrade);
        _tPriceUpgrade.text = _priceUpgrade.ToString();
        GetInteractableButtonUpgrade();
    }

    public void Upgrade(int number)
    {
        switch (number)
        {
            case 0:
                damageLevel++;
                break;
            case 1:
                healsLevel++;
                break;
            case 2:
                armorLevel++;
                break;
            case 3:
                missLevel++;
                break;
            case 4:
                critChanceLevel++;
                break;
            case 5:
                critDamageLevel++;
                break;
            case 6:
                attackSpeedLevel++;
                break;
            case 7:
                shildLevel++;
                break;
            case 8:
                healPerLevelLevel++;
                break;
            case 9:
                goldBonusLevel++;
                break;
            default:
                break;
        }
        UstanovkaParametrov();
        SetTextFly();
        UpgradePersEvent?.Invoke(number);
        _anticlicerAll.SetActive(false);
        SaveGame();
        SetParametrItemSingolton();



    }
    private void UstanovkaParametrov()
    {
        damage = damagePerLevel * damageLevel;
        heals = healsPerLevel * healsLevel;
        armor = armorPerLevel * armorLevel;
        miss = missPerLevel * missLevel;
        critChance = critChancePerLevel * critChanceLevel;
        critDamage = critDamagePerLevel * critDamageLevel;
        attackSpeed = attackSpeedPerLevel * attackSpeedLevel;
        shild  = shildPerLevel * shildLevel;
        healPesLevel = healPerLevelPerLevel * healPerLevelLevel;
        goldBonus = goldBonusPerLevel * goldBonusLevel;

        TDamageLevel.text = damageLevel.ToString();
        THealsLevel.text = healsLevel.ToString();
        TArmorLevel.text = armorLevel.ToString();
        TMissLevel.text = missLevel.ToString();
        TCritChanseLevel.text = critChanceLevel.ToString();
        TCritDamageLevel.text = critDamageLevel.ToString();
        TAttackSpeedLevel.text =  attackSpeedLevel.ToString();
        TMovementkSpeedLevel.text =  shildLevel.ToString();
        THealPerLevelLevel.text =  healPerLevelLevel.ToString();
        TGoldBonusLevel.text = goldBonusLevel.ToString();

        _tAllpointUpgrade.text = allPointsUpgrade.ToString();

        

}
    

    public void SetTextFly()
    {
       TDamageCount.text = LocalizationManager.Localize("Menu.Upgrades.Damage.TextFly") + damage.ToString();
        THealsCount.text = LocalizationManager.Localize("Menu.Upgrades.Health.TextFly") + heals.ToString();
        TArmorount.text = LocalizationManager.Localize("Menu.Upgrades.Defense.TextFly") + armor.ToString(); ;
        TMissCount.text = LocalizationManager.Localize("Menu.Upgrades.Dodge.TextFly") + miss.ToString() +"%";
        TCritChanseCount.text = LocalizationManager.Localize("Menu.Upgrades.CritChance.TextFly") + critChance.ToString() + "%";
        TCritDamageCount.text = LocalizationManager.Localize("Menu.Upgrades.CriticalDamage.TextFly") + critDamage.ToString() + "%";
        TAttackSpeedCount.text = LocalizationManager.Localize("Menu.Upgrades.MachineGun.TextFly") + attackSpeed.ToString() + "%";
        TShildCount.text = LocalizationManager.Localize("Menu.Upgrades.Powerman.TextFly") + shild.ToString();
        THealPerLevelCount.text = LocalizationManager.Localize("Menu.Upgrades.Medic.TextFly") + healPesLevel.ToString();
        TGoldBonusCount.text = LocalizationManager.Localize("Menu.Upgrades.RichMan.TextFly") + goldBonus.ToString() + "%";
    }

    //public void SetTextCoun()
    //{
    //    tDamageCount = TDamageCount.text;
    //    tHealsCount = THealsCount.text;
    //    tArmorount = TArmorount.text;
    //    tMissCount = TMissCount.text;
    //    tCritChanseCount = TCritChanseCount.text;
    //    tCritDamageCount = TCritDamageCount.text;
    //    tAttackSpeedCount = TAttackSpeedCount.text;
    //    tShildCount = TShildCount.text;
    //    tHealPerLevelCount = THealPerLevelCount.text;
    //    tGoldBonusCount = TGoldBonusCount.text;
    //}

    public void SetParametrItemSingolton()
    {
        _itemSingolton.SetParametrUpgrade(damage,heals,armor,miss,critChance,critDamage,attackSpeed,shild,healPesLevel,goldBonus);
    }
    public void SaveGame()
    {

        _saveLocal.UpDamageLevelSave = damageLevel;
        _saveLocal.UpHealsLevelSave = healsLevel;
        _saveLocal.UpArmorLevelSave = armorLevel;
        _saveLocal.UpMissLevelSave = missLevel;
        _saveLocal.UpCritChanceLevelSave = critChanceLevel;
        _saveLocal.UpCritDamageLevelSave = critDamageLevel;
        _saveLocal.UpAttackSpeedLevelSave = attackSpeedLevel;
        _saveLocal.UpShildLevelSave = shildLevel;
        _saveLocal.UpHealPerLevelLevelSave = healPerLevelLevel;
        _saveLocal.UpGoldBonusLevelSave = goldBonusLevel;
        _saveLocal.allPointUpgrade = allPointsUpgrade;

        _saver.SaveDataUpgradePers(_saveLocal);
    }
    public void LoadGame()
    {
        _saveLocal = _saver.LoadDataUpgradePers();

            damageLevel = _saveLocal.UpDamageLevelSave;
            healsLevel = _saveLocal.UpHealsLevelSave;
            armorLevel = _saveLocal.UpArmorLevelSave;
            missLevel = _saveLocal.UpMissLevelSave;
            critChanceLevel = _saveLocal.UpCritChanceLevelSave;
            critDamageLevel = _saveLocal.UpCritDamageLevelSave;
            attackSpeedLevel = _saveLocal.UpAttackSpeedLevelSave;
            shildLevel = _saveLocal.UpShildLevelSave;
            healPerLevelLevel = _saveLocal.UpHealPerLevelLevelSave;
            goldBonusLevel = _saveLocal.UpGoldBonusLevelSave;
            allPointsUpgrade = _saveLocal.allPointUpgrade;

        UstanovkaParametrov();
       // SetTextCoun();
        SetTextFly();
        SetPriceUpgrade();

    }
}

public class SaveLoadUpgradeMenu
{
    public int UpDamageLevelSave;
    public int UpHealsLevelSave;
    public int UpArmorLevelSave;
    public int UpMissLevelSave;
    public int UpCritChanceLevelSave;
    public int UpCritDamageLevelSave;
    public int UpAttackSpeedLevelSave;
    public int UpShildLevelSave;
    public int UpHealPerLevelLevelSave;
    public int UpGoldBonusLevelSave;

    public int allPointUpgrade;

}





