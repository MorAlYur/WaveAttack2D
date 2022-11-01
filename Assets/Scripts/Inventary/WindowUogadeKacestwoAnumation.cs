using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowUogadeKacestwoAnumation : MonoBehaviour
{
    public WindowUpgradKachestvo _windowUpgradKachestvo;


    public void EventVan()
    {
        _windowUpgradKachestvo.StartVanParticle();
    }
    public void EventTwo()
    {
        _windowUpgradKachestvo.StoptVanParticle();
        _windowUpgradKachestvo.StartTwoParticle();
        _windowUpgradKachestvo.SetItemAnimation();
    }
    public void EventFri()
    {
        _windowUpgradKachestvo.StopTwoParticle();


    }
    public void EventFoo()
    {
        
        _windowUpgradKachestvo.OpenTwoWindow();
    }

}
