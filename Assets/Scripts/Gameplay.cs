using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Gameplay : MonoBehaviour
{
    [SerializeField] GameObject _usePanel;
    [SerializeField] GameObject _backPanel;
    [SerializeField] Camera _mainCamera;
    [SerializeField] Camera _balconCamera;
    [SerializeField] Camera _zercaloCamera;
    [SerializeField] Player _player;
    [SerializeField] Image _image;
    [SerializeField] float _timeToBlur;
    [SerializeField] GameObject _messengerPanel;
    private Sequence _sequence;
    private UseType _useType;
    private bool _onAnimation=false;
    private Color _baseColor;
    private bool _onMessengerPanel;

    public void ShowUse(UseType useType)
    {
        _useType = useType;
        _usePanel.SetActive(true);
    }

    public void HideUse()
    {
        _useType = UseType.None;
        _usePanel.SetActive(false);
    }

    private void Update()
    {
        if (_onAnimation) return;
        if (Input.GetKeyDown("e"))
        {
            if (_onMessengerPanel)
            {
                _messengerPanel.SetActive(false);
                _onMessengerPanel = false;
            }
            else
            {
                _messengerPanel.SetActive(true);
                _onMessengerPanel = true;
            }
        }
        if (_onMessengerPanel) return;
        if (Input.GetKey("f") && (_useType != UseType.None))
        {
            _sequence = DOTween.Sequence();
            if (_useType != UseType.Back)
            {
                _onAnimation = true;
                _baseColor = _image.color;
                _sequence.Append(_image.DOFade(1, _timeToBlur).SetEase(Ease.Linear).OnComplete(CallScreen));
            }
            else _sequence.Append(_image.DOFade(1, _timeToBlur).SetEase(Ease.Linear).OnComplete(BackScreen)); 
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
        _useType = UseType.Back;
        _onAnimation = false;
        _image.color= _baseColor;
    }

    private void ShowZercalo()
    {
        _mainCamera.gameObject.SetActive(false);
        _zercaloCamera.gameObject.SetActive(true);
        _player.StopPlayer();
    }

    private void BackScreen()
    {
        _image.color = _baseColor;
        _mainCamera.gameObject.SetActive(true);
        _balconCamera.gameObject.SetActive(false);
        _zercaloCamera.gameObject.SetActive(false);
        _player.RunPlayer();
    }

    private void ShowBalcon()
    {
        _mainCamera.gameObject.SetActive(false);
        _balconCamera.gameObject.SetActive(true);
        _player.StopPlayer();
    }




    public enum UseType
    {
        None,
        Balcon,
        Zercalo,
        Back
    }

}
