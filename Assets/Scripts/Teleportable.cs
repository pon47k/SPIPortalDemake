using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Teleportable : MonoBehaviour
{
    //public HashSet<Transform> teleported { get; } = new();
    [SerializeField] private Rigidbody2D rb;
    private float timeBetweenTeleports = 0.1f;
    public bool CanTeleport { get; set; } = true;
    // Start is called before the first frame update
    public void StartTime()
    {
        StartCoroutine(MakeGap());
    }
    

    private IEnumerator MakeGap()
    {
        CanTeleport = false;
        yield return new WaitForSeconds(timeBetweenTeleports);
        CanTeleport = true;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude > 20)
        {
            rb.velocity = rb.velocity.normalized * 20;
        }
    }
}
