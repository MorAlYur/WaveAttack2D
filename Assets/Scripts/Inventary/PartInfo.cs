using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartInfo : MonoBehaviour
{
    [SerializeField] private int _id;
    [SerializeField] private int _count;
    [SerializeField] private Text _textCount;
    public string _infoPart;

    public void Start()
    {

    }

    public int ID => _id;
    public int Count => _count;

    public void SetCount(int count)
    {
        _count = count;
    }

    public void SetTextCount()
    {
        _textCount.text = $"X{_count}";
    }
}
