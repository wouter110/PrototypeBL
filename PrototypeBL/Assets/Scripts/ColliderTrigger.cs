using UnityEngine;
using UnityEngine.Events;

public class ColliderTrigger : MonoBehaviour
{
    public UnityEvent<Collider2D> OnEnter;
    public UnityEvent<Collider2D> OnStay;
    public UnityEvent<Collider2D> OnExit;

    [SerializeField] private LayerMask _layerMask;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(_layerMask == (_layerMask | (1 << collision.gameObject.layer))) {
            OnEnter?.Invoke(collision);
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (_layerMask == (_layerMask | (1 << collision.gameObject.layer))) {
            OnStay?.Invoke(collision);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (_layerMask == (_layerMask | (1 << collision.gameObject.layer))) {
            OnExit?.Invoke(collision);
        }
    }

}
