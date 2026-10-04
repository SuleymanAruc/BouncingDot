using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
public class Top : MonoBehaviour
{
    public Color color1, color2, color3, color4, color5, color6;
    private SpriteRenderer topRenderer;
    private Rigidbody2D topRb;
    public float ziplamaGucu;
    public Text skorYazisi, rekorYazisi;
    private int skor, rekor;
    private int lastGravityUpdateScore = 0;
   
    void Start()
    {
        topRb = GetComponent<Rigidbody2D>();
        topRenderer = GetComponent<SpriteRenderer>();
        if (PlayerPrefs.HasKey("rekor"))
        {
            rekor = PlayerPrefs.GetInt("rekor", rekor);
            rekorYazisi.text = "rekor:" + rekor.ToString();
        }
        else
        {
            rekor = 0;
        }
    }
    void Update()
    {
        if (51>skor && skor > 0 && skor % 10 == 0 && skor != lastGravityUpdateScore)
        {
            IncreaseGravity();
            lastGravityUpdateScore = skor; 
        }

    }
    private void OnCollisionEnter2D(Collision2D temas)
    {

        if (temas.gameObject.tag == "zemin")
        {
            topRb.linearVelocity = Vector2.up * ziplamaGucu / 2;
        }

        if (temas.gameObject.tag == "kenar")
        {
            topRb.linearVelocity = Vector2.up * ziplamaGucu;
            if (topRenderer.color == temas.gameObject.GetComponent<SpriteRenderer>().color)
            {
                GetComponent<AudioSource>().Play();
                skor++;
                skorYazisi.text = "Skor: " + skor.ToString();
                if (skor > rekor)
                {
                    rekor = skor;
                    rekorYazisi.text = "rekor:" + rekor.ToString();
                    PlayerPrefs.SetInt("rekor", rekor);

                }
            }
            else if (topRenderer.color != temas.gameObject.GetComponent<SpriteRenderer>().color)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D temast)
    {
        if (temast.gameObject.tag == "RenkDegistirici")
        {
            RenkDegistir();
        }
    }
    private void RenkDegistir()
    {
        int rastgeleSayi = Random.Range(1, 7);
        switch (rastgeleSayi)
        {
            case 1:
                topRenderer.color = color1;
                break;
            case 2:
                topRenderer.color = color2;
                break;
            case 3:
                topRenderer.color = color3;
                break;
            case 4:
                topRenderer.color = color4;
                break;
            case 5:
                topRenderer.color = color5;
                break;
            case 6:
                topRenderer.color = color6;
                break;
        }

    }
   private void IncreaseGravity()
    {
        
        topRb.gravityScale *= 1.05f;
    
    }

}