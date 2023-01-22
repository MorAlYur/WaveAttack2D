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

    [SerializeField] private GridLayoutGroup _gridLayoutGroup; 

    private int _countActivSkill;

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

    public void SetSkillInMenuPauza(Sprite imageSkill ,string shortSpecification,string fullSpeification)
    {
        var go = Instantiate(_prefabActivSkill, _goPaternSkils);
        go.SetImage(imageSkill);
        go.SetOpisanie(shortSpecification, fullSpeification);
        _countActivSkill++;
        if (_countActivSkill > 18)
        {
            SetSizeGridLayoutGroup();
        }
    }
    private void SetSizeGridLayoutGroup()
    {
        _gridLayoutGroup.cellSize = new Vector2(150, 150);
    }


}
