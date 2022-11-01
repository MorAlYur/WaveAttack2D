using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kuznica : MonoBehaviour
{
   

    public Inventary inventary;
    public SortItemIsKuznica _sortItemIsKuznica;
    public WindowUpgradKachestvo _windowUpgradKachestvo;


    public int _id;
    public int level=1;

    public Transform TItem1;
    public Transform TItem2;
    public Transform TItem3;

    public Transform TInventary;

    public Item _item1;
    public Item _item2;
    public Item _item3;
    [Header("Êíîïêè")]
    public GameObject resetButton;
    public GameObject uniteButton;

    public Item.Mesto _mesto;
    public bool _isActivItem;

    public void OnEnable()
    {
       // Item.NoviiEvent += Item_NoviiEvent;
       
    }

    

    public void OnDisable()
    {
       // Item.NoviiEvent -= Item_NoviiEvent;
        
    }


    public void Item_NoviiEvent(Item item)
    {
        _id = item.id;
        if (inventary.isKuznjaActive == false)
        {
            return;
        }
        if(item.kacestvo == Item.Kacestvo.legendary)
        {
            return;
        }
        if (_item1 == null)
        {
            _mesto = item.mesto;
            _item1 = item;
            level = _item1.level;
            _item1.transform.SetParent(TItem1);
            inventary.IsNoIneracableItem(item.id);
            resetButton.SetActive(true);
        }
        else if (_item2 == null)
        {
            if (item == _item1)
                return;
            _item2 = item;
            if (_item2.level > level)
            {
                level = _item2.level;
            }
            _item2.transform.SetParent(TItem2);
        }
        else if (_item3 == null)
        {
            if (item == _item1||item==_item2)
                return;
            _item3 = item;
            if (_item3.level > level)
            {
                level = _item3.level;
            }
            _item3.transform.SetParent(TItem3);
            IsActivItem();
            ProverkaItemsIsKuznica();

        }
    }

    public void ResetKuznicaItem()
    {
        if (_item1 != null)
        {
            _item1.transform.SetParent(TInventary);
        }
       if (_item2 != null)
        {
            _item2.transform.SetParent(TInventary);
        }
       if (_item3 != null)
        {
            _item3.transform.SetParent(TInventary);
           
        }
       
        _item1 = null;
        _item2 = null;
        _item3 = null;
        _isActivItem = false;
        inventary.IsYesIneracableItem();
        _sortItemIsKuznica.sort(); 
        resetButton.SetActive(false);
        uniteButton.SetActive(false);

    }
    public void IsActivItem()
    {
        if(_item1.isActiv==true|| _item2.isActiv == true || _item3.isActiv == true)
        {
            _isActivItem = true;
        }
        else
        {
            _isActivItem = false;
        }
    }

    
    public void ProverkaItemsIsKuznica()
    {
        if (_item1.id == _item2.id &&_item1.id == _item3.id&&_item1.kacestvo!=Item.Kacestvo.legendary)
        {
            uniteButton.SetActive(true);
        }
    }
    public void UniteItemsKuznica()
    {
              
        _windowUpgradKachestvo.OpenWindow();
       
        inventary.RemoteItemIsKuznja(_item1);
        inventary.RemoteItemIsKuznja(_item2);
        inventary.RemoteItemIsKuznja(_item3);
        _item1 = null;
        _item2 = null;
        _item3 = null;
        inventary.AddItem(_id + 100, level, _isActivItem);
        ResetKuznicaItem();
        inventary.AllStats();
        

    }

}
