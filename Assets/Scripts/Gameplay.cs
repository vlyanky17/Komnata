using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Gameplay : MonoBehaviour
{
    [SerializeField] private Parameters _parameters;
    private UseType _useType;
    private bool _onMessengerPanel;

    public void ShowUse(UseType useType)
    {
        _useType = useType;
        _parameters.UsePanel.SetActive(true);
    }

    public void HideUse()
    {
        _useType = UseType.None;
        _parameters.UsePanel.SetActive(false);
    }

    private void Update()
    {
        if (_onMessengerPanel) return;
        if (Input.GetKeyDown("e") && (_useType != UseType.None))
        {
                CallScreen();
        }
        if (Input.GetKeyDown("escape") && (_useType == UseType.None))
        {
              BackScreen();
        }
    }

    private void CallScreen()
    {
        if (_useType == UseType.Balcon)
        {
            ShowBalcon();
        }

        if (_useType == UseType.Zercalo)
        {
            ShowZercalo();
        }
        _useType = UseType.None;
    }

    private void ShowZercalo()
    {
        _parameters.MainCamera.gameObject.SetActive(false);
        _parameters.ZercaloCamera.gameObject.SetActive(true);
        _parameters.Player.StopPlayer();
    }

    private void BackScreen()
    {
        _parameters.MainCamera.gameObject.SetActive(true);
        _parameters.BalconCamera.gameObject.SetActive(false);
        _parameters.ZercaloCamera.gameObject.SetActive(false);
        _parameters.Player.RunPlayer();
    }

    private void ShowBalcon()
    {
        _parameters.MainCamera.gameObject.SetActive(false);
        _parameters.BalconCamera.gameObject.SetActive(true);
        _parameters.Player.StopPlayer();
    }




    public enum UseType
    {
        None,
        Balcon,
        Zercalo,
        Back
    }

}
