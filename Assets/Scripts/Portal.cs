using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private Transform destination;

    private Vector2 direction;
    [SerializeField] private float Offset;
    [SerializeField] private float ImpulseForce;

    private PortalProvider provider;

    
    public bool isOrange;




    public void Set(PortalProvider provider)
    {
        direction = transform.right;
        this.provider = provider;
        destination = provider.GetPortal(!isOrange).transform;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Teleportable>(out var obj) && obj.CanTeleport && provider.CanUse)
        {
            obj.StartTime();
            if (other.TryGetComponent<Rigidbody2D>(out var rb))
            {
                other.transform.position = new Vector2(destination.position.x, destination.position.y) + direction * Offset;
                var normal = destination.GetComponent<Portal>().direction;
                
                var angle = Quaternion.FromToRotation(-direction, normal);
                
                rb.velocity = angle * rb.velocity;
                
                rb.velocity += direction * ImpulseForce;
                print(rb.velocity);
            }
        }
    }
}
