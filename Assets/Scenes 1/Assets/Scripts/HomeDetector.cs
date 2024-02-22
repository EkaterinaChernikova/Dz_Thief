using UnityEngine;

public class HomeDetector : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Movement>(out Movement component) == true)
        {
            _alarm.SetAlarmOn();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Movement>(out Movement component) == true)
        {
            _alarm.SetAlarmOff();
        }
    }
}