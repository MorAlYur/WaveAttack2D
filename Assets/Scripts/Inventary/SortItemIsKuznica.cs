using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SortItemIsKuznica : MonoBehaviour
{
    public Inventary _inventary;
    [Inject]
    public ItemSingolton _itemSingolton;
    public List<Item> _allItems;
    public List<Item> _items;
    public int[] count;
    public int[] id;
    public bool IsSort;

    [Header("для надписи new")]
    public int[] _countNew;
    public GameObject _tNew;
    void Start()
    {
        CoppyList();
        SetActivSeslTexNewKuznica();
    }
    public void CoppyList()
    {
        foreach (var item in _itemSingolton.allitems)
        {
            _allItems.Add(item);

        }
        count = new int[_allItems.Count];
        _countNew = new int[_allItems.Count];
        id = new int[_allItems.Count];
        var i = 0;
        foreach (var it in _allItems)
        {
            
            id[i] = it.id;
            i++;
        }

    }

    public void sort()
    {
        IsSort = false;

        for (int i = 0; i < count.Length; i++)
        {
            count[i] = 0;
        }

        foreach (var item in _inventary._inventary)
        {
            _items.Add(item);

        }


        
        foreach (var item in _items)
        {
            for (int i = 0; i < id.Length; i++)
            {
               
                if(id[i]== item.id)
                {
                    
                    count[i]=count[i]+1;
                    
                }
            }
        }
        for (int i = 0; i < count.Length; i++)
        {
           
            if (count[i] >= 3)
            {
               
                _inventary.SortMasiv(id[i], true);
                IsSort = true;
               
            }
        }
        if (!IsSort)
        {
            _inventary.SortMasiv();
           
        }
        _items.Clear();


    }
    public void SetActivSeslTexNewKuznica()
    {
        _tNew.SetActive(GetActiveTextNew());
    }
    public bool GetActiveTextNew()
    {
        for (int i = 0; i < _countNew.Length; i++)
        {
            _countNew[i] = 0;
        }

        foreach (var item in _inventary._inventary)
        {
            for (int i = 0; i < id.Length; i++)
            {

                if (id[i] == item.id)
                {

                    _countNew[i] = _countNew[i] + 1;

                }
            }
        }
        for (int i = 0; i < _countNew.Length; i++)
        {
            if (_countNew[i] >= 3)
            {
                return true;
            }
            
        }
        return false;

    }
     
}
