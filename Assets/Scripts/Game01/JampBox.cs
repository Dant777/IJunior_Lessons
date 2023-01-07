using UnityEngine;
using UnityEngine.EventSystems;

public class JampBox : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _jampForce;
    public void OnPointerClick(PointerEventData eventData)
    {
        _rigidbody2D.AddForce(Vector2.up * _jampForce);
    }
}
