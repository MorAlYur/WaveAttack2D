using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellWindow : MonoBehaviour
{
    public Inventary _inventary;
    public UIViborItemPanel _uiViborItemPanel;
    public GameObject _panelSell;
    public Image _sellImageItem;
    public Text _tPrise;
    public Text _tItemName;

    public void OpenWindowSell()
    {
        _panelSell.SetActive(true);
        _sellImageItem.sprite = _uiViborItemPanel.image.sprite;
        _tPrise.text = _uiViborItemPanel.saleText.ToString();
        _tItemName.text = _uiViborItemPanel.itemName.text;
    }

    public void Sell()
    {
        
        _inventary.SellItem();
        _inventary.CloseWindowSell();
    }
    public void ClosePanel()
    {
        _panelSell.SetActive(false);
    }
    
}
