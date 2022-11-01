using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(EmenyHPManager))]
[RequireComponent(typeof(Enemy))]

public class EnemyDrop : MonoBehaviour
{


    private Saver _saver;
    private Bank _bank;
    private ItemSingolton _itemSingolton;

    private ManagerHPPlayer _managerHPPlayer;
    private LevelPlayer _levelPlayer;
    private RewardInLevel _rewardInLevel;

    private PoolGoldDrop _poolGoldDrop;
    private PoolDiamondDrop _poolDiamondDrop;
    private Player _player;
  
    private Enemy _enemy;
    [Header("Префабы")]
    public GameObject _prefabItemDrop;
    public GameObject _prefabDimand;
    public GameObject _prefabHeart;
  
    [Header("Количество:")]
    public int _exp;
    public int _gold;
    public int _diamond;
    public int _helsPlayerInDead;
    [Header("Шанс дропа сердца")]
    public float _prHeart;
    [Header("Шанс дропа алмазов")]
    public float _prDiamond;
    [Header("Шанс дропа частей")]
    public float _prPartDrop;
    public int _countPartDrop = 1;
    public bool _isCutrentPart;
    public int _numberPartInItemSingoltonAllPart;
    [Header("Шанс дропа айтемов")]
    public bool _curentItem;
    public int _numberItemInItemSingoltonAllPart;
    public float _prDropaCurentItem;
    public float _prEcipirovkaNormal;
    public float _prEcipirovkaUncomon;
    public float _prEcipirovkaUnusual;
    public float _prEcipirovkaEpic;
    public float _prEcipirovkaLegendary;

    public void InstallingDependencies(Bank bank,Saver saver,ItemSingolton itemSingolton,ManagerHPPlayer managerHPPlayer,LevelPlayer levelPlayer,
        RewardInLevel rewardInLevel,PoolGoldDrop poolGoldDrop,PoolDiamondDrop poolDiamondDrop,Player player)
    {
        _bank = bank;
        _saver = saver;
        _itemSingolton = itemSingolton;
        _managerHPPlayer = managerHPPlayer;
        _levelPlayer = levelPlayer;
        _rewardInLevel = rewardInLevel;
        _poolGoldDrop = poolGoldDrop;
        _poolDiamondDrop = poolDiamondDrop;
        _player = player;
    }
    void Start()
    {
        _enemy = GetComponent<Enemy>();
    }

    public void Deat()
    {
        AddExp();
        AddGold();
        DropItem();
        DropPart();
        DropDiamond();
        VampiricPlayer();
        DropHeart();
    }

    public void DropItem()
    {
        var r = Random.Range(0, 9999);
        if (_curentItem)
        {
            var it = _numberItemInItemSingoltonAllPart;
            if(it> _itemSingolton.allitems.Count)
            {
                Debug.LogError("Номер айтема больше чем количество в ItemSingolton.AllItems " + gameObject.name);
                return;
                
            }
            var item = Instantiate(_prefabItemDrop, transform.position, Quaternion.identity);
            item.GetComponent<DropItem>().SetParametr(_itemSingolton.allitems[it].itemName, _itemSingolton.allitems[it].GetComponent<Image>().sprite);
            _rewardInLevel.AddItemList(_itemSingolton.allitems[it].gameObject);
            _saver.AddItemToInventarySaveData(_itemSingolton.allitems[it]);
            return;
        }
        if (r <(int)(_prEcipirovkaLegendary*100))
        {
            var it = Random.Range(0, _itemSingolton._itemsLegendary.Count);
            var item =  Instantiate(_prefabItemDrop,transform.position,Quaternion.identity);
            item.GetComponent<DropItem>().SetParametr(_itemSingolton._itemsLegendary[it].itemName, _itemSingolton._itemsLegendary[it].GetComponent<Image>().sprite);
            _rewardInLevel.AddItemList(_itemSingolton._itemsLegendary[it].gameObject);
            _saver.AddItemToInventarySaveData(_itemSingolton._itemsLegendary[it]);
            return;
        }
        else if(r < (int)(_prEcipirovkaEpic * 100))
        {
            var it = Random.Range(0, _itemSingolton._itemsEpic.Count);
            var item = Instantiate(_prefabItemDrop, transform.position, Quaternion.identity);
            item.GetComponent<DropItem>().SetParametr(_itemSingolton._itemsEpic[it].itemName, _itemSingolton._itemsEpic[it].GetComponent<Image>().sprite);
            _rewardInLevel.AddItemList(_itemSingolton._itemsEpic[it].gameObject);
            _saver.AddItemToInventarySaveData(_itemSingolton._itemsEpic[it]);
            return;
        }
        else if(r < (int)(_prEcipirovkaUnusual * 100))
        {
            var it = Random.Range(0, _itemSingolton._itemsUnusual.Count);
            var item = Instantiate(_prefabItemDrop, transform.position, Quaternion.identity);
            item.GetComponent<DropItem>().SetParametr(_itemSingolton._itemsUnusual[it].itemName, _itemSingolton._itemsUnusual[it].GetComponent<Image>().sprite);
            _rewardInLevel.AddItemList(_itemSingolton._itemsUnusual[it].gameObject);
            _saver.AddItemToInventarySaveData(_itemSingolton._itemsUnusual[it]);
            return;
        }
        else if (r < (int)(_prEcipirovkaUncomon * 100))
        {
            var it = Random.Range(0, _itemSingolton._itemsUncommom.Count);
            var item = Instantiate(_prefabItemDrop, transform.position, Quaternion.identity);
            item.GetComponent<DropItem>().SetParametr(_itemSingolton._itemsUncommom[it].itemName, _itemSingolton._itemsUncommom[it].GetComponent<Image>().sprite);
            _rewardInLevel.AddItemList(_itemSingolton._itemsUncommom[it].gameObject);
            _saver.AddItemToInventarySaveData(_itemSingolton._itemsUncommom[it]);
            return;
        }
         else if (r < (int)(_prEcipirovkaNormal * 100))
        {
            var it = Random.Range(0, _itemSingolton._itemsNormal.Count);
            var item = Instantiate(_prefabItemDrop, transform.position, Quaternion.identity);
            item.GetComponent<DropItem>().SetParametr(_itemSingolton._itemsNormal[it].itemName, _itemSingolton._itemsNormal[it].GetComponent<Image>().sprite);
            _rewardInLevel.AddItemList(_itemSingolton._itemsNormal[it].gameObject);
            _saver.AddItemToInventarySaveData(_itemSingolton._itemsNormal[it]);
            return;
        }
    }

    public void DropPart()
    {
        var pr = Random.Range(0, 9999);
        if (pr < (int)((_prPartDrop + _managerHPPlayer._dopPrDropPart) * 100))
        {
            for (int i = 0; i < _countPartDrop; i++)
            {
                var part = Instantiate(_prefabItemDrop, transform.position, Quaternion.identity);
                var r = 0;
                if (_isCutrentPart)
                {
                    r = _numberPartInItemSingoltonAllPart;
                    if(r> _itemSingolton.allItemsPart.Count)
                    {
                        Debug.LogError("Номер части больше чем количество в ItemSingolton.AllItemsPart " + gameObject.name);
                        return;
                    }
                }
                else
                {
                     r = Random.Range(0, _itemSingolton.allItemsPart.Count);
                }
                part.GetComponent<DropItem>().SetParametr(_itemSingolton.allItemsPart[r]._infoPart, _itemSingolton.allItemsPart[r].GetComponent<Image>().sprite);
                _rewardInLevel.AddPartList(_itemSingolton.allItemsPart[r].gameObject);
                _saver.AddToPartSaveData(_itemSingolton.allItemsPart[r].ID, 1);
            }
        }
    }

    private void AddGold()
    {
        _poolGoldDrop.Activate(transform.position);
        _poolGoldDrop.Activate(transform.position);
        _poolGoldDrop.Activate(transform.position);
       
        var allGold = _gold + ((int)(_gold * _managerHPPlayer._dopGoldPR*0.01));
        _rewardInLevel.AddGold(allGold);
        _bank.AddGoldInLevel(allGold);
    }

    public void DropDiamond()
    {
        var pr = Random.Range(0, 9999);
        if (pr < (int)((_prDiamond + _managerHPPlayer._dopDropDiamondPR) * 100))
        {
            for (int i = 0; i < _diamond; i++)
            {
                _poolDiamondDrop.Activate(transform.position);
            }
            _rewardInLevel.AddDianod(_diamond);
            _bank.AddDiamondInLevel(_diamond);
        }
    }
    public void VampiricPlayer()
    {
        if (_managerHPPlayer.isVampiric == false)
        {
            return;
        }
        _managerHPPlayer.SetHP(_managerHPPlayer.vampiricHelsing, false);
    }

    public void DropHeart()
    {
        var pr = Random.Range(0, 9999);
        if (pr < (int)((_prHeart + _managerHPPlayer._dopPrHeart) * 100))
        {
            var heart = Instantiate(_prefabHeart, transform.position, Quaternion.identity);
            heart.GetComponent<DropHeart>().SetHelsCountPlayer(_helsPlayerInDead);
        }
    }

    private void AddExp()
    {
        var allExp = _exp + (int)(_exp * _managerHPPlayer._dopExpPR*0.01);
        _levelPlayer.AddExp(allExp);
    }


}
