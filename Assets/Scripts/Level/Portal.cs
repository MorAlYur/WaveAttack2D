using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Levels _nextLevel;
    [SerializeField] private LevelSetting _levelSetting;
    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private ParticleSystem _particleStart;
    [SerializeField] private bool _activ = false; 
    private void Start()
    {
       // _particle = GetComponent<ParticleSystem>();
    }
    public void LoadNextLevel()
    {
        _levelSetting.LoadNextLevel(_nextLevel);
    }
    public async void ActivatePortal()
    {
        _particleStart.Play();
        await Task.Delay(1000);
        _particle.Play();
        _activ = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(_activ == false)
        {
            return;
        }
        if (collision.gameObject.TryGetComponent<Player>(out Player player)) 
        {
            LoadNextLevel();
        }
    }
}
