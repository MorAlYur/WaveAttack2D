using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerTextDamageFly : MonoBehaviour
{
    public Transform tContainer;
    public int poolCount;
    public bool autoExpant;

    public TextDamageFly prefabTextDamageNormal;
    public PoolMono<TextDamageFly> poolTextDamage;

    public int targetSize;
    public int sizeNorm;
    public int sizeCrit;
    public int sizeFire;
    public int sizeToxic;
    public int sizeHeals;

    public Color targetColor;
    public Color colorNorm;
    public Color colorCrit;
    public Color colorFire;
    public Color colorToxic;
    public Color colorHeals;


    void Start()
    {
        poolTextDamage = new PoolMono<TextDamageFly>(prefabTextDamageNormal, poolCount,tContainer);
        poolTextDamage.autoExpand = autoExpant;
    }
    private void OnEnable()
    {
        EmenyHPManager.TextFlyEvent += EmenyHPManager_TextFly;
    }
    private void OnDisable()
    {
        EmenyHPManager.TextFlyEvent -= EmenyHPManager_TextFly;
    }
    private void EmenyHPManager_TextFly(Vector3 position, int value, bool isFire, bool isToxic, bool isCrit, bool isDamage)
    {
        var flyText = poolTextDamage.GetFreeElement(position);
        if (isDamage == false)
        {
            targetColor = colorHeals;
            targetSize = sizeHeals;
        }
        else
        {
            if (isCrit == true)
            {
                targetColor = colorCrit;
                targetSize = sizeCrit;
                flyText.transform.SetAsLastSibling();
            }
            else
            {
                if (isFire == true)
                {
                    targetColor = colorFire;
                    targetSize = sizeFire;
                }
                else if (isToxic == true)
                {
                    targetColor = colorToxic;
                    targetSize = sizeToxic;
                }
                else
                {
                    targetColor = colorNorm;
                    targetSize = sizeNorm;
                }
            }
        }
        flyText.SetParametrText(value, targetSize, targetColor);
        
    }
}
