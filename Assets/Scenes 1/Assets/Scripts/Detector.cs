using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Movement>(out Movement component) == true)
        {
            _alarm.StartAlarm();
        }
    }
}
