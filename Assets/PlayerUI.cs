using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerUI : MonoBehaviour
{
    public Slider HpSlider, ShieldSlider,DashSlider;
    PlayerMovement PlayerValues;

    public GameObject AxeImage, BowImage;

    public TextMeshProUGUI AmmoText;

    public GameObject AxeCharImage, BowCharImage;
    public GameObject ESCmenu;
    
    void Start()
    {
        PlayerValues = GameObject.FindObjectOfType<PlayerMovement>();
    }

    
    void Update()
    {

       
        HpSlider.value = PlayerValues.hp;
        ShieldSlider.value = PlayerValues.shield;
        if(PlayerValues.nextDash > Time.time)
        {
            DashSlider.maxValue = PlayerValues.nextDash;
            
        DashSlider.value = Time.time;
        }
        else
        { if(DashSlider.minValue < DashSlider.maxValue)
            {

            DashSlider.minValue = Time.time;
              
            }
        }
        if(PlayerValues.AxeChar)
        {
            AxeImage.SetActive(true);
            BowImage.SetActive(false);
            AxeCharImage.SetActive(true);
            BowCharImage.SetActive(false);

        }
        else
        {
            BowCharImage.SetActive(true);
            AxeCharImage.SetActive(false);
            AxeImage.SetActive(false);
            BowImage.SetActive(true);
        }


        AmmoText.text = PlayerValues.bulletCount + "/" + PlayerValues.maxBulletCount;

    }
}
