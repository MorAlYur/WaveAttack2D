using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDamageFlyPlayer : MonoBehaviour
{
    public float speed;
    private float time = 0f;
    public float _timeFlyStartText;
    public float _timeFlyFinishText;
    public float _timeLifeText;
    public RectTransform rect;
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time>= _timeFlyStartText&&time <= _timeFlyFinishText)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if (time > _timeLifeText)     //время существования
        {
            SetActivFalse();
        }

    }
    public void SetActivFalse()
    {
        time = 0;
        rect.localPosition = new Vector2(0, 0);
        gameObject.SetActive(false);


    }
}
