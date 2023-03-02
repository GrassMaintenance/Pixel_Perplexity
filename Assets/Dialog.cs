using System.Collections;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour {
    public TextMeshProUGUI textComponent;
    public string[] lines;
    private int index;
    public float textSpeed;

    void Start() {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            if (textComponent.text == lines[index]) {
                NextLine();
            } else {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }
    
    void StartDialogue() {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine() {
        foreach (char character in lines[index].ToCharArray()) {
            textComponent.text += character;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine() {
        if (index < lines.Length - 1) {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
    }
}
