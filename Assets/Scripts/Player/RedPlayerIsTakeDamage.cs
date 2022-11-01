using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlayerIsTakeDamage : MonoBehaviour
{
    [SerializeField] private Color _damageColor;
    [SerializeField] private float _timeRed;
    [SerializeField] private SpriteRenderer[] _allSpriteRenderPlayer;

    private Color[] _colorDefoldSprite;
    private ManagerHPPlayer _managerHPPlayer;


    private void Start()
    {
        _managerHPPlayer = gameObject.GetComponent<ManagerHPPlayer>();
        _managerHPPlayer.TakeDamage1 += SetColorDamage;

        _colorDefoldSprite = new Color[_allSpriteRenderPlayer.Length];
        for (int i = 0; i < _allSpriteRenderPlayer.Length; i++)
        {
            _colorDefoldSprite[i] = _allSpriteRenderPlayer[i].color;
        }
    }
    private void OnDisable()
    {
        _managerHPPlayer.TakeDamage1 -= SetColorDamage;
    }

    private void SetColorDamage(int damage)
    {
        for (int i = 0; i < _allSpriteRenderPlayer.Length; i++)
        {
            _allSpriteRenderPlayer[i].color = _damageColor;
        }
        Invoke(nameof(SetColorDefold), _timeRed);
    }
    private void SetColorDefold()
    {
        for (int i = 0; i < _allSpriteRenderPlayer.Length; i++)
        {
            _allSpriteRenderPlayer[i].color = _colorDefoldSprite[i];
        }
    }
}
