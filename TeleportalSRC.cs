using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TeleportalSRC : MonoBehaviour
{
    [SerializeField] private Transform tp_point;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other) {
        other.transform.position = new Vector2(tp_point.transform.position.x, tp_point.transform.position.y);            
    }
}
