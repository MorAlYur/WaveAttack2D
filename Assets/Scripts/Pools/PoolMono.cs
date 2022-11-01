using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolMono<T> where T : MonoBehaviour
{
   public T prefab { get; }
    public bool autoExpand { get; set; }
    public Transform container { get; }

    private List<T> pool;

    public PoolMono(T prefab,int count)
    {
        this.prefab = prefab;
        this.container = null;

        this.CreatePool(count);
    }
     public PoolMono(T prefab,int count, Transform container )
    {
        this.prefab = prefab;
        this.container = container;

        this.CreatePool(count);
    }

    private void CreatePool(int count)
    {
        this.pool = new List<T>();
        for (int i = 0; i < count; i++)
        {
            this.CreateObject();
        }
    }

    private T CreateObject(bool isActiveByDefolt = false)
    {
        var createObject = Object.Instantiate(this.prefab, this.container);
        createObject.gameObject.SetActive(isActiveByDefolt);
        this.pool.Add(createObject);
        return createObject;
    }

    public bool HasFreeElement(out T element)
    {
        foreach (var mono in pool)
        {
            if (!mono.gameObject.activeInHierarchy)
            {
                element = mono;
                mono.gameObject.SetActive(true);
                return true;
            }
        }
       
        element = null;
        return false;
    }

    public T GetFreeElement()
    {
        if (this.HasFreeElement(out var element))
            return element;

        if (this.autoExpand)
            return this.CreateObject(true);
        throw new System.Exception($"There is no free elements in pool of type {typeof(T)}");
    }
     public T GetFreeElement(Vector3 positiion)
    {
        if (this.HasFreeElement(out var element))
        {
            element.transform.position = positiion;
            return element;
        }

        if (this.autoExpand)
            return this.CreateObject(true);
        throw new System.Exception($"There is no free elements in pool of type {typeof(T)}");
    }
     public T GetFreeElement(Vector3 positiion, Collider2D collider)
    {
        if (this.HasFreeElement(out var element))
        {
            element.transform.position = positiion;
            Physics2D.IgnoreCollision(element.gameObject.GetComponent<Collider2D>(), collider);
            return element;
        }

        if (this.autoExpand)
            return this.CreateObject(true);
        throw new System.Exception($"There is no free elements in pool of type {typeof(T)}");
    }

    public List<T> GetPoolList()
    {
        return pool;
    }
}
