using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerUI : MonoBehaviour
{
    public Slider HpSlider, ShieldSlider;
    PlayerMovement PlayerValues;

    public GameObject AxeImage, BowImage;

    public TextMeshProUGUI AmmoText;
    
    void Start()
    {
        PlayerValues = GameObject.FindObjectOfType<PlayerMovement>();
    }

    
    void Update()
    {
        HpSlider.value = PlayerValues.hp;
        ShieldSlider.value = PlayerValues.shield;

        if(PlayerValues.AxeChar)
        {
            AxeImage.SetActive(true);
            BowImage.SetActive(false);
        }
        else
        {
            AxeImage.SetActive(false);
            BowImage.SetActive(true);
        }

        AmmoText.text = PlayerValues.bulletCount + "/" + PlayerValues.maxBulletCount;

    }
}
