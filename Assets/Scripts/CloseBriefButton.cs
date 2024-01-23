using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseBriefButton : MonoBehaviour
{
    private GameObject FocusPlanet;
    
    // Start is called before the first frame update
    public void SetFocus(GameObject new_FocusPlanet){
        FocusPlanet = new_FocusPlanet;
    }

    public void OnClick(){
        FocusPlanet.GetComponent<PlanetClick>().ResetScript();
    }
}
