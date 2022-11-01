using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class Inventary : MonoBehaviour
{
    [Inject]
    public Saver _saver;
    [Inject]
    public Bank _bank;

    [Header("Все параметры")]
    public float damage;
    public float heals;
    public float armor;
    public float miss;
    public float critChance;
    public float critDamage;
    public float attackSpeed;
    public float movementSpeed;


    public bool isKuznjaActive = false;

    public delegate void ClosePanelViborItemDelegate();
    public  event ClosePanelViborItemDelegate ClosePanelViborItemEvent;

    public event Action KuznicaActivEvent;


    
    public List<Item> _inventary;
    [Inject]
    public ItemSingolton itemSingolton;
    public InventaryPart _inventaryPart;
    public UIAllParamert _uIAllParamert;


    public Item IGolova;
    public Item IAmulet;
    public Item IKolco;
    public Item IGrudi;
    public Item INogi;
    public Item IBotinki;

    public UIViborItemPanel UIViborItemPanel;
    [HideInInspector] public Item _item;
    [HideInInspector] public int level;
    [HideInInspector] public int cislo;
    [HideInInspector] public bool isActiv;
    [HideInInspector] public Item.Mesto mesto;
    [HideInInspector] public int partID;

    [Header("Трансформы для рпсположения айтемов")]
    public Transform PanelItemsTR;
    public Transform BotinkiTR;
    public Transform NogiTR;
    public Transform KolcoTR;
    public Transform GrudiTR;
    public Transform AmuletTR;
    public Transform GolovaTR;

    public GameObject _paenlWindowSell;

    [Header("Кузница")]
    public Kuznica _kuznica;
    public UIKuzmica UIKuzmica;
    public SortItemIsKuznica _sortItemIsKuznica;









    

    private void OnDisable()
    {
        foreach (var item in _inventary)
        {
            item.GetComponent<Button>().onClick.RemoveListener(delegate { ViborItema(item); });
        }


    }

    #region для сохранений
    [Header("Для сохранений")]
    [HideInInspector] public int cisloBotinkiSave;
    [HideInInspector] public int cisloNogiSave;
    [HideInInspector] public int cisloKolcoSave;
    [HideInInspector] public int cisloGrudiSave;
    [HideInInspector] public int cisloAmuletSave;
    [HideInInspector] public int cisloGolovaSave;

    [HideInInspector] public int[] idSave;
    [HideInInspector] public int[] lvlSave;
    [HideInInspector] public int[] cisloSave;
    #endregion

    private void ViborItema(Item item)
    {
        _item = item;
        cislo = item.cislo;
        isActiv = item.isActiv;
        mesto = item.mesto;
        level = item.level;
        partID = item.partID;
        _kuznica.Item_NoviiEvent(item);
        UIViborItemPanel.ViborItemPanel(item);


    }
    public void DeleteItem(Item item)
    {
        item.GetComponent<Button>().onClick.RemoveListener(delegate { ViborItema(item); });
        _inventary.Remove(item);
        Destroy(item.gameObject);
    }
    public void CloseAllChildWindow()
    {
        if (isKuznjaActive)
        {
            UIKuzmica.ClosePanelKuznjaIsAnimation();
        }
        else
        {
            if (UIViborItemPanel.ViborItemsPanel.activeSelf == true)
            {
                ClosePanelViborItemEvent?.Invoke();
                if (_paenlWindowSell.activeSelf == true)
                {
                    CloseWindowSell();
                }
            }
        }
    }
    #region "Для продажи айтемов"
    public void SellItem()
    {
        if (level == 1)
            _bank.AddGold(50);
        else
            _bank.AddGold((int)((int)((0.5 * (level - 1) * (level)) * 200) * 0.5f));
        if (isActiv)
        {
            switch (mesto)
            {
                case Item.Mesto.golova:
                    DeleteItem(IGolova);
                    //_inventary.Remove(IGolova);
                    //Destroy(IGolova.gameObject);
                    break;
                case Item.Mesto.amulet:
                    DeleteItem(IAmulet);
                    break;
                case Item.Mesto.kolco:
                    DeleteItem(IKolco);
                    break;
                case Item.Mesto.grudi:
                    DeleteItem(IGrudi);
                    break;
                case Item.Mesto.nogi:
                    DeleteItem(INogi);
                    break;
                case Item.Mesto.botinki:
                    DeleteItem(IBotinki);
                    break;
                default:
                    break;
            }
        }
        else
        {
            DeleteItem(_item);
        }
        ClosePanelViborItemEvent?.Invoke();
        _sortItemIsKuznica.SetActivSeslTexNewKuznica();
        SortMasiv();
        AllStats();
        SaveGame();
    }
    public void CloseWindowSell()
    {
        _paenlWindowSell.SetActive(false);
        ClosePanelViborItemEvent?.Invoke();
    }
    #endregion
    



    public void LVLUPItem()
    {
        _bank.SpendGold((level) * 200);
        _item.level = _item.level + 1;
        _item.UpdateTextLevel();
        _item.SetParametr();
        if (_inventaryPart.GetCountPartPerLevel(level) <= _inventaryPart.GetCount(_item.partID))
        {
            _inventaryPart.SetCount(_item.partID, _inventaryPart.GetCountPartPerLevel(level) * -1);
        }
        else
        {
            _inventaryPart.SetCount(999, (_inventaryPart.GetCountPartPerLevel(level)-_inventaryPart.GetCount(_item.partID)) * -1);
            _inventaryPart.SetCount(_item.partID, _inventaryPart.GetCount(_item.partID)*-1);
        }
        

       // _item.Click();
        ViborItema(_item);
        AllStats();
        SortMasiv();
        SaveGame();
    }
    public void AddItem()
    {
        var c = UnityEngine.Random.Range(1, 7);
        foreach (var item in itemSingolton.allitems)
        {
            if (item.id == c)
            {
                var obj = Instantiate(item, PanelItemsTR);
                obj.cislo = CisloIsItems.NextCislo();
                CisloIsItems.Save();
                obj.GetComponent<Button>().onClick.AddListener(delegate { ViborItema(obj); });
                _inventary.Add(obj);
               
            }
        }
        _sortItemIsKuznica.SetActivSeslTexNewKuznica();
        SaveGame();
    }
    public void AddItem(int minID, int maxID)
    {
        var c = UnityEngine.Random.Range(minID, maxID);
        foreach (var item in itemSingolton.allitems)
        {
            if (item.id == c)
            {
                var obj = Instantiate(item, transform);
                obj.cislo = CisloIsItems.NextCislo();
                CisloIsItems.Save();
                obj.GetComponent<Button>().onClick.AddListener(delegate { ViborItema(obj); });
                _inventary.Add(obj);
            }
        }
        _sortItemIsKuznica.SetActivSeslTexNewKuznica();
        SaveGame();
    }

    public void AddItem(int id, int level, bool isActiv)
    {
        foreach (var item in itemSingolton.allitems)
        {
            if (item.id == id)
            {
                var obj = Instantiate(item, PanelItemsTR);
                var cis = obj.cislo = CisloIsItems.NextCislo();
                CisloIsItems.Save();
                obj.GetComponent<Button>().onClick.AddListener(delegate { ViborItema(obj); });
                _inventary.Add(obj);
                obj.level = level;
                obj.SetParametr();
                obj.isActiv = isActiv;
                
                if (isActiv == true)
                {
                    if (isKuznjaActive == true)
                    {
                        NadetItem(cis);
                    }
                }
            }
        }
        _sortItemIsKuznica.SetActivSeslTexNewKuznica();
        SaveGame();

    }


    public void RemoteItem(bool Disass)
    {

        if (isActiv)
        {
            switch (mesto)
            {
                case Item.Mesto.golova:
                    DeleteItem(IGolova);
                    break;
                case Item.Mesto.amulet:
                    DeleteItem(IAmulet);
                    break;
                case Item.Mesto.kolco:
                    DeleteItem(IKolco);
                    break;
                case Item.Mesto.grudi:
                    DeleteItem(IGrudi);
                    break;
                case Item.Mesto.nogi:
                    DeleteItem(INogi);
                    break;
                case Item.Mesto.botinki:
                    DeleteItem(IBotinki);
                    break;
                default:
                    break;
            }
        }
        else
        {

            DeleteItem(_item);

        }
        ClosePanelViborItemEvent?.Invoke();
        _sortItemIsKuznica.SetActivSeslTexNewKuznica();
        SortMasiv();
        AllStats();
        SaveGame();
    }
    public void RemoteItemIsKuznja(Item it)
    {
        if (it.isActiv == true)
        {
            switch (it.mesto)
            {
                case Item.Mesto.golova:
                    DeleteItem(IGolova);
                    break;
                case Item.Mesto.amulet:
                    DeleteItem(IAmulet);
                    break;
                case Item.Mesto.kolco:
                    DeleteItem(IKolco);
                    break;
                case Item.Mesto.grudi:
                    DeleteItem(IGrudi);
                    break;
                case Item.Mesto.nogi:
                    DeleteItem(INogi);
                    break;
                case Item.Mesto.botinki:
                    DeleteItem(IBotinki);
                    break;
                default:
                    break;
            }
        }
        else
        {
            DeleteItem(it);
        }
        _sortItemIsKuznica.SetActivSeslTexNewKuznica();
    }

    public void NadetItem()
    {
        if (isActiv)
        {
            switch (mesto)
            {
                case Item.Mesto.golova:
                    IGolova.transform.SetParent(PanelItemsTR);
                    IGolova.isActiv = false;
                    IGolova = null;
                    break;
                case Item.Mesto.amulet:
                    IAmulet.transform.SetParent(PanelItemsTR);
                    IAmulet.isActiv = false;
                    IAmulet = null;
                    break;
                case Item.Mesto.kolco:
                    IKolco.transform.SetParent(PanelItemsTR);
                    IKolco.isActiv = false;
                    IKolco = null;
                    break;
                case Item.Mesto.grudi:
                    IGrudi.transform.SetParent(PanelItemsTR);
                    IGrudi.isActiv = false;
                    IGrudi = null;
                    break;
                case Item.Mesto.nogi:
                    INogi.transform.SetParent(PanelItemsTR);
                    INogi.isActiv = false;
                    INogi = null;
                    break;
                case Item.Mesto.botinki:
                    IBotinki.transform.SetParent(PanelItemsTR);
                    IBotinki.isActiv = false;
                    IBotinki = null;
                    break;
                default:
                    break;
            }
            ClosePanelViborItemEvent?.Invoke();
            AllStats();
            SortMasiv();
            SaveGame();
            return;
        }
        else
        {
            switch (mesto)
            {
                case Item.Mesto.golova:
                    if (IGolova != null)
                    {
                        IGolova.transform.SetParent(PanelItemsTR);
                        IGolova.isActiv = false;

                    }
                    _item.gameObject.transform.SetParent(GolovaTR);
                    IGolova = _item;
                    IGolova.isActiv = true;
                    break;
                case Item.Mesto.amulet:
                    if (IAmulet != null)
                    {
                        IAmulet.transform.SetParent(PanelItemsTR);
                        IAmulet.isActiv = false;

                    }
                    _item.gameObject.transform.SetParent(AmuletTR);
                    IAmulet = _item;
                    IAmulet.isActiv = true;
                    break;
                case Item.Mesto.kolco:
                    if (IKolco != null)
                    {
                        IKolco.transform.SetParent(PanelItemsTR);
                        IKolco.isActiv = false;

                    }
                    _item.gameObject.transform.SetParent(KolcoTR);
                    IKolco = _item;
                    IKolco.isActiv = true;
                    break;
                case Item.Mesto.grudi:
                    if (IGrudi != null)
                    {
                        IGrudi.transform.SetParent(PanelItemsTR);
                        IGrudi.isActiv = false;

                    }
                    _item.gameObject.transform.SetParent(GrudiTR);
                    IGrudi = _item;
                    IGrudi.isActiv = true;
                    break;
                case Item.Mesto.nogi:
                    if (INogi != null)
                    {
                        INogi.transform.SetParent(PanelItemsTR);
                        INogi.isActiv = false;

                    }
                    _item.gameObject.transform.SetParent(NogiTR);
                    INogi = _item;
                    INogi.isActiv = true;
                    break;
                case Item.Mesto.botinki:
                    if (IBotinki != null)
                    {
                        IBotinki.transform.SetParent(PanelItemsTR);
                        IBotinki.isActiv = false;

                    }
                    _item.gameObject.transform.SetParent(BotinkiTR);
                    IBotinki = _item;
                    IBotinki.isActiv = true;
                    break;
                default:
                    break;
            }
        }
        ClosePanelViborItemEvent?.Invoke();
        AllStats();
        SortMasiv();
        SaveGame();

    }
    public void SnatieVsechItemov()
    {
        if (IBotinki != null)
        {
            IBotinki.transform.SetParent(PanelItemsTR);

        }
        if (INogi != null)
        {
            INogi.transform.SetParent(PanelItemsTR);

        }
        if (IGrudi != null)
        {
            IGrudi.transform.SetParent(PanelItemsTR);

        }
        if (IKolco != null)
        {
            IKolco.transform.SetParent(PanelItemsTR);

        }
        if (IAmulet != null)
        {
            IAmulet.transform.SetParent(PanelItemsTR);

        }
        if (IGolova != null)
        {
            IGolova.transform.SetParent(PanelItemsTR);

        }
        SortMasiv();

    }
    public void NadetVseItems()
    {

        if (IBotinki != null)
        {
            IBotinki.transform.SetParent(BotinkiTR);

        }
        if (INogi != null)
        {
            INogi.transform.SetParent(NogiTR);

        }
        if (IGrudi != null)
        {
            IGrudi.transform.SetParent(GrudiTR);

        }
        if (IKolco != null)
        {
            IKolco.transform.SetParent(KolcoTR);

        }
        if (IAmulet != null)
        {
            IAmulet.transform.SetParent(AmuletTR);

        }
        if (IGolova != null)
        {
            IGolova.transform.SetParent(GolovaTR);

        }
        SortMasiv();
    }

    public void NadetItem(int cis)
    {

        foreach (var it in _inventary)
        {
            if (it.cislo == cis)
            {
                if (it.isActiv == true)
                {
                    if (it.mesto == Item.Mesto.golova)
                    {
                        IGolova = it;
                    }
                    if (it.mesto == Item.Mesto.amulet)
                    {
                        IAmulet = it;
                    }
                    if (it.mesto == Item.Mesto.kolco)
                    {
                        IKolco = it;
                    }
                    if (it.mesto == Item.Mesto.grudi)
                    {
                        IGrudi = it;
                    }
                    if (it.mesto == Item.Mesto.nogi)
                    {
                        INogi = it;
                    }
                    if (it.mesto == Item.Mesto.botinki)
                    {
                        IBotinki = it;
                    }

                }
            }
        }
        AllStats();
    }
    public void NadetItem(Item it)     // использовать только при загрузки инвентаря
    {
        if (it.mesto == Item.Mesto.golova)
        {
            IGolova = it;
            IGolova.transform.SetParent(GolovaTR);
        }
        if (it.mesto == Item.Mesto.amulet)
        {
            IAmulet = it;
            IAmulet.transform.SetParent(AmuletTR);
        }
        if (it.mesto == Item.Mesto.kolco)
        {
            IKolco = it;
            IKolco.transform.SetParent(KolcoTR);
        }
        if (it.mesto == Item.Mesto.grudi)
        {
            IGrudi = it;
            IGrudi.transform.SetParent(GrudiTR);
        }
        if (it.mesto == Item.Mesto.nogi)
        {
            INogi = it;
            INogi.transform.SetParent(NogiTR);
        }
        if (it.mesto == Item.Mesto.botinki)
        {
            IBotinki = it;
            IBotinki.transform.SetParent(BotinkiTR);
        }
        AllStats();
    }
    public void KuznajActive()
    {
        isKuznjaActive = true;
        SnatieVsechItemov();
        KuznicaActivEvent?.Invoke();



    }

    public void AllStats()
    {

        damage = 0;
        heals = 0;
        armor = 0;
        miss = 0;
        critChance = 0;
        critDamage = 0;
        attackSpeed = 0;
        movementSpeed = 0;

        if (IGolova)
        {
            var itGolova = IGolova.GetComponent<Item>();
            damage += itGolova.damage;
            heals += itGolova.heals;
            armor += itGolova.armor;
            miss += itGolova.miss;
            critChance += itGolova.critChance;
            critDamage += itGolova.critDamage;
            attackSpeed += itGolova.attackSpeed;
            movementSpeed += itGolova.shild;
        }
        if (IAmulet)
        {
            var itAmulet = IAmulet.GetComponent<Item>();
            damage += itAmulet.damage;
            heals += itAmulet.heals;
            armor += itAmulet.armor;
            miss += itAmulet.miss;
            critChance += itAmulet.critChance;
            critDamage += itAmulet.critDamage;
            attackSpeed += itAmulet.attackSpeed;
            movementSpeed += itAmulet.shild;
        }
        if (IKolco)
        {
            var itKolco = IKolco.GetComponent<Item>();
            damage += itKolco.damage;
            heals += itKolco.heals;
            armor += itKolco.armor;
            miss += itKolco.miss;
            critChance += itKolco.critChance;
            critDamage += itKolco.critDamage;
            attackSpeed += itKolco.attackSpeed;
            movementSpeed += itKolco.shild;
        }
        if (IGrudi)
        {
            var itGrudi = IGrudi.GetComponent<Item>();
            damage += itGrudi.damage;
            heals += itGrudi.heals;
            armor += itGrudi.armor;
            miss += itGrudi.miss;
            critChance += itGrudi.critChance;
            critDamage += itGrudi.critDamage;
            attackSpeed += itGrudi.attackSpeed;
            movementSpeed += itGrudi.shild;
        }
        if (INogi)
        {
            var itNogi = INogi.GetComponent<Item>();
            damage += itNogi.damage;
            heals += itNogi.heals;
            armor += itNogi.armor;
            miss += itNogi.miss;
            critChance += itNogi.critDamage;
            attackSpeed += itNogi.attackSpeed;
            movementSpeed += itNogi.shild;
        }
        if (IBotinki)
        {
            var itBotinki = IBotinki.GetComponent<Item>();
            damage += itBotinki.damage;
            heals += itBotinki.heals;
            armor += itBotinki.armor;
            miss += itBotinki.miss;
            critChance += itBotinki.critChance;
            critDamage += itBotinki.critDamage;
            attackSpeed += itBotinki.attackSpeed;
            movementSpeed += itBotinki.shild;
        }
        itemSingolton.SetParametrInventary(damage, heals, armor, miss, critChance, critDamage, attackSpeed, movementSpeed);
        _uIAllParamert.SetParamentHaracterictic();

    }
    public void SortMasiv()              // Сортировка айтемов 
    {

        for (int i = 0; i < transform.childCount; i++)
        {
            for (int j = i + 1; j < transform.childCount; j++)
            {
                if (transform.GetChild(i).GetComponent<Item>().id < transform.GetChild(j).GetComponent<Item>().id)
                {
                    transform.GetChild(j).SetSiblingIndex(i);
                }
                else if (transform.GetChild(i).GetComponent<Item>().id == transform.GetChild(j).GetComponent<Item>().id)
                {
                    if (transform.GetChild(i).GetComponent<Item>().level < transform.GetChild(j).GetComponent<Item>().level)
                    {
                        transform.GetChild(j).SetSiblingIndex(i);
                    }
                }
            }
        }
    }
    public void SortMasiv(int id, bool b)              // Сортировка айтемов 
    {
        foreach (Transform child in transform)
        {
            if (child.GetComponent<Item>().id == id)
            {
                child.SetAsFirstSibling();
            }

        }
    }


    public void IsNoIneracableItem(int id)
    {
        foreach (Transform child in transform)
        {
            if (child.GetComponent<Item>().id != id)
            {
                child.GetComponent<Button>().interactable = false;
            }
        }
    }
    public void IsYesIneracableItem()
    {
        foreach (Transform child in transform)
        {

            child.GetComponent<Button>().interactable = true;

        }
    }

    public void SortMasiv(int id)           //сортировка по ид для кузни. и делает айтемы ненажимаемые
    {
        foreach (Transform child in transform)
        {
            if (child.GetComponent<Item>().id == id)
            {
                child.SetAsFirstSibling();
            }
            else
            {
                child.GetComponent<Button>().interactable = false;
            }
        }
    }

    public void ResetInventary()
    {
        foreach (Transform child in PanelItemsTR) 
        {
            DeleteItem(child.GetComponent<Item>());
           // Destroy(child.gameObject); 
        }
        foreach (Transform child in NogiTR) DeleteItem(child.GetComponent<Item>());
        foreach (Transform child in BotinkiTR) DeleteItem(child.GetComponent<Item>());
        foreach (Transform child in GrudiTR) DeleteItem(child.GetComponent<Item>());
        foreach (Transform child in KolcoTR) DeleteItem(child.GetComponent<Item>());
        foreach (Transform child in AmuletTR) DeleteItem(child.GetComponent<Item>());
        foreach (Transform child in GolovaTR) DeleteItem(child.GetComponent<Item>());

        INogi = null;
        IBotinki = null;
        IGrudi = null;
        IKolco = null;
        IAmulet = null;
        IGolova = null;
        _inventary.Clear();
        
    }

    
    #region Сохранение

    public void SaveGame()
    {
        _saver.SaveDataInventaryAll(_inventary);
    }


    public void LoadGame()
    {
        #region //старая загрузка
        //if (File.Exists(Application.persistentDataPath + "/Inventary.dat"))
        //{
        //    BinaryFormatter bf = new BinaryFormatter();
        //    FileStream file =
        //      File.Open(Application.persistentDataPath
        //      + "/Inventary.dat", FileMode.Open);
        //    SaveLoad data = (SaveLoad)bf.Deserialize(file);
        //    file.Close();

        //    idSave = data.idS;            // для сохранения редактировать тут
        //    lvlSave = data.lvlS;
        //    cisloSave = data.cisloS;

        //    cisloBotinkiSave = data.cisloSB;
        //    cisloNogiSave = data.cisloSN;
        //    cisloKolcoSave = data.cisloSK;
        //    cisloGrudiSave = data.cisloSGR;
        //    cisloAmuletSave = data.cisloSA;
        //    cisloGolovaSave = data.cisloSGol;



        //    for (int i = 0; i < idSave.Length; i++)
        //    {
        //        foreach (var item in itemSingolton.allitems)
        //        {
        //            if (item.GetComponent<Item>().id == idSave[i])
        //            {
        //                var obj = Instantiate(item, transform);                   
        //                _inventary.Add(obj);

        //                obj.GetComponent<Item>().level = lvlSave[i];
        //                obj.GetComponent<Item>().cislo = cisloSave[i];       // для сохранения редактировать тут

        //                obj.GetComponent<Item>().SetParametr();
        //            }
        //        }
        //    }
        //}
        #endregion

        ResetInventary();
        var inventary = _saver.LoadDataInventary();
        foreach (var itemSaved in inventary)
        {
            foreach (var item in itemSingolton.allitems)
            {
                if (itemSaved.id == item.id)
                {
                    var newItem = Instantiate(item, PanelItemsTR);
                    newItem.cislo = itemSaved.cislo;
                    newItem.level = itemSaved.level;
                    newItem.isActiv = itemSaved.isActive;
                    newItem.SetParametr();
                    newItem.GetComponent<Button>().onClick.AddListener(delegate { ViborItema(newItem); });
                    _inventary.Add(newItem);
                    if (newItem.isActiv == true)
                    {
                        NadetItem(newItem);
                    }


                }
            }
        }
        SortMasiv();
        _sortItemIsKuznica.SetActivSeslTexNewKuznica();

    }
   
    #endregion
}



