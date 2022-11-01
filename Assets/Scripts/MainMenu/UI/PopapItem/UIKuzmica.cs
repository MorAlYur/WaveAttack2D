using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIKuzmica : MonoBehaviour
{
    public Inventary inventary;
    public Animator animator;
    public Kuznica _kuznica;

    public GameObject kuznjaPanel;

    public Button _BKuznica;
    public Button _BEqiperovka;


    private void Start()
    {
        _BEqiperovka.interactable = false;
    }

    private void OnEnable()
    {
        inventary.KuznicaActivEvent += KuznicaActivOn; 
    }

    

    private void OnDisable()
    {
        inventary.KuznicaActivEvent -= KuznicaActivOn;
    }
    private void KuznicaActivOn()
    {
        kuznjaPanel.SetActive(true);
        _BKuznica.interactable = false;
        _BEqiperovka.interactable = true;
    }
    public void ClosePanelKuznjaIsAnimation()
    {
        _kuznica.ResetKuznicaItem();
        inventary.IsYesIneracableItem();
        inventary.NadetVseItems();
        animator.SetTrigger("CloseKuznicaTriger");
        inventary.isKuznjaActive = false;
        _BEqiperovka.interactable = false;
        _BKuznica.interactable = true;
    }

   
}
