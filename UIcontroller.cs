using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour {
    public static UIcontroller instance;
    public Image Heart1, Heart2, Heart3, Heart4, Heart5;
    public Sprite heartFull, heartEmpty;

    private void Awake() {
        instance = this;
    }

    public void UpdateHealthDisplay(){
        switch(PlayerHealthController.instance.currentHealth){
            case 4:
                Heart1.sprite = heartFull;
                Heart2.sprite = heartFull;
                Heart3.sprite = heartFull;
                Heart4.sprite = heartFull;
                Heart5.sprite = heartEmpty;
                break;
            case 3:
                Heart1.sprite = heartFull;
                Heart2.sprite = heartFull;
                Heart3.sprite = heartFull;
                Heart4.sprite = heartEmpty;
                Heart5.sprite = heartEmpty;
                break;
            case 2:
                Heart1.sprite = heartFull;
                Heart2.sprite = heartFull;
                Heart3.sprite = heartEmpty;
                Heart4.sprite = heartEmpty;
                Heart5.sprite = heartEmpty;
                break;
            case 1:
                Heart1.sprite = heartFull;
                Heart2.sprite = heartEmpty;
                Heart3.sprite = heartEmpty;
                Heart4.sprite = heartEmpty;
                Heart5.sprite = heartEmpty;
                break;
            case 0:
                Heart1.sprite = heartEmpty;
                Heart2.sprite = heartEmpty;
                Heart3.sprite = heartEmpty;
                Heart4.sprite = heartEmpty;
                Heart5.sprite = heartEmpty;
                break;
            default:
                Heart1.sprite = heartFull;
                Heart2.sprite = heartFull;
                Heart3.sprite = heartFull;
                Heart4.sprite = heartFull;
                Heart5.sprite = heartFull;
                break;
        }
    }

}
