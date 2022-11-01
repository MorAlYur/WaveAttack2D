using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWallTranzition : Transition
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (enabled == false)
            return;
        if (collision.gameObject.TryGetComponent(out Player player) || collision.gameObject.TryGetComponent(out Enemy enemy) || collision.gameObject.TryGetComponent(out Wall wall))
            NeedTransit = true;
    }
}
