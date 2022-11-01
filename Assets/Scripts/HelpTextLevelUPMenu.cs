using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Experimental.GlobalIllumination;

public class HelpTextLevelUPMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text _tHelp1;
    [SerializeField] private TMP_Text _tHelp2;
    [SerializeField] private TMP_Text _tHelp3;
    [SerializeField] private GameObject _panelHelp;
    [SerializeField] private GameObject _bQestion;
    [SerializeField] private LevelUpMenu _levelUpMenu;

    public void ActivButtonQestion()
    {
        _bQestion.SetActive(true);
    }
    public void HideButtonQestion()
    {
        _bQestion.SetActive(false);
    }
    public void HideAll()
    {
        HideButtonQestion();
        HidePanelHelp();
    }
    public void HidePanelHelp()
    {
        _panelHelp.SetActive(false);
    }
    public void HelpQestionPressed()
    {
        if (_panelHelp.activeSelf)
        {
            HidePanelHelp();
        }
        else
        {
            IsVisiblePanel();
            SetTextHelp();
        }
    }
    private void IsVisiblePanel()
    {
        _panelHelp.SetActive(true);
    }
    private void SetTextHelp()
    {
        _tHelp1.text = LocalizationManager.Localize(_levelUpMenu.bonusAvailable[_levelUpMenu.vibraniBonus[0]].
                                                      GetComponent<SkilSpecification>()._fullSpecification);
        _tHelp2.text = LocalizationManager.Localize(_levelUpMenu.bonusAvailable[_levelUpMenu.vibraniBonus[1]].
                                                      GetComponent<SkilSpecification>()._fullSpecification);
        _tHelp3.text = LocalizationManager.Localize(_levelUpMenu.bonusAvailable[_levelUpMenu.vibraniBonus[2]].
                                                      GetComponent<SkilSpecification>()._fullSpecification);
    }

}
