using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Menu : MonoBehaviour {

    public List<GameObject> pages = new List<GameObject>();
    public int currentPageIndex = 0;
    public GameObject currentPage;
    public CanvasGroup cg;

    // Update is called once per frame
    void Update() {

    }

    public void NewPage(int newPage)
    {
        if(newPage != currentPageIndex)
            StartCoroutine("ChangePage", newPage);
    }

    public IEnumerator ChangePage(int newPage)
    {
        //Close page
        currentPage.SetActive(false);

        //Open new page
        currentPageIndex = newPage;
        currentPage = pages[currentPageIndex];
        currentPage.SetActive(true);

        yield return 0;

    }




}

