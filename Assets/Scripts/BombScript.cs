using System;
using Unity.VisualScripting;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    private Coroutine _coroutine;
    private Collider2D _collider;
    public bool IsActiveted=false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player in area");
            IsActiveted = true;
            other.gameObject.GetComponent<PlayerHealth>().Die();
        }
        else if(other.CompareTag("Enemy"))
        {
            IsActiveted = false;
            //Find methode
            
        }
    }
}
