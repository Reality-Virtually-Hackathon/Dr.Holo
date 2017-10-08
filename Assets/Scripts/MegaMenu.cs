using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaMenu : MonoBehaviour {
    public Menu[] menus;

    public void HideOthers(int visibleMenuIndex)
    {
        for(int i = 0; i < menus.Length; i++)
        {
            if (i != visibleMenuIndex)
            {
                menus[i].NewPage(0);
            }
        }
        
    }
}
