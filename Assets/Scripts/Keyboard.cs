using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Keyboard : MonoBehaviour {


    [Header(" Elements ")]
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private Keys keyPrefab;


    [Header(" Settings ")]
    [Range(0f, 1f)]
    [SerializeField] private float widthPercent;
    [Range(0f, 1f)]
    [SerializeField] private float heightPercent;
    [Range(0f, .5f)]
    [SerializeField] private float bottomOffset;

    [Header(" Keyboard Lines ")]
    [SerializeField] private KeyboardLine[] lines;
  

    [Header(" Key Settings ")]
    [Range(0f, 1f)]
    [SerializeField] private float keyToLineRatio;
    [Range(0f, 1f)]
    [SerializeField] private float keyXSpacing;
    IEnumerator Start() {
        CreateKeys();
        yield return null;
        UpdateRectTransform();

        //rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height / 2);
    }

    private void Update() {
        UpdateRectTransform();
        PlaceKeys();
    }
    private void UpdateRectTransform() {
        float width = widthPercent * Screen.width;
        float height = heightPercent * Screen.height;
        // Configuring the size of the keyboard container
        rectTransform.sizeDelta = new Vector2(width, height);
        // Configure the bottom offset
        Vector2 position;
        position.x = Screen.width / 2;
        position.y = bottomOffset * Screen.height + height / 2;
        rectTransform.position = position;
    }

    private void CreateKeys() {
        for (int i = 0; i < lines.Length; i++) {
            for (int j = 0; j < lines[i].keys.Length; j++) {
               // char key = lines[i].keys[j];
                char key = ' ';
                Sprite img = lines[i].images[j];
                Keys keyInstance = Instantiate(keyPrefab, rectTransform);
                keyInstance.SetKey(key,img);
            }
        }
    }

    private void PlaceKeys() {
        int lineCount = lines.Length;
        float lineHeight = rectTransform.rect.height / lineCount;
        float keyWidth = lineHeight * keyToLineRatio;
        float xSpacing = keyXSpacing * lineHeight;
        int currentKeyIndex = 0;

        for (int i = 0; i < lineCount; i++) {
            float halfKeyCount = (float)lines[i].keys.Length / 2;
            float startX = rectTransform.position.x - (keyWidth+ xSpacing) * halfKeyCount + (keyWidth+ xSpacing) / 2;
            float lineY = rectTransform.position.y + rectTransform.rect.height / 2 - lineHeight / 2 - i * lineHeight;

            for (int j = 0; j < lines[i].keys.Length; j++) {
                float keyX = startX + j * (keyWidth+ xSpacing);
                Vector2 keyPosition = new Vector2(keyX, lineY);
                RectTransform keyRectTransform = rectTransform.GetChild(currentKeyIndex).GetComponent<RectTransform>();
                keyRectTransform.position = keyPosition;
                keyRectTransform.sizeDelta = new Vector2(keyWidth, keyWidth);
                currentKeyIndex++;
            }
        }
    }
    public void changeTheme() {

    }
}
[System.Serializable]
public struct KeyboardLine {
    public string keys;
    public Sprite[] images;
}