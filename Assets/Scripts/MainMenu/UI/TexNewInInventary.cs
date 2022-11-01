using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TexNewInInventary : MonoBehaviour
{
    public GameObject TexNew;
    [Inject]
    private Saver _saver;
    
    void Start()
    {
        Chek();
    }

    public void Chek()
    {
        if (_saver.GetNewItemInInventary())
        {
            SetTexNewTrue();
        }
        else
        {
            SetTexNewFalse();
        }
    }
    public void SetTexNewTrue()
    {
        TexNew.SetActive(true);
        _saver.SetNewItemInInventary(true);
    }
    
        public void SetTexNewFalse()
    {
        TexNew.SetActive(false);
        _saver.SetNewItemInInventary(false);

    }
}
