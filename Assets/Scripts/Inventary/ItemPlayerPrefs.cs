using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlayerPrefs : MonoBehaviour
{
    public event Action newItemPPEvent;
    public int c;
    public void IsPlayerPrefsIsEists()
    {
        if (!PlayerPrefs.HasKey("item"))
        {
            PlayerPrefs.SetInt("item",1);
            PlayerPrefs.SetInt("i0",0);
            PlayerPrefs.SetInt("i1",0);
            PlayerPrefs.SetInt("i2",0);
            PlayerPrefs.SetInt("i3",0);
            PlayerPrefs.SetInt("i4",0);
            PlayerPrefs.SetInt("i5",0);
            PlayerPrefs.SetInt("i6",0);
            PlayerPrefs.SetInt("i7",0);
            PlayerPrefs.SetInt("i8",0);
            PlayerPrefs.SetInt("i9",0);
            PlayerPrefs.SetInt("i10",0);
            PlayerPrefs.SetInt("i11",0);
            PlayerPrefs.SetInt("i12",0);
            PlayerPrefs.SetInt("i13",0);
            PlayerPrefs.SetInt("i14",0);
            PlayerPrefs.SetInt("i15",0);
            PlayerPrefs.SetInt("i16",0);
            PlayerPrefs.SetInt("i17",0);
            PlayerPrefs.SetInt("i18",0);
            PlayerPrefs.SetInt("i19",0);
            PlayerPrefs.SetInt("i20",0);
        }
    }

    public bool ChekItemPP()
    {
        c = PlayerPrefs.GetInt("i0");
        if (PlayerPrefs.GetInt("i0") == 0)
        {
            
            return false;
        }
        else
            return true;
       
    }
    public int GetFirstNullIndex()
    {
        for (int i = 0; i < 1000; i++)
        {
            if (PlayerPrefs.GetInt($"i{i}") == 0)
            {
                return i;
            }
        }
        return 0;
    }
    public void SetIdItemPlayerPrefs(int id)
    {
        PlayerPrefs.SetInt($"i{GetFirstNullIndex()}", id);
        newItemPPEvent?.Invoke();
       
    }
}
