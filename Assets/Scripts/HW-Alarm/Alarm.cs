using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [SerializeField] private UnityEvent _alarmTrigger;

    public bool IsEnabled { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Criminal>(out Criminal criminal))
        {
            _alarmTrigger.Invoke();
            IsEnabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Criminal>(out Criminal criminal))
        {
            _alarmTrigger.Invoke();
            IsEnabled = false;
        }
    }
}
