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
    public CanvasGroup _popupHeroes;

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
    }
    public void SetPopap(CanvasGroup canvasPopup)
    {
        AllDeaktivate();
        ActivatePopup(canvasPopup);
    }
    public void ActivatePopup(CanvasGroup canvasPopup)
    {
        canvasPopup.alpha = 1f;
        canvasPopup.blocksRaycasts = true;
        canvasPopup.interactable = true;
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
        DeaktivatePopup(_popupHeroes);
    }
}
