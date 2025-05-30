using DG.Tweening;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Parameters _parameters;
    [SerializeField] private ParticleSystem _particles;
    [SerializeField] private List<EnemyPart> _parts;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Image _image;
    private Vector3 _splashDir;
    private Sequence _sequence;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") PlayerNear();
    }

    private void Awake()
    {
        _image.gameObject.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") PlayerAway();
    }

    private void PlayerNear()
    {
        TextSpawnAnimation();
        _parameters.Player.SetEnemy(this);
    }

    private void TextHideAnimation()
    {
        _sequence = DOTween.Sequence();
        _sequence.Join(_image.transform.DOLocalMove(new Vector3(0, -50, 0), 0.8f)).SetEase(Ease.Linear);
        _sequence.Join(_image.DOColor(new Color(1, 1, 1, 0), 0.8f)).SetEase(Ease.Linear);
        _sequence.Join(_text.DOColor(new Color(0, 0, 0, 0), 0.8f)).SetEase(Ease.Linear);
    }

    private void TextSpawnAnimation()
    {
        _image.gameObject.SetActive(true);
        _image.color = new Color(1,1,1,0);
        _text.color = new Color(0,0,0,0);
        _sequence = DOTween.Sequence();
        _image.transform.localPosition = new Vector3(0,-50,0);
        _sequence.Join(_image.transform.DOLocalMove(Vector3.zero, 0.8f)).SetEase(Ease.Linear);
        _sequence.Join(_image.DOColor(Color.white, 0.8f)).SetEase(Ease.Linear);
        _sequence.Join(_text.DOColor(Color.black, 0.8f)).SetEase(Ease.Linear);
    }

    private void PlayerAway()
    {
        TextHideAnimation();
        _parameters.Player.DeleteEnemy();
    }

    public void GetHit()
    {
        _parameters.Player.DeleteEnemy();
        SplashParts();
        var direction = transform.position- _parameters.Player.transform.position;
        _particles.transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
       // var a = transform.InverseTransformDirection(_parameters.Player.transform.position);
        //Debug.Log(a);
        //_particles.transform.eulerAngles =new Vector3(0,180,0);
        _particles.gameObject.SetActive(true);
        _particles.Play();
        gameObject.SetActive(false);
        _parameters.Gameplay.PlaceDecal(transform);

    }

    private void SplashParts()
    {
        for (int i = 0; i < _parts.Count; i++)
        {
            _splashDir = transform.position - _parameters.Player.transform.position + new Vector3(Random.Range(-1.5f, 1.5f), 2, Random.Range(-1.5f, 1.5f));
            _splashDir = _splashDir * 3;
            _parts[i].gameObject.SetActive(true);
            //Debug.Log(_splashDir);
            _parts[i].GetForceAtDirection(_splashDir);
        }
    }
}
