using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public bool HaveCollide { get; private set; }

    private void Start() 
    {
        HaveCollide = false;
    }

    private void OnTriggerStay(Collider other) 
    {
        HaveCollide = true;
    }

    private void OnTriggerExit(Collider other) 
    {
        HaveCollide = false;
    }
}
