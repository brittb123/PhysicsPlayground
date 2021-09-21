using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikedLogMovementBehavior : MonoBehaviour
{

    [SerializeField]
    private GameObject _spkiedLog;

    public float Speed = 2.0f;

    // Update is called once per frame
    void Update()
    {
        _spkiedLog.transform.position += new Vector3(0, 0, Speed) * Time.deltaTime;
    }
}
