using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRandom : MonoBehaviour
{
    public int r;

    public int[] count = new int[10];
    public void TestRandom1()
    {
        for (int i = 0; i < 10000; i++)
        {
            var x = r;
            while (x == r)
            {
                r = UnityEngine.Random.Range(0, 10);
            }
            count[r]++;

        }

        for (int i = 0; i < count.Length; i++)
        {
            Debug.Log($"{i} выпала {count[i]} раз");
        }
    }
}
