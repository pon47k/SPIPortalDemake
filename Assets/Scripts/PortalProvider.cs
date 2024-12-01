using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class PortalProvider : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject Blue;
    [SerializeField] private GameObject Orange;
    
    private Portal blue;
    private Portal orange;
    
    public bool CanUse => blue != null && orange != null && firedB && firedO;


    public bool firedO;
    public bool firedB;

    public Portal GetPortal(bool isOrange)
    {
        if (isOrange)
        {
            if (orange == null)
            {
                orange = Instantiate(Orange, new Vector3(1488, 1488, 1488), quaternion.identity).GetComponent<Portal>();
            }
            return orange;
        }
        else
        {
            if (blue == null)
            {
                blue = Instantiate(Blue, new Vector3(1488, 1488, 1488), quaternion.identity).GetComponent<Portal>();
            }
            return blue;
        }    
    }
}
