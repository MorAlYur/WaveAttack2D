using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUpMenu : MonoBehaviour
{
    public List<GameObject> bonusAvailable = new List<GameObject>();
    public int[] vibraniBonus = new int[3];
    public Transform _tBonus;
    public LevelPlayer _levelPlayer;
    public GameObject GO;


    public int countPerebo;
    public float timePerebor;
    public float timeToActivateQestion;
    public HelpTextLevelUPMenu _helpTextLevelUPMenu;


    private void OnEnable()
    {
        _levelPlayer.ActivBonusMenuEvent += ActivBonusMenu;
    }
    private void OnDisable()
    {
        _levelPlayer.ActivBonusMenuEvent -= ActivBonusMenu;
    }
    private void ActivBonusMenu()
    {
       // LevelUp();
        GoSetActiv(true);
        SetActivFalsAll();
        StartCoroutine(StartBonus());
    }

    public void GoSetActiv(bool tf)
    {
        GO.SetActive(tf);
    }
    IEnumerator StartBonus()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return StartCoroutine(BonusPerebor(i));
        }
        yield return new WaitForSecondsRealtime(timeToActivateQestion);
        _helpTextLevelUPMenu.ActivButtonQestion();
    }
    IEnumerator BonusPerebor(int numberSkill)
    {
        for (int i = 0; i < countPerebo; i++)
        {
            var r = Random.Range(0, bonusAvailable.Count);
            if (vibraniBonus[0] == r || vibraniBonus[1] == r)
            {
                i--;
                continue; 
            }

            bonusAvailable[r].SetActive(true);
            yield return new WaitForSecondsRealtime(timePerebor);
            if (i < countPerebo-1)
            {
                bonusAvailable[r].SetActive(false);

            }
            else
            {
                vibraniBonus[numberSkill] = r;
                bonusAvailable[r].transform.SetSiblingIndex(numberSkill);

            }
        }
    }
   
    public void SetActivFalsAll()
    {
        foreach (Transform child in _tBonus)
        {
            child.gameObject.SetActive(false);
        }
        for (int i = 0; i < vibraniBonus.Length; i++)
        {
            vibraniBonus[i] = 9999;
        }
        _helpTextLevelUPMenu.HideAll();

    }
   
    public void AddBon(GameObject bon)
    {
        bonusAvailable.Add(bon);
    }
    public void RemovBon(GameObject bon)
    {
        if (bonusAvailable.Contains(bon))
        {
            bonusAvailable.Remove(bon);
        }
    }


}
