using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Mathematics;
using UnityEngine;

public class Projectile : MonoBehaviour 
{
    [SerializeField] private float Velocity;
    [SerializeField] private LayerMask collisions;

    [SerializeField] private bool IsOrange;

    private PortalProvider provider;
    public void SetRotation(Quaternion rotation)
    {
        transform.rotation = rotation;
    }

    public void SetProvider(PortalProvider provider)
    {
        this.provider = provider;
    }

    private void Start()
    {
        Destroy(gameObject, 3);
    }

    private void Update()
    {
        var position = (Vector2)transform.position;
        var direction = (Vector2)transform.up; 
        var dist = Velocity * Time.deltaTime;

        var hit = Physics2D.Raycast(position, direction, dist, collisions);

        if (hit) 
        {
            if (hit.collider.gameObject.TryGetComponent<PortalSurface>(out var surface))
            {
                var normal = hit.normal;


                float angle = Mathf.Atan2(normal.y, normal.x) * Mathf.Rad2Deg;

                
                var portal = provider.GetPortal(IsOrange);
                
                portal.transform.position = hit.point;
                portal.transform.rotation =  Quaternion.Euler(0f, 0f, angle);

                portal.Set(provider);

                if (IsOrange)
                {
                    provider.firedO = true;
                }
                else
                {
                    provider.firedB = true;
                }
            }

            Destroy(gameObject);
        }

        transform.position = position + direction * dist;
    }
}
