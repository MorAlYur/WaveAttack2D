using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Zenject;
using System.Threading.Tasks;

public class UIGoldMenu : MonoBehaviour
{

    public Text goldText;
    public Text diamondText;

    [SerializeField] private Text _flyGoldText;
    [SerializeField] private Text _flyDiamondText;

    [SerializeField] private Color _colorMinusGold;
    [SerializeField] private Color _colorAddGold;
    [SerializeField] private Color _colorAddDiamond;
    [SerializeField] private int _timeInMlSecDeleyRewardOnLevel;
    [SerializeField] private float _timeOnScreenTextRewardLevel; 
    [Inject]
    public Bank _bank;
    
    private void OnEnable()
    {
        _bank.bankGoldEvent += BANK_bankGoldEvent;
        _bank.bankDiamodEvent += BANK_bankDiamodEvent;
        _bank.SetGoldAndDiamindOldEvent += SetGoldAndDiamondInStartScene;
    }
    private void OnDisable()
    {
        _bank.bankGoldEvent -= BANK_bankGoldEvent;
        _bank.bankDiamodEvent -= BANK_bankDiamodEvent;
        _bank.SetGoldAndDiamindOldEvent -= SetGoldAndDiamondInStartScene;
    }
    private void Start()
    {
        _bank.SetInitialValues();
        SetGoldInLevel();
    }
    private async void SetGoldInLevel()
    {
        await Task.Delay(_timeInMlSecDeleyRewardOnLevel);
        _bank.AddGoldAndDiamondInLevel();
    }

    private void SetGoldAndDiamondInStartScene(int goldOld, int DiamondOld)
    {
        goldText.text = goldOld.ToString();
        diamondText.text = DiamondOld.ToString();
        _flyDiamondText.gameObject.SetActive(false);
        _flyGoldText.gameObject.SetActive(false);
    }

    private void BANK_bankDiamodEvent(int oldDiamodValue, int newDiamodValue)
    {
        _flyDiamondText.gameObject.SetActive(true);
        if (newDiamodValue - oldDiamodValue < 0)
        {
            _flyDiamondText.text =  (newDiamodValue - oldDiamodValue).ToString();
            _flyDiamondText.color = _colorMinusGold;
        }
        else
        {
            _flyDiamondText.text = "+" + (newDiamodValue - oldDiamodValue).ToString();
            _flyDiamondText.color = _colorAddDiamond;

        }
        diamondText.DOText(newDiamodValue.ToString(), 0.5f, true, ScrambleMode.Numerals);
        Invoke("HideDiamondText", _timeOnScreenTextRewardLevel);
    }

    private void BANK_bankGoldEvent(int oldGoldValue, int newGoldValue)
    { 
        _flyGoldText.gameObject.SetActive(true);
        if(newGoldValue - oldGoldValue < 0)
        {
            _flyGoldText.text =  (newGoldValue - oldGoldValue).ToString();
            _flyGoldText.color = _colorMinusGold;
        }
        else
        {
            _flyGoldText.text = "+" + (newGoldValue - oldGoldValue).ToString();
            _flyGoldText.color = _colorAddGold;

        }
        goldText.DOText(newGoldValue.ToString(),0.5f, true, ScrambleMode.Numerals);
        Invoke("HideGoldText", _timeOnScreenTextRewardLevel);
    }
    private void HideGoldText()
    {
        _flyGoldText.gameObject.SetActive(false);
    } 
    private void HideDiamondText()
    {
        _flyDiamondText.gameObject.SetActive(false);
    }
   
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _bank.AddGold(5000);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _bank.SpendGold(30);
        } 
        if (Input.GetKeyDown(KeyCode.Z))
        {
            _bank.AddDiamond(30);
        }
         if (Input.GetKeyDown(KeyCode.X))
        {
            _bank.SpendDiamond(50);
        }

        
    }
}
