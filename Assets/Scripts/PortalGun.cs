using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PortalGun : MonoBehaviour
{
    Camera cam;
    public Transform pivot;

    [SerializeField] Projectile Blue;
    [SerializeField] Projectile Orange;

    [SerializeField] private Transform barrel;

    [SerializeField] private PortalProvider provider;


    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        var pos = (Vector2)cam.ScreenToWorldPoint(mousePos);
        var screenPoint = (Vector2)transform.position;

        var offset = pos - screenPoint;
        float angle = Mathf.Atan2(offset.x, offset.y) * Mathf.Rad2Deg;
        pivot.rotation = Quaternion.Euler(0, 0, -angle);

        if (Input.GetMouseButtonDown(0))
        {
            var bullet = Instantiate(Blue, barrel.position, barrel.rotation);
            bullet.SetRotation(barrel.rotation);
            bullet.SetProvider(provider);
        }

        if (Input.GetMouseButtonDown(1))
        {
            var bullet = Instantiate(Orange, barrel.position, barrel.rotation);
            bullet.SetRotation(barrel.rotation);
            bullet.SetProvider(provider);
        }
    }
}