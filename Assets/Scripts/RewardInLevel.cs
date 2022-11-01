using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;

public class RewardInLevel : MonoBehaviour
{
    public int gold;
    public int diamod;
    public List<GameObject> _rewardGO;
    public List<GameObject> _rewardPart;
    public List<int> addedPartID;
    public GameObject _panelPater;
    public CanvasGroup _canvasGroup;
    public GameObject _goldReward;
    public TMP_Text _tGoldReward;
    public GameObject _diamondReward;
    public TMP_Text _tDiamondReward;
    public GameObject _goTextDobica;

    public Text _tGold;

    private void Start()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.blocksRaycasts = false;
        gold = 0;
        diamod = 0;
        _tGold.text = 0.ToString();
        _tGoldReward.text = 0.ToString();
        _diamondReward.SetActive(false);
        _goldReward.SetActive(false);
    }
    public void OnPauza()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;      
        Time.timeScale = 0;
    }
    public void AddItemList(GameObject go)
    {
        var item = Instantiate(go, _panelPater.transform);
        _rewardGO.Add(item);
        ChekListCount();
    }
    public void AddPartList(GameObject go)
    {
        var idGO = go.GetComponent<PartInfo>().ID;
        if (HavePatr(idGO))
        {         
            for (int i = 0; i < _rewardPart.Count; i++)
            {
                if(_rewardPart[i].GetComponent<PartInfo>().ID == idGO)
                {
                    _rewardPart[i].GetComponent<PartInfo>().SetCount(_rewardPart[i].GetComponent<PartInfo>().Count + 1);
                    _rewardPart[i].GetComponent<PartInfo>().SetTextCount();
                    return;
                }
                
            } 
        }
        else
        {
            var part = Instantiate(go, _panelPater.transform);
            _rewardGO.Add(part);
            _rewardPart.Add(part);
            ChekListCount();
            part.GetComponent<PartInfo>().SetCount(go.GetComponent<PartInfo>().Count + 1);
            part.GetComponent<PartInfo>().SetTextCount();
        }
    }
    public bool HavePatr(int id)
    {
        foreach (var part in _rewardPart)
        {
            if (part.GetComponent<PartInfo>().ID == id)
            {
                return true;
            }
        }
        return false;

    }
    public void AddGold(int count)
    {
        if (_goldReward.activeSelf == false)
        {
            _goldReward.SetActive(true);
            ChekListCount();
        }
        gold += count;
        _tGoldReward.text = gold.ToString();
        Invoke("ResetTextGold", 2f);
    }
    public void AddDianod(int count)
    {
        if (_diamondReward.activeSelf == false)
        {
            _diamondReward.SetActive(true);
            ChekListCount();
        }
        diamod += count;
        _tDiamondReward.text = diamod.ToString();
    }

    public void ResetTextGold()
    {
        _tGold.DOText(gold.ToString(), 0.5f, true, ScrambleMode.Numerals);
    }
    public void ChekListCount()
    {
        if (_rewardGO.Count > 14&& _diamondReward.activeSelf == true&& _goldReward.activeSelf == true || _rewardGO.Count>15&& _goldReward.activeSelf == true||
            _rewardGO.Count > 15 && _diamondReward.activeSelf == true||_rewardGO.Count>16)
        {
            Group();
        }
    }
    public void Group()
    {
        _panelPater.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 360);
        _goTextDobica.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 95);
        _goTextDobica.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 95);
    }
    public void OfPauza()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.blocksRaycasts = false;
        Time.timeScale = 1;
    }
    public void GoTOMenu()
    {
        
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

   
}
