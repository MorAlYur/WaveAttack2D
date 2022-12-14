using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillToPauza : MonoBehaviour
{
    [SerializeField] private Image _iSkil;
    [SerializeField] private TextMeshProUGUI _shortSpecification;
    [SerializeField] private TextMeshProUGUI _fullSpecification;
    [SerializeField] private GameObject _goTextFly;
    [SerializeField] private float _timeFlyText;
    private Coroutine rut;

    public void SetImage(Image image)
    {
        _iSkil.sprite = image.sprite;
    }
    public void SetOpisanie(string shortSpecification, string fullSpecification)
    {
        _shortSpecification.text = shortSpecification;
        _fullSpecification.text = fullSpecification;
    }
    public void SetActiveTextFly()
    {
         rut = StartCoroutine(SetActivTexFly());
    }

    IEnumerator SetActivTexFly()
    {
        if (_goTextFly.activeSelf == true)
        {
            _goTextFly.SetActive(false);
            if (rut != null)
            {
                StopCoroutine(rut);
            }
            
        }
        else
        {
            _goTextFly.SetActive(true);
            yield return new WaitForSecondsRealtime(_timeFlyText);
            _goTextFly.SetActive(false);
        }
    }
}
