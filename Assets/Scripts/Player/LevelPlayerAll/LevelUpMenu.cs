using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class LevelUpMenu : MonoBehaviour
{
    public int[] vibraniBonus = new int[3];
    public LevelPlayer _levelPlayer;
    public GameObject GO;


    public int[] countPerebo = new int[3];
    public float timePerebor;
    public float timeToActivateQestion;
    public HelpTextLevelUPMenu _helpTextLevelUPMenu;

    [SerializeField] private SkilsControls _skilsControls;
    [SerializeField] private Image[] images;
    [SerializeField] private RectTransform[] rectTransforms;
    public Skils[] skils;
    [SerializeField] private Text[] textPodpis;
    public LevelTextExplain _levelTextExplain;
    [SerializeField] private MenuPauza _menuPauza; 




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
        GoSetActiv(true);
        SetActivFalsAll();
        skils = new Skils[3];
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
            images[i].gameObject.SetActive(true);
            StartCoroutine(BonusPerebor(i));
        }
        yield return new WaitForSecondsRealtime(timeToActivateQestion);
        _helpTextLevelUPMenu.ActivButtonQestion();
    }
    IEnumerator BonusPerebor(int number)
    {
        for (int i = 0; i < countPerebo[number]; i++)
        {
            var r = Random.Range(0, _skilsControls._activSkills.Count);
            if (r == vibraniBonus[0]) 
            {
                i--;
                continue;
            }
            else if(r == vibraniBonus[1])
            {
                i--;
                continue;
            }

            rectTransforms[number].anchoredPosition = new Vector2(0, 360);

            images[number].sprite = _skilsControls._activSkills[r].Image;
            if (i < countPerebo[number] - 1)
            {
                rectTransforms[number].DOAnchorPosY(-360f, timePerebor-0.03f).SetUpdate(UpdateType.Normal, true);
            }
            else
            {
                rectTransforms[number].DOAnchorPosY(-0f, timePerebor - 0.03f).SetUpdate(UpdateType.Normal, true);
            }
            yield return new WaitForSecondsRealtime(timePerebor);
            if (i == countPerebo[number] -1)
            {
                vibraniBonus[number] = r;
                skils[number] = _skilsControls._activSkills[r];
                textPodpis[number].gameObject.SetActive(true);
                textPodpis[number].text = LocalizationManager.Localize(skils[number].ShortSpecification);
            }
        }
    }
   
    public void SetActivFalsAll()
    {
        foreach (var text in textPodpis)
        {
            text.gameObject.SetActive(false);
        }
        for (int i = 0; i < vibraniBonus.Length; i++)
        {
            vibraniBonus[i] = 9999;
        }
        _helpTextLevelUPMenu.HideAll();
    }

    public void ActivateSkill(int number)
    {
        var activateSkill = skils[number];
        _levelTextExplain.ActivateBonText(LocalizationManager.Localize(activateSkill.ShortSpecification),
                                           LocalizationManager.Localize(activateSkill.FullSpecification));
        activateSkill.Activate();
        _levelPlayer.clicButtonBonus = true;

        _menuPauza.SetSkillInMenuPauza(activateSkill.Image, activateSkill.ShortSpecification, activateSkill.FullSpecification);

        GoSetActiv(false);
    }
   
}
