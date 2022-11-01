using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PartButton : MonoBehaviour
{
    public GameObject goFly;
    public Coroutine rutine;
    public GameObject _iTriangle;
    public float timeFlyText;


    public void Click()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (gameObject.transform.localPosition.x >= 275)
            {
                //goFly.transform.localPosition = new Vector3(-150f, 250f, 0f);
                goFly.transform.localPosition = new Vector3(-150f, 140f, 0f);
                Debug.Log("PartButton");
            }
        }

        if (goFly.activeSelf == true)
        {
            StopCoroutine(rutine);
            rutine = null;
            goFly.SetActive(false);
            _iTriangle.SetActive(false);
        }
        else
        {
            goFly.SetActive(true);
            _iTriangle.SetActive(true);
            rutine =  StartCoroutine(SetActivTextFleFalse());
        }


        
    }
    public IEnumerator SetActivTextFleFalse()
    {
        yield return new WaitForSecondsRealtime(timeFlyText);
        goFly.SetActive(false);
        _iTriangle.SetActive(false);


    }
    

}
