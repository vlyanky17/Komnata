using UnityEngine;

public class Balcon : MonoBehaviour
{
    [SerializeField] private Parameters _parameters;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player") _parameters.Gameplay.ShowUse(Gameplay.UseType.Balcon);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") _parameters.Gameplay.HideUse();
    }
}
