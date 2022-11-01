using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickButtonUpgradeIsTextFly : MonoBehaviour
{
    

    public GameObject goFly;
    public Coroutine rutine;
    //public GameObject _iTriangle;
    public float timeFlyText;

    

    


    



    public void Click()
    {

        if (goFly.activeSelf == true)
        {
            StopCoroutine(rutine);
            rutine = null;
            goFly.SetActive(false);
           // _iTriangle.SetActive(false);
        }
        else
        {
            goFly.SetActive(true);
           //_iTriangle.SetActive(true);
            rutine = StartCoroutine(SetActivTextFleFalse());
        }



    }
    public IEnumerator SetActivTextFleFalse()
    {
        yield return new WaitForSecondsRealtime(timeFlyText);
        goFly.SetActive(false);
       // _iTriangle.SetActive(false);


    }
}
