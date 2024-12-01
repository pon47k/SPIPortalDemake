using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Cube : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    // Start is called before the first frame update

    public void BeginBeingPicked()
    {
        rb.mass = 0;
        gameObject.GetComponent<Collider2D>().enabled = false;
    }

    public void StopBeingPicked()
    {
        rb.mass = 1;
        gameObject.GetComponent<Collider2D>().enabled = true;
    }

    public void Follow(Transform point)
    {
        StartCoroutine(Following(point));
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Following(Transform point)
    {

        while (true)
        {
            var dir = transform.position + ((Vector3)Vector2.Lerp(transform.position, point.position, 0.3f) - transform.position) * 100 * Time.deltaTime ;
            transform.position = dir;
            yield return 0;
        }
    }

}
