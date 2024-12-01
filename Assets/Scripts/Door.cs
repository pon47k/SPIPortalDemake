using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Collider2D Collider;
    public void Open()
    {
        Collider.enabled = false;
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    public void Close()
    {
        Collider.enabled = true;
        GetComponent<SpriteRenderer>().color = Color.white;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
