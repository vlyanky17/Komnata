using UnityEngine;

public class Zerkalo : MonoBehaviour
{
    [SerializeField] private Gameplay _gameplay;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") _gameplay.ShowUse(Gameplay.UseType.Zercalo);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") _gameplay.HideUse();
    }
}
