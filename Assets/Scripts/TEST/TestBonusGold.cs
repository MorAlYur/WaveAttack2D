using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TestBonusGold : MonoBehaviour
{
    [Inject]
    public Bank bank;
   
    public void AddGold()
    {
        bank.AddGold(10000);
    }
}
