using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopKontrol : MonoBehaviour
{
    public UnityEngine.UI.Button btn;
    public UnityEngine.UI.Text zaman, can, durum;
    private Rigidbody rg;
    public float Hiz = 2f;
    float zamanSayaci = 30;
    int canSayaci = 3;
    bool oyunDevam = true;
    bool oyunTamam = false;
    // Start is called before the first frame update
    void Start()
    {
        can.text = canSayaci + "";
        rg = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (oyunDevam && !oyunTamam)
        {
            zamanSayaci -= Time.deltaTime; //zamanSayaci=zamanSayaci - Time.deltaTime;
            zaman.text = (int)zamanSayaci + "";
            if (Input.GetKeyDown("escape"))
            {
                oyunDevam = false;

            }
        }
        
        /*else if(!oyunTamam)
        {
            durum.text = "Oyun Tamamlanamadý!";

            btn.gameObject.SetActive(true);

        } */
        if (zamanSayaci < 0)
        {
            oyunDevam = false;
        }

    }

    void FixedUpdate()
    {
        if (oyunDevam && !oyunTamam)
        {
            float yatay = Input.GetAxis("Horizontal");
            float dikey = Input.GetAxis("Vertical");
            Vector3 kuvvet = new Vector3(-dikey, 0, yatay);
            rg.AddForce(kuvvet * Hiz);
    
        }
        else
        {
            rg.velocity = Vector3.zero;
            rg.angularVelocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        string objIsmi = collision.gameObject.name;
        if (objIsmi.Equals("Bitiþ"))
        {
            //print("Oyun Tamamlandý!");
            oyunTamam = true;
            durum.text = "Oyun Tamamlandý!";
            btn.gameObject.SetActive(true);
        }
        else if(!objIsmi.Equals("LabirentZemin")&& !objIsmi.Equals("Zemin"))
        {
            canSayaci -= 1;
            can.text = canSayaci+"";
            if (canSayaci == 0)
            {
                oyunDevam = false;
                durum.text = "Oyun Tamamlanamadý!";

                btn.gameObject.SetActive(true);
            }
        }
    }
}
