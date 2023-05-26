using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Keys : MonoBehaviour {

    [Header(" Elements ")]
    [SerializeField] private TextMeshProUGUI keyText;
    private char key;
    private Sprite image;
    public void SetKey(char key, Sprite img) {
        Image image = GetComponent<Image>();
        image.sprite = img;
        this.key = key;
        keyText.text = key.ToString();
    }
    public Button GetButton() {

        return GetComponent<Button>();
    }
    public Image GetImage() {
        Image image = GetComponent<Image>();
        image.sprite = this.image;
        return image;
    }
}
