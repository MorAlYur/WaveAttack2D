using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class MenuPauza : MonoBehaviour
{
    [SerializeField] private Transform _goPaternSkils;
    [SerializeField] private SkillToPauza _prefabActivSkill;
    [SerializeField] private CanvasGroup _menuPauzaCanvas;
    [SerializeField] private GameObject _exitConfirmGO;
    [SerializeField] private RewardInLevel _rewardInLevel;

    public void StartPauza()
    {
        _menuPauzaCanvas.alpha = 1;
        _menuPauzaCanvas.blocksRaycasts = true;
        Time.timeScale = 0;
    }
    public void StopPauza()
    {
        _menuPauzaCanvas.alpha = 0;
        _menuPauzaCanvas.blocksRaycasts = false;
        Time.timeScale = 1;
    }
    public void GoTOMenu()
    {
        _exitConfirmGO.SetActive(true);
    }
    public void ExitConfirmYes()
    {
        _rewardInLevel.GoTOMenu();
    }
    public void ExitConfirmNo()
    {
        _exitConfirmGO.SetActive(false);
    }
        


    public void Activate(Image imagee,string shortSpecification, string fullSpecification)
    {
        var obj = Instantiate(_prefabActivSkill,_goPaternSkils);
        obj.SetImage(imagee);
        obj.SetOpisanie(shortSpecification, fullSpecification);
    }
    

    
}
