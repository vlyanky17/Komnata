using UnityEngine;

public class Balcon : MonoBehaviour
{
    [SerializeField] private Gameplay _gameplay;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player") _gameplay.ShowUse(Gameplay.UseType.Balcon);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") _gameplay.HideUse();
    }
}
