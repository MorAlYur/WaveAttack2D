using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class LevelPlayer : MonoBehaviour
{
    public event Action ActivBonusMenuEvent;

    public int _expNew;

    public bool newLevel;

    public int _allExp;
    public int _exp;
    public int _expDop;
    public int[] _expInLevel;
    public int _level;
    public int _maxLevel;

   
    
    public Text _tLevel;
    public Slider _slider;

    public bool clicButtonBonus;
    public float _timeSlider—hangeValue;


    private void Start()
    {
        _level = 1;
        _exp = 0;
        SliderExpMinMax(0, _expInLevel[_level]);
        ExpPlus(0, 0);

        StartCoroutine(DopAbility());
        //LelelUpInStart(); 
    }

    public async void LelelUpInStart()
    {
        await Task.Delay(1000);
        Time.timeScale = 0;
        ActivBonusMenuEvent?.Invoke();
        StartCoroutine(LevelUp());

    }
    IEnumerator DopAbility()
    {
        yield return new WaitForSeconds(0.5f);
        ActivBonusMenuEvent?.Invoke();
        Time.timeScale = 0;
        yield return new WaitUntil(() => clicButtonBonus == true);
        yield return null;
        Time.timeScale = 1;
    }
    public void AddExp(int exp)
    {
        _allExp += exp;
        if (_expNew==0&&newLevel==false)
        {
            _expNew = exp;
            PlusExp(_expNew);
        }
        else
        {
            _expDop += exp;
        } 

    }
    public void PlusExp(int exp)
    {
        if (_level < _maxLevel)
        {
            
           
            if (exp < _expInLevel[_level] - _exp)
            {
                _exp += exp;
                _expNew -= exp;
                ExpPlus(_exp - exp, _exp);
                newLevel = false;
                
               
            }
            else
            {

                newLevel = true;
                int expNuz = _expInLevel[_level] - _exp;
                _exp += expNuz;
                _expNew -= expNuz;
                ExpPlus(_exp, _exp);
                clicButtonBonus = false;
                StartCoroutine(LevelUp());

            }
        }
        else
        {

            SliderExpMinMax(0, 1);
            ExpPlus(1, 1);
        }

    }
   

    IEnumerator LevelUp()
    {
        yield return new WaitForSeconds(_timeSlider—hangeValue+0.1f);
        ActivBonusMenuEvent?.Invoke();
        Time.timeScale = 0;
        yield return new WaitUntil(() => clicButtonBonus == true);
        _exp =0;
        SliderExpMinMax(0, _expInLevel[_level+1]);
        _level++;
        _tLevel.text = _level.ToString();
        yield return null;
        Time.timeScale = 1;
        _slider.value = 0;
        if (_expNew != 0)
        {
            PlusExp(_expNew);
        }
        else if (_expNew==0&&_expDop != 0)
        {
            _expNew = _expDop;
            _expDop = 0;
            newLevel = false;
            PlusExp(_expNew);
        }
        else
        {
            newLevel = false;
        }
    }

    private void SliderExpMinMax(int minValue, int maxValue)
    {
        _slider.minValue = minValue;
        _slider.maxValue = maxValue;

    }
    private void ExpPlus(int oldExp, int newExp)
    {
        _slider.DOValue(newExp, _timeSlider—hangeValue);
    }

}
