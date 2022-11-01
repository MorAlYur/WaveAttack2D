using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ZenJeckAllScene : MonoInstaller
{
    [SerializeField] private Saver _saverPrefab;
    [SerializeField] private Statistics _statisticsPrefab;
    [SerializeField] private Bank _bankPrefab;
    [SerializeField] private ItemSingolton _itemSingoltonPrefab;
    [SerializeField] private Example _localizateExamplePrefab;
    public override void InstallBindings()
    {
        BindSaver();
        BindBank();
        BindStatistic();
        BindItemSingolton();
        BindLocalizate();

    }
    private void BindSaver()
    {
        var saver = Container.InstantiatePrefabForComponent<Saver>(_saverPrefab);
        Container.Bind<Saver>().FromInstance(saver).AsSingle().NonLazy();
    }

    private void BindStatistic()
    {
        var statistic = Container.InstantiatePrefabForComponent<Statistics>(_statisticsPrefab);
        Container.Bind<Statistics>().FromInstance(statistic).AsSingle().NonLazy();
    }
    private void BindBank()
    {
        var bank = Container.InstantiatePrefabForComponent<Bank>(_bankPrefab);
        Container.Bind<Bank>().FromInstance(bank).AsSingle().NonLazy();
    }
    private void BindItemSingolton()
    {
        var itemSingolton = Container.InstantiatePrefabForComponent<ItemSingolton>(_itemSingoltonPrefab);
        Container.Bind<ItemSingolton>().FromInstance(itemSingolton).AsSingle().NonLazy();
    }
     private void BindLocalizate()
    {
        var localizate = Container.InstantiatePrefabForComponent<Example>(_localizateExamplePrefab);
        Container.Bind<Example>().FromInstance(localizate).AsSingle().NonLazy();
    }
    
}
