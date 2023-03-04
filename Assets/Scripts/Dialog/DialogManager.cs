using System.Collections;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour {
    public TextMeshProUGUI textComponent;
    [TextArea(3,10)] public string[] lines;
    public float textSpeed;
    private int index;
    private delegate void DialogAudio();
    private DialogAudio playDialogAudio;

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

    void PlayPlayerDialog() {
        SoundManager.Instance.Play("VoiceDialog");
    }

    void PlayVoiceDialog() {
        SoundManager.Instance.Play("PlayerDialog");
    }

    IEnumerator TypeLine() {
        playDialogAudio = index % 2 == 0 ? PlayPlayerDialog : PlayVoiceDialog;
        
        foreach (char character in lines[index]) {
            textComponent.text += character;
            playDialogAudio();
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
