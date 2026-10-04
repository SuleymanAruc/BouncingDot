using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Donus : MonoBehaviour
{
    public float beklemeSuresi = 0.0001f;
    bool donuyorMu = false;

    void Start()
    {
        
    }

   
    void Update()
    {
    if(Input.GetMouseButtonDown(0)&& !donuyorMu)
        {
            StartCoroutine(AltýgenDonus());
        }
    }
    IEnumerator AltýgenDonus()
    {
        donuyorMu = true;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, 0));
        if (Input.GetMouseButtonDown(0)&& mousePos.x>0)
        {
            transform.Rotate(0, 0, -30);
            yield return new WaitForSeconds(beklemeSuresi);
            transform.Rotate(0, 0, -30);

        }
        else if (Input.GetMouseButtonDown(0) && mousePos.x < 0)
        {
            transform.Rotate(0, 0, 30);
            yield return new WaitForSeconds(beklemeSuresi);
            transform.Rotate(0, 0, 30);
        }
        donuyorMu = false;
    }
}
