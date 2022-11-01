using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PanelUpgrade : MonoBehaviour
{
    public UpgradePersInMenu _upgradePersInMenu;
    public GameObject _panelUpgradeUpgrade;

    public float _timeDelay;
    public float _timeScroling;

    [Header("Кнопки улучшений")]
    public GameObject _iDamage;
    public GameObject _iHels;
    public GameObject _iArmor;
    public GameObject _iMiss;
    public GameObject _iCritChanse;
    public GameObject _iCritDamage;
    public GameObject _iAttacSpeed;
    public GameObject _iShild;
    public GameObject _iHelPerLevel;
    public GameObject _iBonusGold;
    [Header("Уровни улучшений")]
    public Text _tDamageLevel;
    public Text _tHelsLevel;
    public Text _tArmorLevel;
    public Text _tMissLevel;
    public Text _tCritCganseLevel;
    public Text _tCritDamageLevel;
    public Text _tAttacSpeedLevel;
    public Text _tShildLevel;
    public Text _tHelPerLevelLevel;
    public Text _tBonusGoldLevel;
    [Header("G.O. для активности")]
    public GameObject _gDamageAll;
    public GameObject _gHelsAll;
    public GameObject _gArmorAll;
    public GameObject _gMissAll;
    public GameObject _gCritCganseAll;
    public GameObject _gCritDamageAll;
    public GameObject _gAttacSpeedAll;
    public GameObject _gShildAll;
    public GameObject _gHelPerLevelAll;
    public GameObject _gBonusGoldAll;

    public GameObject _gDamagePerLevel;
    public GameObject _gHelsPerLevel;
    public GameObject _gArmorPerLevel;
    public GameObject _gMissPerLevel;
    public GameObject _gCritCgansePerLevel;
    public GameObject _gCritDamagePerLevel;
    public GameObject _gAttacSpeedPerLevel;
    public GameObject _gShildPerLevel;
    public GameObject _gHelPerLevelPerLevel;
    public GameObject _gBonusGoldPerLevel;


    [Header("Текущие параметры")]
    public Text _tDamageCount;
    public Text _tHelsCount;
    public Text _tArmorCount;
    public Text _tMissCount;
    public Text _tCritCganseCount;
    public Text _tCritDamageCount;
    public Text _tAttacSpeedCount;
    public Text _tShildCount;
    public Text _tHelPerLevelCount;
    public Text _tBonusGoldCount;
    [Header("Параметры за уровень")]
    public Text _tDamageCountPerLevel;
    public Text _tHelsCountPerLevel;
    public Text _tArmorCountPerLevel;
    public Text _tMissCountPerLevel;
    public Text _tCritCganseCountPerLevel;
    public Text _tCritDamageCountPerLevel;
    public Text _tAttacSpeedCountPerLevel;
    public Text _tShildCountPerLevel;
    public Text _tHelPerLevelCountPerLevel;
    public Text _tBonusGoldCountPerLevel;


    [Header("Для анимации увелечения уровня")]
    [SerializeField] private float _timeDelayLevel;
    [SerializeField] private float _scaleLevelText;
    [SerializeField] private float _timeDelayImage;
    [SerializeField] private float _timeDurationImage;
    [SerializeField] private Vector3 _rotateImage;
    [SerializeField] private Vector3 _startRotateimage;


    private void OnEnable()
    {
        _upgradePersInMenu.UpgradePersEvent += UpgradePersE;
    }

    private void OnDisable()
    {
        _upgradePersInMenu.UpgradePersEvent -= UpgradePersE;
    }

    private void UpgradePersE(int number)
    {
        _panelUpgradeUpgrade.SetActive(true);
        SetActivFalsAll();

        switch (number)
        {
            case 0:
                //SetParametr(_iDamage, _gDamageAll, _gDamagePerLevel, _tDamageLevel, _tDamageCount, _tDamageCountPerLevel);

                _iDamage.SetActive(true);
                _gDamageAll.SetActive(true);
                _gDamagePerLevel.SetActive(true);
                _tDamageLevel.text = (_upgradePersInMenu.damageLevel - 1).ToString();
                _tDamageCount.text = (_upgradePersInMenu.damage - _upgradePersInMenu.damagePerLevel).ToString();
                _tDamageCountPerLevel.text = "+" + _upgradePersInMenu.damagePerLevel.ToString();
                _tDamageCount.DOText(_upgradePersInMenu.damage.ToString(), _timeScroling, true, ScrambleMode.Numerals).SetDelay(_timeDelay);

                _tDamageLevel.DOText(_upgradePersInMenu.damageLevel.ToString(), 0, true, ScrambleMode.None).SetDelay(_timeDelayLevel);
                _tDamageLevel.GetComponent<RectTransform>().DOScale(_scaleLevelText, _timeDelayLevel);
                _tDamageLevel.GetComponent<RectTransform>().DOScale(1, 1).SetDelay(_timeDelayLevel);

                _iDamage.GetComponent<RectTransform>().DORotate(_rotateImage, _timeDurationImage,RotateMode.FastBeyond360).SetDelay(_timeDelayImage);
                _iDamage.GetComponent<RectTransform>().localScale = _startRotateimage;
                _iDamage.GetComponent<RectTransform>().DOScale(1, _timeDurationImage).SetDelay(_timeDelayImage);

                break;
            case 1:
                //SetParametr(_iHels, _gHelsAll, _gHelsPerLevel, _tHelsLevel, _tHelsCount, _tHelsCountPerLevel);

                _iHels.SetActive(true);
                _gHelsAll.SetActive(true);
                _gHelsPerLevel.SetActive(true);
                _tHelsLevel.text = (_upgradePersInMenu.healsLevel - 1).ToString();
                _tHelsCount.text = (_upgradePersInMenu.heals - _upgradePersInMenu.healsPerLevel).ToString();
                _tHelsCountPerLevel.text = "+" + _upgradePersInMenu.healsPerLevel.ToString();
                _tHelsCount.DOText(_upgradePersInMenu.heals.ToString(), _timeScroling, true, ScrambleMode.Numerals).SetDelay(_timeDelay);

                _tHelsLevel.DOText(_upgradePersInMenu.healsLevel.ToString(), 0, true, ScrambleMode.None).SetDelay(_timeDelayLevel);
                _tHelsLevel.GetComponent<RectTransform>().DOScale(_scaleLevelText, _timeDelayLevel);
                _tHelsLevel.GetComponent<RectTransform>().DOScale(1, 1).SetDelay(_timeDelayLevel);

                _iHels.GetComponent<RectTransform>().DORotate(_rotateImage, _timeDurationImage, RotateMode.FastBeyond360).SetDelay(_timeDelayImage);
                _iHels.GetComponent<RectTransform>().localScale = _startRotateimage;
                _iHels.GetComponent<RectTransform>().DOScale(1, _timeDurationImage).SetDelay(_timeDelayImage);
                break;
            case 2:
                //SetParametr(_iArmor, _gArmorAll, _gArmorPerLevel, _tArmorLevel, _tArmorCount, _tArmorCountPerLevel);

                _iArmor.SetActive(true);
                _gArmorAll.SetActive(true);
                _gArmorPerLevel.SetActive(true);
                _tArmorLevel.text = (_upgradePersInMenu.armorLevel - 1).ToString();
                _tArmorCount.text = (_upgradePersInMenu.armor - _upgradePersInMenu.armorPerLevel).ToString();
                _tArmorCountPerLevel.text = "+" + _upgradePersInMenu.armorPerLevel.ToString();
                _tArmorCount.DOText(_upgradePersInMenu.armor.ToString(), _timeScroling, true, ScrambleMode.Numerals).SetDelay(_timeDelay);

                _tArmorLevel.DOText(_upgradePersInMenu.armorLevel.ToString(), 0, true, ScrambleMode.None).SetDelay(_timeDelayLevel);
                _tArmorLevel.GetComponent<RectTransform>().DOScale(_scaleLevelText, _timeDelayLevel);
                _tArmorLevel.GetComponent<RectTransform>().DOScale(1, 1).SetDelay(_timeDelayLevel);

                _iArmor.GetComponent<RectTransform>().DORotate(_rotateImage, _timeDurationImage, RotateMode.FastBeyond360).SetDelay(_timeDelayImage);
                _iArmor.GetComponent<RectTransform>().localScale = _startRotateimage;
                _iArmor.GetComponent<RectTransform>().DOScale(1, _timeDurationImage).SetDelay(_timeDelayImage);
                break;
            case 3:
                //SetParametr(_iMiss, _gMissAll, _gMissPerLevel, _tMissLevel, _tMissCount, _tMissCountPerLevel);

                _iMiss.SetActive(true);
                _gMissAll.SetActive(true);
                _gMissPerLevel.SetActive(true);
                _tMissLevel.text = (_upgradePersInMenu.missLevel - 1).ToString();
                _tMissCount.text = (_upgradePersInMenu.miss - _upgradePersInMenu.missPerLevel).ToString() + "%";
                _tMissCountPerLevel.text = "+" + _upgradePersInMenu.missPerLevel.ToString() + "%";
                _tMissCount.DOText(_upgradePersInMenu.miss.ToString() + "%", _timeScroling, true, ScrambleMode.Numerals).SetDelay(_timeDelay);

                _tMissLevel.DOText(_upgradePersInMenu.missLevel.ToString(), 0, true, ScrambleMode.None).SetDelay(_timeDelayLevel);
                _tMissLevel.GetComponent<RectTransform>().DOScale(_scaleLevelText, _timeDelayLevel);
                _iMiss.GetComponent<RectTransform>().DOScale(1, 1).SetDelay(_timeDelayLevel);

                _iMiss.GetComponent<RectTransform>().DORotate(_rotateImage, _timeDurationImage, RotateMode.FastBeyond360).SetDelay(_timeDelayImage);
                _iMiss.GetComponent<RectTransform>().localScale = _startRotateimage;
                _iMiss.GetComponent<RectTransform>().DOScale(1, _timeDurationImage).SetDelay(_timeDelayImage);
                break;
            case 4:
                //SetParametr(_iCritChanse, _gCritCganseAll, _gCritCgansePerLevel, _tCritCganseLevel, _tCritCganseCount, _tCritCganseCountPerLevel);

                _iCritChanse.SetActive(true);
                _gCritCganseAll.SetActive(true);
                _gCritCgansePerLevel.SetActive(true);
                _tCritCganseLevel.text = (_upgradePersInMenu.critChanceLevel - 1).ToString();
                _tCritCganseCount.text = (_upgradePersInMenu.critChance - _upgradePersInMenu.critChancePerLevel).ToString() + "%";
                _tCritCganseCountPerLevel.text = "+" + _upgradePersInMenu.critChancePerLevel.ToString() + "%";
                _tCritCganseCount.DOText(_upgradePersInMenu.critChance.ToString() + "%", _timeScroling, true, ScrambleMode.Numerals).SetDelay(_timeDelay);

                _tCritCganseLevel.DOText(_upgradePersInMenu.critChanceLevel.ToString(), 0, true, ScrambleMode.None).SetDelay(_timeDelayLevel);
                _tCritCganseLevel.GetComponent<RectTransform>().DOScale(_scaleLevelText, _timeDelayLevel);
                _tCritCganseLevel.GetComponent<RectTransform>().DOScale(1, 1).SetDelay(_timeDelayLevel);

                _iCritChanse.GetComponent<RectTransform>().DORotate(_rotateImage, _timeDurationImage, RotateMode.FastBeyond360).SetDelay(_timeDelayImage);
                _iCritChanse.GetComponent<RectTransform>().localScale = _startRotateimage;
                _iCritChanse.GetComponent<RectTransform>().DOScale(1, _timeDurationImage).SetDelay(_timeDelayImage);
                break;
            case 5:
                // SetParametr(_iCritDamage, _gCritDamageAll, _gCritDamagePerLevel, _tCritDamageLevel, _tCritDamageCount, _tCritDamageCountPerLevel);

                _iCritDamage.SetActive(true);
                _gCritDamageAll.SetActive(true);
                _gCritDamagePerLevel.SetActive(true);
                _tCritDamageLevel.text = (_upgradePersInMenu.critDamageLevel - 1).ToString();
                _tCritDamageCount.text = (_upgradePersInMenu.critDamage - _upgradePersInMenu.critDamagePerLevel).ToString() + "%";
                _tCritDamageCountPerLevel.text = "+" + _upgradePersInMenu.critDamagePerLevel.ToString() + "%";
                _tCritDamageCount.DOText(_upgradePersInMenu.critDamage.ToString() + "%", _timeScroling, true, ScrambleMode.Numerals).SetDelay(_timeDelay);

                _tCritDamageLevel.DOText(_upgradePersInMenu.critDamageLevel.ToString(), 0, true, ScrambleMode.None).SetDelay(_timeDelayLevel);
                _tCritDamageLevel.GetComponent<RectTransform>().DOScale(_scaleLevelText, _timeDelayLevel);
                _tCritDamageLevel.GetComponent<RectTransform>().DOScale(1, 1).SetDelay(_timeDelayLevel);

                _iCritDamage.GetComponent<RectTransform>().DORotate(_rotateImage, _timeDurationImage, RotateMode.FastBeyond360).SetDelay(_timeDelayImage);
                _iCritDamage.GetComponent<RectTransform>().localScale = _startRotateimage;
                _iCritDamage.GetComponent<RectTransform>().DOScale(1, _timeDurationImage).SetDelay(_timeDelayImage);
                break;
            case 6:
                //SetParametr(_iAttacSpeed, _gAttacSpeedAll, _gAttacSpeedPerLevel, _tAttacSpeedLevel, _tAttacSpeedCount, _tAttacSpeedCountPerLevel);

                _iAttacSpeed.SetActive(true);
                _gAttacSpeedAll.SetActive(true);
                _gAttacSpeedPerLevel.SetActive(true);
                _tAttacSpeedLevel.text = (_upgradePersInMenu.attackSpeedLevel - 1).ToString();
                _tAttacSpeedCount.text = (_upgradePersInMenu.attackSpeed - _upgradePersInMenu.attackSpeedPerLevel).ToString() + "%";
                _tAttacSpeedCountPerLevel.text = "+" + _upgradePersInMenu.attackSpeedPerLevel.ToString() + "%";
                _tAttacSpeedCount.DOText(_upgradePersInMenu.attackSpeed.ToString() + "%", _timeScroling, true, ScrambleMode.Numerals).SetDelay(_timeDelay);

                _tAttacSpeedLevel.DOText(_upgradePersInMenu.attackSpeedLevel.ToString(), 0, true, ScrambleMode.None).SetDelay(_timeDelayLevel);
                _tAttacSpeedLevel.GetComponent<RectTransform>().DOScale(_scaleLevelText, _timeDelayLevel);
                _tAttacSpeedLevel.GetComponent<RectTransform>().DOScale(1, 1).SetDelay(_timeDelayLevel);

                _iAttacSpeed.GetComponent<RectTransform>().DORotate(_rotateImage, _timeDurationImage, RotateMode.FastBeyond360).SetDelay(_timeDelayImage);
                _iAttacSpeed.GetComponent<RectTransform>().localScale = _startRotateimage;
                _iAttacSpeed.GetComponent<RectTransform>().DOScale(1, _timeDurationImage).SetDelay(_timeDelayImage);
                break;
            case 7:
                //SetParametr(_iShild, _gShildAll, _gShildPerLevel, _tShildLevel, _tShildCount, _tShildCountPerLevel);

                _iShild.SetActive(true);
                _gShildAll.SetActive(true);
                _gShildPerLevel.SetActive(true);
                _tShildLevel.text = (_upgradePersInMenu.shildLevel - 1).ToString();
                _tShildCount.text = (_upgradePersInMenu.shild - _upgradePersInMenu.shildPerLevel).ToString();
                _tShildCountPerLevel.text = "+" + _upgradePersInMenu.shildPerLevel.ToString();
                _tShildCount.DOText(_upgradePersInMenu.shild.ToString(), _timeScroling, true, ScrambleMode.Numerals).SetDelay(_timeDelay);

                _tShildLevel.DOText(_upgradePersInMenu.shildLevel.ToString(), 0, true, ScrambleMode.None).SetDelay(_timeDelayLevel);
                _tShildLevel.GetComponent<RectTransform>().DOScale(_scaleLevelText, _timeDelayLevel);
                _tShildLevel.GetComponent<RectTransform>().DOScale(1, 1).SetDelay(_timeDelayLevel);

                _iShild.GetComponent<RectTransform>().DORotate(_rotateImage, _timeDurationImage, RotateMode.FastBeyond360).SetDelay(_timeDelayImage);
                _iShild.GetComponent<RectTransform>().localScale = _startRotateimage;
                _iShild.GetComponent<RectTransform>().DOScale(1, _timeDurationImage).SetDelay(_timeDelayImage);
                break;
            case 8:
               // SetParametr(_iHelPerLevel, _gHelPerLevelAll, _gHelPerLevelPerLevel, _tHelPerLevelLevel, _tHelPerLevelCount, _tHelPerLevelCountPerLevel);

                _iHelPerLevel.SetActive(true);
                _gHelPerLevelAll.SetActive(true);
                _gHelPerLevelPerLevel.SetActive(true);
                _tHelPerLevelLevel.text = (_upgradePersInMenu.healPerLevelLevel - 1).ToString();
                _tHelPerLevelCount.text = (_upgradePersInMenu.healPesLevel - _upgradePersInMenu.healPerLevelPerLevel).ToString();
                _tHelPerLevelCountPerLevel.text = "+" + _upgradePersInMenu.healPerLevelPerLevel.ToString();
                _tHelPerLevelCount.DOText(_upgradePersInMenu.healPesLevel.ToString(), _timeScroling, true, ScrambleMode.Numerals).SetDelay(_timeDelay);

                _tHelPerLevelLevel.DOText(_upgradePersInMenu.healPerLevelLevel.ToString(), 0, true, ScrambleMode.None).SetDelay(_timeDelayLevel);
                _tHelPerLevelLevel.GetComponent<RectTransform>().DOScale(_scaleLevelText, _timeDelayLevel);
                _tHelPerLevelLevel.GetComponent<RectTransform>().DOScale(1, 1).SetDelay(_timeDelayLevel);

                _iHelPerLevel.GetComponent<RectTransform>().DORotate(_rotateImage, _timeDurationImage, RotateMode.FastBeyond360).SetDelay(_timeDelayImage);
                _iHelPerLevel.GetComponent<RectTransform>().localScale = _startRotateimage;
                _iHelPerLevel.GetComponent<RectTransform>().DOScale(1, _timeDurationImage).SetDelay(_timeDelayImage);
                break;
            case 9:
                //SetParametr(_iBonusGold, _gBonusGoldAll, _gBonusGoldPerLevel, _tBonusGoldLevel, _tBonusGoldCount, _tBonusGoldCountPerLevel);

                _iBonusGold.SetActive(true);
                _gBonusGoldAll.SetActive(true);
                _gBonusGoldPerLevel.SetActive(true);
                _tBonusGoldLevel.text = (_upgradePersInMenu.goldBonusLevel - 1).ToString();
                _tBonusGoldCount.text = (_upgradePersInMenu.goldBonus - _upgradePersInMenu.goldBonusPerLevel).ToString() + "%";
                _tBonusGoldCountPerLevel.text = "+" + _upgradePersInMenu.goldBonusPerLevel.ToString() + "%";
                _tBonusGoldCount.DOText(_upgradePersInMenu.goldBonus.ToString() + "%", _timeScroling, true, ScrambleMode.Numerals).SetDelay(_timeDelay);

                _tBonusGoldLevel.DOText(_upgradePersInMenu.goldBonusLevel.ToString(), 0, true, ScrambleMode.None).SetDelay(_timeDelayLevel);
                _tBonusGoldLevel.GetComponent<RectTransform>().DOScale(_scaleLevelText, _timeDelayLevel);
                _tBonusGoldLevel.GetComponent<RectTransform>().DOScale(1, 1).SetDelay(_timeDelayLevel);

                _iBonusGold.GetComponent<RectTransform>().DORotate(_rotateImage, _timeDurationImage, RotateMode.FastBeyond360).SetDelay(_timeDelayImage);
                _iBonusGold.GetComponent<RectTransform>().localScale = _startRotateimage;
                _iBonusGold.GetComponent<RectTransform>().DOScale(1, _timeDurationImage).SetDelay(_timeDelayImage);
                break;

            default:
                break;
        }
    }

    public void SetParametr(GameObject iBonus,GameObject gBonusAll,GameObject GbonusPerLevel,Text tBonusLevel,Text tBonusCount,Text tBonusCountPerLevel)
    {
        iBonus.SetActive(true);
        gBonusAll.SetActive(true);
        GbonusPerLevel.SetActive(true);
        tBonusLevel.text = (_upgradePersInMenu.goldBonusLevel - 1).ToString();
        tBonusCount.text = (_upgradePersInMenu.goldBonus - _upgradePersInMenu.goldBonusPerLevel).ToString() + "%";
        tBonusCountPerLevel.text = "+" + _upgradePersInMenu.goldBonusPerLevel.ToString() + "%";
        tBonusCount.DOText(_upgradePersInMenu.goldBonus.ToString() + "%", _timeScroling, true, ScrambleMode.Numerals).SetDelay(_timeDelay);

        tBonusLevel.DOText(_upgradePersInMenu.damageLevel.ToString(), 3, true, ScrambleMode.None);
        tBonusLevel.GetComponent<RectTransform>().DOScale(3, 3);
        tBonusLevel.GetComponent<RectTransform>().DOScale(1, 1).SetDelay(3);
    }

    private void SetActivFalsAll()
    {
        _iDamage.SetActive(false);
        _iHels.SetActive(false);
        _iArmor.SetActive(false);
        _iMiss.SetActive(false);
        _iCritChanse.SetActive(false);
        _iCritDamage.SetActive(false);
        _iAttacSpeed.SetActive(false);
        _iShild.SetActive(false);
        _iHelPerLevel.SetActive(false);
        _iBonusGold.SetActive(false);

        _gDamageAll.SetActive(false);
        _gHelsAll.SetActive(false);
        _gArmorAll.SetActive(false);
        _gMissAll.SetActive(false);
        _gCritCganseAll.SetActive(false);
        _gCritDamageAll.SetActive(false);
        _gAttacSpeedAll.SetActive(false);
        _gShildAll.SetActive(false);
        _gHelPerLevelAll.SetActive(false);
        _gBonusGoldAll.SetActive(false);

        _gDamagePerLevel.SetActive(false);
        _gHelsPerLevel.SetActive(false);
        _gArmorPerLevel.SetActive(false);
        _gMissPerLevel.SetActive(false);
        _gCritCgansePerLevel.SetActive(false);
        _gCritDamagePerLevel.SetActive(false);
        _gAttacSpeedPerLevel.SetActive(false);
        _gShildPerLevel.SetActive(false);
        _gHelPerLevelPerLevel.SetActive(false);
        _gBonusGoldPerLevel.SetActive(false);
    }

   public void ClosePanel()
    {
        _panelUpgradeUpgrade.SetActive(false);
    }
}
