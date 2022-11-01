using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartPlayerPrefs : MonoBehaviour
{
    public void IsPlayerPrefsIsEists()
    {
        if (!PlayerPrefs.HasKey("item"))
        {
            PlayerPrefs.SetInt("part", 1);
            PlayerPrefs.SetInt("p0", 0);
            PlayerPrefs.SetInt("p1", 0);
            PlayerPrefs.SetInt("p2", 0);
            PlayerPrefs.SetInt("p3", 0);
            PlayerPrefs.SetInt("p4", 0);
            PlayerPrefs.SetInt("p5", 0);
            PlayerPrefs.SetInt("p6", 0);
            PlayerPrefs.SetInt("p7", 0);
            PlayerPrefs.SetInt("p8", 0);
            PlayerPrefs.SetInt("p9", 0);
            PlayerPrefs.SetInt("p10", 0);
            PlayerPrefs.SetInt("p11", 0);
            PlayerPrefs.SetInt("p12", 0);
            PlayerPrefs.SetInt("p13", 0);
            PlayerPrefs.SetInt("p14", 0);
            PlayerPrefs.SetInt("p15", 0);
            PlayerPrefs.SetInt("p16", 0);
            PlayerPrefs.SetInt("p17", 0);
            PlayerPrefs.SetInt("p18", 0);
            PlayerPrefs.SetInt("p19", 0);
            PlayerPrefs.SetInt("p20", 0);
            PlayerPrefs.SetInt("p21", 0);
            PlayerPrefs.SetInt("p22", 0);
            PlayerPrefs.SetInt("p23", 0);
            PlayerPrefs.SetInt("p24", 0);
            PlayerPrefs.SetInt("p25", 0);
            PlayerPrefs.SetInt("p26", 0);
            PlayerPrefs.SetInt("p27", 0);
            PlayerPrefs.SetInt("p28", 0);
            PlayerPrefs.SetInt("p29", 0);
            PlayerPrefs.SetInt("p30", 0);
            PlayerPrefs.SetInt("p31", 0);
            PlayerPrefs.SetInt("p32", 0);
            PlayerPrefs.SetInt("p33", 0);
            PlayerPrefs.SetInt("p34", 0);
            PlayerPrefs.SetInt("p35", 0);
            PlayerPrefs.SetInt("p36", 0);
            PlayerPrefs.SetInt("p37", 0);
            PlayerPrefs.SetInt("p38", 0);
            PlayerPrefs.SetInt("p39", 0);
            PlayerPrefs.SetInt("p40", 0);
            PlayerPrefs.SetInt("p41", 0);
            PlayerPrefs.SetInt("p42", 0);
            PlayerPrefs.SetInt("p43", 0);
            PlayerPrefs.SetInt("p44", 0);
            PlayerPrefs.SetInt("p45", 0);
            PlayerPrefs.SetInt("p46", 0);
            PlayerPrefs.SetInt("p47", 0);
            PlayerPrefs.SetInt("p48", 0);
            PlayerPrefs.SetInt("p49", 0);
            PlayerPrefs.SetInt("p50", 0);
            PlayerPrefs.SetInt("p51", 0);
            PlayerPrefs.SetInt("p52", 0);
            PlayerPrefs.SetInt("p53", 0);
            PlayerPrefs.SetInt("p54", 0);
            PlayerPrefs.SetInt("p55", 0);
            PlayerPrefs.SetInt("p56", 0);
            PlayerPrefs.SetInt("p57", 0);
            PlayerPrefs.SetInt("p58", 0);
            PlayerPrefs.SetInt("p59", 0);
            PlayerPrefs.SetInt("p60", 0);
            PlayerPrefs.SetInt("p61", 0);
            PlayerPrefs.SetInt("p62", 0);
            PlayerPrefs.SetInt("p63", 0);
            PlayerPrefs.SetInt("p64", 0);
            PlayerPrefs.SetInt("p65", 0);
            PlayerPrefs.SetInt("p66", 0);
            PlayerPrefs.SetInt("p67", 0);
            PlayerPrefs.SetInt("p68", 0);
            PlayerPrefs.SetInt("p69", 0);
            PlayerPrefs.SetInt("p70", 0);
            PlayerPrefs.SetInt("p71", 0);
            PlayerPrefs.SetInt("p72", 0);
            PlayerPrefs.SetInt("p73", 0);
            PlayerPrefs.SetInt("p74", 0);
            PlayerPrefs.SetInt("p75", 0);
            PlayerPrefs.SetInt("p76", 0);
            PlayerPrefs.SetInt("p77", 0);
            PlayerPrefs.SetInt("p78", 0);
            PlayerPrefs.SetInt("p79", 0);
            PlayerPrefs.SetInt("p80", 0);
            PlayerPrefs.SetInt("p81", 0);
            PlayerPrefs.SetInt("p82", 0);
            PlayerPrefs.SetInt("p83", 0);
            PlayerPrefs.SetInt("p84", 0);
            PlayerPrefs.SetInt("p85", 0);
            PlayerPrefs.SetInt("p86", 0);
            PlayerPrefs.SetInt("p87", 0);
            PlayerPrefs.SetInt("p88", 0);
            PlayerPrefs.SetInt("p89", 0);
            PlayerPrefs.SetInt("p90", 0);
            PlayerPrefs.SetInt("p91", 0);
            PlayerPrefs.SetInt("p92", 0);
            PlayerPrefs.SetInt("p93", 0);
            PlayerPrefs.SetInt("p94", 0);
            PlayerPrefs.SetInt("p95", 0);
            PlayerPrefs.SetInt("p96", 0);
            PlayerPrefs.SetInt("p97", 0);
            PlayerPrefs.SetInt("p98", 0);
            PlayerPrefs.SetInt("p99", 0);
            PlayerPrefs.SetInt("p100", 0);
        }
    }

    public int GetFirstNullIndex()
    {
        for (int i = 0; i < 1000; i++)
        {
            if(PlayerPrefs.GetInt($"p{i}") == 0)
            {
                return i;
            }
        }
        return 0;
    }
    public void SetIdPartPlayerPrefs(int id)
    {
        PlayerPrefs.SetInt($"p{GetFirstNullIndex()}", id);
    }
    public void SetIdPartPlayerPrefs(int id,int count) 
    {
        for (int i = 0; i < count; i++)
        {
            SetIdPartPlayerPrefs(id);
        }
    }


}
