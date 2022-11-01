using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class Factory : MonoBehaviour
{

    public event Action NullEnemyEvent;

    [HideInInspector]
    [Inject]
    public Bank bank;
    [HideInInspector]
    [Inject]
    public Saver saver;
    [HideInInspector]
    [Inject]
    public ItemSingolton itemSingolton;

    [SerializeField] private ManagerHPPlayer _managerHPPlayer;
    [SerializeField] private LevelPlayer _levelPlayer;
    [SerializeField] private RewardInLevel _rewardInLevel;
    [SerializeField] private PoolGoldDrop _poolGoldDrop;
    [SerializeField] private PoolDiamondDrop _poolDiamondDrop;
    [SerializeField] private Player _player;
    [SerializeField] private PoolEnemyBulletState1 _poolEnemyBulletState1;
    [SerializeField] private CameraController _cameraController;
    [SerializeField] private PlayerMove _playerMove;
    [SerializeField] private Image _blackBox;
    [Space(15)]
    [SerializeField]
    private List<Enemy> _activEnemies; 
    [Space(15)]
    public Levels _startLevel;
    public Levels _curentLevelENum;
    public LevelSetting _currntLevel;
    [Space(15)]
    [Header("—сылки на фабрики левелов")]
    [Space(5)]
    [SerializeField] private FactoryLevel1_1 _factoryLevel1_1;
    [SerializeField] private FactoryLevel1_2 _factoryLevel1_2;
    [SerializeField] private FactoryLevel1_3 _factoryLevel1_3;

    private void Start()
    {
        LoadLevel(_startLevel);
        NullEnemyToStart();
    }
    public async void LoadLevel(Levels loadLevel)
    {

        if (_curentLevelENum != Levels.Level0)
        {
            await Task.Delay(200);
            DestroyLevel(_currntLevel);
           
            
        }
        switch (loadLevel)
        {
            case Levels.Level1_1:
                _factoryLevel1_1.InstanseAllScene();
                break;
            case Levels.Level1_2:
                _factoryLevel1_2.InstanseAllScene();
                break;
            case Levels.Level1_3:
                _factoryLevel1_3.InstanseAllScene();
                break;
            default:
                _factoryLevel1_1.InstanseAllScene();
                break;
        }
        _curentLevelENum = loadLevel;
        _cameraController.FindLimit(_currntLevel.GetRightLimit(),_currntLevel.GetLeftLimit(),_currntLevel.GetUPLimit(),_currntLevel.GetDownLimit());
        _playerMove.SetPosition(_currntLevel.GetStartPlayerPosition());
        await Task.Delay(200);
        _blackBox.DOFade(0f, 0.05f);
    }
    public void StartPodLevel()
    {

    }
    public void InstanseLevel(LevelSetting levell)
    {
        _currntLevel = Instantiate(levell);
        _currntLevel.InstallingDependencies(this);
    }

    public void InstanseEnemy(Enemy enemyy, Vector3 position)
    {
        Enemy enemy = Instantiate(enemyy, position, Quaternion.identity, null);
        enemy.InstallingDependencies(_poolEnemyBulletState1);
        enemy.GetComponent<EnemyDrop>().InstallingDependencies(bank, saver, itemSingolton, _managerHPPlayer, _levelPlayer, _rewardInLevel,
           _poolGoldDrop, _poolDiamondDrop, _player); ;
        enemy.GetComponent<EmenyHPManager>().InstallingDependencies(_managerHPPlayer);
        Enable(enemy);
        

        _activEnemies.Add(enemy);
    }
    public void DestroyLevel(LevelSetting level)
    {
        _blackBox.DOFade(1f, 0.2f);
        Destroy(level.gameObject);
    }

    private void DeadEnemy(bool isKill,Enemy enemy)
    {
        Disable(enemy);
        _activEnemies.Remove(enemy);

        if(_activEnemies.Count == 0)
        {
            NullEnemy();
        }
    }
    public async void NullEnemy()
    {
        await Task.Delay(500);
        if (_activEnemies.Count == 0)
        {
            NullEnemyEvent?.Invoke();
        }
    }
    public async void NullEnemyToStart()
    {
        await Task.Delay(1500);
        if (_activEnemies.Count == 0)
        {
            NullEnemyEvent?.Invoke();
        }
    }
    public void Enable(Enemy enemy)
    {
        enemy.GetComponent<EmenyHPManager>().DeadEnemyEvent += DeadEnemy;
        enemy.GetComponent<EnemyCreateEnemy>().CreateEnemyEvent += InstanseEnemy;

    }
    public void Test(Enemy enemy,Vector3 position)
    {
        Debug.Log(position);
    }
    
    public void Disable(Enemy enemy)
    {
        enemy.GetComponent<EmenyHPManager>().DeadEnemyEvent -= DeadEnemy;
        enemy.GetComponent<EnemyCreateEnemy>().CreateEnemyEvent -= InstanseEnemy;
    }
    private void OnEnable()
    {
        foreach (var enemy in _activEnemies)
        {
            Disable(enemy);
        }
    }

}
