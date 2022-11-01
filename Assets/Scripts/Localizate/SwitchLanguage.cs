using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SwitchLanguage : MonoBehaviour
{
    [Inject]
    public Example _example;
   

    public void SwitcLanguagee(string language)
    {
        _example.SetLocalization(language);
        _example.ReloadScene();
    }
}
