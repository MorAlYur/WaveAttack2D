using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardPart : MonoBehaviour
{
    public InventaryPart _inventaryPart;
    public Transform _panelCurent;
    public Inventary _inventary;

    public GridLayoutGroup _grid;

    public int count;
    public float time;

    public GameObject _panelDisassemse1;
    public GameObject _panelViborItem;

    public List<PartInfo> list;
    public Coroutine rutine;
    

    
    public void Disassemle()
    {
        gameObject.SetActive(true);
        foreach (Transform child in _panelCurent)
        {
            Destroy(child.gameObject);
        }
        list.Clear();
        count = _inventaryPart._countReward;
        SettingsLayautGroup(count);
    }

    public void SettingsLayautGroup(int c)
    {
        if (c <= 10)
        {
            _grid.cellSize = new Vector2(250, 250);
            _grid.spacing = new Vector2(50, 50);
            _grid.constraintCount = 5;
        }
        else if (c > 10&&count<=21)
        {
            _grid.cellSize = new Vector2(250, 250);
            _grid.spacing = new Vector2(50, 50);
            _grid.constraintCount = 7;
        }
        else if(c > 21&&count<=24)
        {
            _grid.cellSize = new Vector2(250, 250);
            _grid.spacing = new Vector2(50, 50);
            _grid.constraintCount = 8;
        }
        else if(c > 24&&count<=36)
        {
            _grid.cellSize = new Vector2(200, 200);
            _grid.spacing = new Vector2(50, 50);
            _grid.constraintCount = 9;
        }

         else if(c > 36&&count<=40)
        {
            _grid.cellSize = new Vector2(200, 200);
            _grid.spacing = new Vector2(40, 40);
            _grid.constraintCount = 10;
        }
         else if(c > 40&&count<=50)
        {
            _grid.cellSize = new Vector2(170, 170);
            _grid.spacing = new Vector2(50, 25);
            _grid.constraintCount = 10;
        }
         else if(c > 50&&count<=60)
        {
            _grid.cellSize = new Vector2(170, 170);
            _grid.spacing = new Vector2(50, 25);
            _grid.constraintCount = 12;
        }
         else if(c > 60&&count<=100)
        {
            _grid.cellSize = new Vector2(100, 144);
            _grid.spacing = new Vector2(50, 25);
            _grid.constraintCount = 18;
        }

        else if (c > 144)
        {
            _grid.cellSize = new Vector2(50, 50);
            _grid.spacing = new Vector2(25, 25);
            _grid.constraintCount = 36;
        }
        AddUIPart();
    }
    public void AddUIPart()
    {
        gameObject.SetActive(true);
        for (int i = 0; i < count; i++)
        {
            List<int> rrr = new List<int>();
            int r = UnityEngine.Random.Range(0, _inventaryPart.Part.Count);
            var part = Instantiate(_inventaryPart.Part[r], _panelCurent);
            part.gameObject.SetActive(false);
            part.SetCount(1);
            part.SetTextCount();
            _inventaryPart.SetCount(part.ID);
            list.Add(part);
           
        }
        rutine = StartCoroutine(SetActivTrue());
        _inventary.RemoteItem(true);
    }

    public IEnumerator SetActivTrue()
    {
        foreach (var part in list)
        {
            part.gameObject.SetActive(true);
            yield return new WaitForSeconds(time);
        }

       
    }

    public void CloseChildredWindows()
    {
        StopCoroutine(rutine);
        gameObject.SetActive(false);
        _panelDisassemse1.SetActive(false);
        _panelViborItem.SetActive(false);
    }


}
