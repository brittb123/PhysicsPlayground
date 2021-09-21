using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikedLogSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject SpikedRoll;

    public float TimeTillLogSpawn;

    private float _TimetillNextLog;

    private void Start()
    {
        // Sets the time of when the logs spawn
        _TimetillNextLog = TimeTillLogSpawn;
    }

    private void Update()
    {
        // When the timer is less then or equal to 0 another log spawns and resets the time!
        if (_TimetillNextLog <= 0)
        {
            GameObject spawnedLog = Instantiate(SpikedRoll, transform.position, new Quaternion());
            spawnedLog.transform.position += new Vector3(0, 0, 3);
            _TimetillNextLog = 8;
        }
        else
            _TimetillNextLog -= Time.deltaTime;
    }
}
