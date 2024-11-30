using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGun : MonoBehaviour
{
    Camera cam;
    public GameObject portal;
    public Transform pivot;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = cam.WorldToScreenPoint(transform.localPosition);

        Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);
        float angle = Mathf.Atan2(offset.x, offset.y) * Mathf.Rad2Deg;
        pivot.rotation = Quaternion.Euler(0, 0, angle);

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 cursorPos = cam.ScreenToWorldPoint(Input.mousePosition);
            GameObject bluePortal = GameObject.FindGameObjectWithTag("blue");

            if (bluePortal != null)
            {
                Destroy(bluePortal);
            }

            Instantiate(portal, new Vector3(cursorPos.x, cursorPos.y, 0), Quaternion.identity);
            bluePortal = this.gameObject;
        }
    }
}