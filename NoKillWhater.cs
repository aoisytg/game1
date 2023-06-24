using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoKillWhater : MonoBehaviour
{
    public PlayerMovement pl;

    [SerializeField]
    private GameObject barrier;

    private void Start()
    {
        barrier = GameObject.Find("Open");
    }

    private void Update()
    {
        if (pl.nokillwather)
        {
            Destroy(barrier);
        }
    }
}
