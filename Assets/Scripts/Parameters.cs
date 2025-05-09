using Unity.VisualScripting;
using UnityEngine;

public class Parameters : MonoBehaviour
{
    [field: SerializeField] public float PlayerSpeed { get; private set; } = 5;
    [field: SerializeField] public float PlayerRunSpeed { get; private set; } = 10;
    [field: SerializeField] public Gameplay Gameplay { get; private set; }
    [field: SerializeField] public Player Player { get; private set; }
    [field: SerializeField] public Camera ZercaloCamera { get; private set; }
    [field: SerializeField] public Camera BalconCamera { get; private set; }
    [field: SerializeField] public Camera MainCamera { get; private set; }
    [field: SerializeField] public GameObject BackPanel { get; private set; }
    [field: SerializeField] public GameObject UsePanel { get; private set; }
    [field: SerializeField] public GameObject MessengerPanel { get; private set; }
    [field: SerializeField] public float MinScrollDistance { get; private set; }
    [field: SerializeField] public float MaxScrollDistance { get; private set; }

}
