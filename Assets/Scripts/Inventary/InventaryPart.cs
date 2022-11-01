using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class InventaryPart : MonoBehaviour
{
    public List<PartInfo> Part;



    public Inventary _inventary;
    [Inject]
    public Saver _saver;
    public UIViborItemPanel _uiViborItemPanel;
    [Header("Disassemble")]
    public GameObject _panelAnticlicketDiss;
    

    public Image _imageItem;
    public Text _tName; 
    public Text _tCountPart;
    public int _countReward;

    [Header("Количество частей для улучшения в зависимости от уровня")]
    public int _count_0_9;
    public int _count_10_19;
    public int _count_20_29;
    public int _count_30_39;
    public int _count_40_Infinity;


   public void DisassemblePart()
    {
        
        _panelAnticlicketDiss.SetActive(true);
        _imageItem.sprite = _uiViborItemPanel.image.sprite;
        _tName.text = _uiViborItemPanel.itemName.text;
        _countReward = SwitherKacestvoItem();
        _tCountPart.text = _countReward.ToString();
        


    }
    public void CloseDisassemlePart()
    {
        _panelAnticlicketDiss.SetActive(false);
    }
    public int SwitherKacestvoItem()
    {
        switch (_inventary._item.kacestvo)
        {
            case Item.Kacestvo.normal:
                return 10;
            case Item.Kacestvo.uncommon:
                return 20;
            case Item.Kacestvo.unusual:
                return 30;
            case Item.Kacestvo.epic:
                return 40;
            case Item.Kacestvo.legendary:
                return 50;

            default:
                return 0;
        } 
    }
   

    public void SetCount(int id,int count)
    {
        foreach (var part in Part)
        {
            if (part.ID == id)
            {
                part.SetCount(part.Count + count);
                part.SetTextCount();
                part.SetTextCount();
                if (part.Count == 0)
                {
                    part.gameObject.SetActive(false);
                }
                else
                {
                    part.gameObject.SetActive(true);

                }
            }
        }
        SavePart();
    }
    public void SetCount(int id)
    {
        foreach (var part in Part)
        {
            if (part.ID == id)
            {
                part.SetCount(part.Count + 1);
                part.SetTextCount();
                if (part.Count == 0)
                {
                    part.gameObject.SetActive(false);
                }
                else
                {
                    part.gameObject.SetActive(true);

                }
            }
        }
        SavePart();
    }
    public int GetCount(int id)
    {
        foreach (var part in Part)
        {
            if (part.ID == id)
            {
                return part.Count;
            }
            
        }
        return 0;
    }
    public Image GetImage(int id)
    {
        foreach (var part in Part)
        {
            if (part.ID == id)
            {
                return part.GetComponent<Image>();
            }

        }
        return null;
    }
    
    public void SetActiveAllPart()
    {
        foreach (var part in Part)
        {
            if (part.Count == 0)
            {
                part.gameObject.SetActive(false);
            }
            else
                part.gameObject.SetActive(true);
        }
    }

    public int GetCountPartPerLevel(int level)
    {
        if (level< 10)
        {
            return _count_0_9;
        }
        else if (level >= 10 && level < 20)
        {
            return _count_10_19;
        }
        else if (level >= 20 && level < 30)
        {
            return _count_20_29;
        }
        else if (level >= 30 && level < 40)
        {
            return _count_30_39;
        }
        else 
        {
            return _count_40_Infinity;
        }

    }
    public void SavePart()
    {
        _saver.SavaDataPartAll(Part);
    }
    public void LoadPart()
    {
        var partList = _saver.LoadDataPart();
        foreach (var part in Part)
        {
            foreach (var partSave in partList)
            {
                if(part.ID == partSave.id)
                {
                    part.SetCount(partSave.count);
                    part.SetTextCount();
                }
            }
        }
        SetActiveAllPart();

    }
}

