using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestAplicationPerDatasie : MonoBehaviour
{
    public TMP_Text text;
    private string _filePath; 


    // Start is called before the first frame update
    void Start()
    {
        _filePath = Application.persistentDataPath + "/Save.json";
        text.text = _filePath.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
