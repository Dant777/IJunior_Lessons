using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [SerializeField] private UnityEvent _soundUp;
    [SerializeField] private UnityEvent _soundDown;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Criminal>(out Criminal criminal))
        {
            _soundUp.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Criminal>(out Criminal criminal))
        {
            _soundDown.Invoke();
        }
    }
}
