using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class SkilSpecification : MonoBehaviour
{
    public string _shortSpecification;
    public string _fullSpecification;
    public bool isOpen { get; private set; }

    public LevelTextExplain _levelTextExplain;
    public MenuPauza _menuPauza;

    public void SetTextExp()
    {
        _levelTextExplain.ActivateBonText(LocalizationManager.Localize(_shortSpecification), LocalizationManager.Localize(_fullSpecification));
        _menuPauza.Activate(gameObject.GetComponent<Image>(), LocalizationManager.Localize(_shortSpecification),
                                                              LocalizationManager.Localize(_fullSpecification));
    }
     
}
