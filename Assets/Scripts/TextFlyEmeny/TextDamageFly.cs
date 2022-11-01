using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDamageFly : MonoBehaviour
{
    public Text tDamageValue;

    public float speed;
    private float time = 0f;
    public float _timeLifeText;
    public float _timeFlyText;

    private int sizeText;

    private Color colorText;

    public void SetParametrText(int value,int size,Color color)
    {
        tDamageValue.text = value.ToString();
        tDamageValue.fontSize = size;
        tDamageValue.color = color;
    }


    void Update()
    {
        time += Time.deltaTime;
        if (time < _timeFlyText)
        {
            float x = Random.Range(-0.5f, 0.5f);
            transform.Translate(new Vector3(x,1,0) * speed * Random.Range(0.70f, 1.3f) * Time.deltaTime);
        }
        if (time > _timeLifeText)     //время существования
        {
            SetActivFalse();
        }

    }
    public void SetActivFalse()
    {
        gameObject.SetActive(false);
        time = 0;
    }
}
