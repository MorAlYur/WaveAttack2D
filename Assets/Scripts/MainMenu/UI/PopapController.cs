using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopapController : MonoBehaviour
{
    public CanvasGroup _popupGame;
    public CanvasGroup _popupItem;
    public CanvasGroup _popupUpgrade;
    public CanvasGroup _popupShop;
    public CanvasGroup _popupOptions;

    public Button _bGame;
    public Button _bInventaru;
    public Button _bUpgrade;
    public Button _bShop;
    public Button _bOptions;

   

    private void Awake()
    {
        Time.timeScale = 1f;
    }

    void Start()
    {
        StartCoroutine(StartGame());
        
    }
    IEnumerator StartGame()
    {
        yield return null;
        SetPopap(_popupGame);
        _bGame.interactable = false;
    }
    public void SetPopap(CanvasGroup canvasPopup)
    {
        AllDeaktivate();
        ActivatePopup(canvasPopup);
        if (canvasPopup == _popupGame)
        {
            SetInteractadleButoonMenu(_bGame);
        }
        else if(canvasPopup == _popupItem)
        {
            SetInteractadleButoonMenu(_bInventaru);
        }
        else if (canvasPopup == _popupUpgrade)
        {
            SetInteractadleButoonMenu(_bUpgrade);
        }
        else if (canvasPopup == _popupShop)
        {
            SetInteractadleButoonMenu(_bShop);
        }
        else if (canvasPopup == _popupOptions)
        {
            SetInteractadleButoonMenu(_bOptions);
        }
    }
    public void ActivatePopup(CanvasGroup canvasPopup)
    {
        canvasPopup.alpha = 1f;
        canvasPopup.blocksRaycasts = true;
        canvasPopup.interactable = true;
    }
    public void SetInteractadleButoonMenu(Button button)
    {
        button.interactable = false;
    }
    public void DeaktivatePopup(CanvasGroup canvasPopup)
    {
        canvasPopup.alpha = 0;
        canvasPopup.blocksRaycasts = false;
        canvasPopup.interactable = false;
    }
    public void AllDeaktivate()
    {
        DeaktivatePopup(_popupGame);
        DeaktivatePopup(_popupItem);
        DeaktivatePopup(_popupUpgrade);
        DeaktivatePopup(_popupShop);
        DeaktivatePopup(_popupOptions);

        _bGame.interactable = true;
        _bInventaru.interactable = true;
        _bUpgrade.interactable = true;
        _bShop.interactable = true;
        _bOptions.interactable = true;

    }
}
