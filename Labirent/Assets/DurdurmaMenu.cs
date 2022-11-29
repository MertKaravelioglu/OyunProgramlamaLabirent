using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DurdurmaMenu : MonoBehaviour
{
    public GameObject durdurmaPanel;
    void Start()
    {
        durdurmaPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            durdurmaPanel.SetActive(true);
        }
    }

    public void butons(int deger)
    {
        if(deger == 0)
        {
            durdurmaPanel.SetActive(false);
        }
        else if (deger == -1)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
