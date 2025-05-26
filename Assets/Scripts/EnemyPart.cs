using UnityEngine;

public class EnemyPart : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Parameters _parameters;

    public void GetForceAtDirection(Vector3 direction)
    {
        _rb.AddForce(direction, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Area") EndSplash();
    }

    private void EndSplash()
    {
        _parameters.Gameplay.PlaceDecal(transform);
        gameObject.SetActive(false);
    }
}
