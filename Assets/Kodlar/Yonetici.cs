using UnityEngine;

public class Yonetici : MonoBehaviour
{
    public GameObject altigen,top,baslangicYazisi;
    public Transform baslangicPos;
    private Rigidbody2D topRb;
    private bool basla = false;
    void Start()
    {
        altigen.GetComponent<Donus>().enabled = false;
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&& !basla)
        {
            top.transform.position = baslangicPos.position;
            top.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            altigen.GetComponent<Donus>().enabled = true;
            baslangicYazisi.SetActive(false);
            basla = true;
        }
    }
}
