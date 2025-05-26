using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Gameplay : MonoBehaviour
{
    [SerializeField] private Parameters _parameters;
    [SerializeField] private List<DecalProjector> _decals;
    private UseType _useType;
    private bool _onMessengerPanel;
    private int _decalNumber;

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
        if (Input.GetKeyDown("space") )
        {
            _parameters.Player.HitEnemy();
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

    public void PlaceDecal(Transform pos)
    {
        _decals[_decalNumber].transform.parent = transform;
        _decals[_decalNumber].transform.position = pos.position- new Vector3(0,1,0);
        _decals[_decalNumber].gameObject.SetActive(true);
        _decalNumber++;
        if (_decalNumber == _decals.Count) _decalNumber = 0;
    }


    public enum UseType
    {
        None,
        Balcon,
        Zercalo,
        Back
    }

}
