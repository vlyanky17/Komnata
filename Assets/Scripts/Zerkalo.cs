using UnityEngine;

public class Zerkalo : MonoBehaviour
{
    [SerializeField] private Parameters _parameters;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") _parameters.Gameplay.ShowUse(Gameplay.UseType.Zercalo);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") _parameters.Gameplay.HideUse();
    }
}
