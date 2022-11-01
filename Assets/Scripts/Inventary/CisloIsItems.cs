using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CisloIsItems
{
    public static int cislo;

    public static int NextCislo()
    {
        if (PlayerPrefs.HasKey("A"))
        {
           cislo =  PlayerPrefs.GetInt("A");
        }
       
        return cislo++;
       
    }
    public static void Save()
    {
        PlayerPrefs.SetInt("A", cislo);
    }

}
