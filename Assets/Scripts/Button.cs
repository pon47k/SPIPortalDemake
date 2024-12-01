using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Button : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public Door door;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<CubePicker>(out var c) || other.TryGetComponent<PlayerMovement>(out var p))
        {
            door.Open();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<CubePicker>(out var c) || other.TryGetComponent<PlayerMovement>(out var p))
        {
            door.Close();
        }
    }

}
