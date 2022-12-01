using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource GAtk;
    public AudioSource VAtk;
    public AudioSource DAtk;
    public AudioSource eDAtk;
    public AudioSource eGAtk;
    public AudioSource eVAtk;
    public AudioSource CMdec;
    public AudioSource CMinc;
    public AudioSource lastTick;
    public AudioSource Bequip;
    public AudioSource Dequip;
    public AudioSource Vequip;
    public AudioSource Yequip;
    public AudioSource menuBack;
    public AudioSource menuNavi;

    private static bool sfxmanExists;

    public void playBequip()
    {
        Bequip.Play();
    }

    public void playDequip()
    {
        Dequip.Play();
    }

    public void playVequip()
    {
        Vequip.Play();
    }

    public void playMenNav()
    {
        menuNavi.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        if(!sfxmanExists)
        {
            sfxmanExists = true;
            DontDestroyOnLoad(transform.gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }
    
}
