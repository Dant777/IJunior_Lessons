using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Game01
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private UnityEvent _hit;
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log(collision.collider.gameObject.gameObject.name);

            if (collision.collider.TryGetComponent(out JampBox box))
            {
                _hit?.Invoke();
            }
        }
    }
}
