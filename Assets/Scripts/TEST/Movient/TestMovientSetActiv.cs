using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovientSetActiv : MonoBehaviour
{
    public GameObject _menu;

    public void Activate_DeactivateMenu()
    {
        if (_menu.activeSelf == true)
        {
            _menu.SetActive(false);
        }
        else
        {
            _menu.SetActive(true);
        }
    }
}
