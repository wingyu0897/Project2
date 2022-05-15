using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidTile : MonoBehaviour
{
    private void OnDestroy()
    {
        Destroy(gameObject);
    }
}
