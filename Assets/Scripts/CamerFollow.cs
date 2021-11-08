using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerFollow : MonoBehaviour
{
    [SerializeField] Transform Myplayer;
    Vector3 offsetFACTOR;

    private void Start()
    {
        offsetFACTOR = transform.position - Myplayer.position;
    }

    private void Update()
    {
        Vector3 targetPosition = Myplayer.position + offsetFACTOR;
        targetPosition.x = 0;
        transform.position = targetPosition;
    }
}
