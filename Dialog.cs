using System.Collections;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour {
    [SerializeField] private GameObject dialogMark;
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private TMP_Text dialogText;
    [SerializeField, TextArea(4,6)] private string[] dialogueLines;
    private bool isClose;
    private bool didDialogStart;
    private int lineIndex;
    void Update() {
        if(isClose && Input.GetKeyDown(KeyCode.E)){
            if(!didDialogStart){
                StartDialog();
            }else if(dialogText.text == dialogueLines[lineIndex]){
                NextLine();
            }else{
                StopAllCoroutines();
                dialogText.text = dialogueLines[lineIndex];
            }
        }
    }

    private void NextLine(){
        lineIndex++;
        if(lineIndex < dialogueLines.Length){
            StartCoroutine(ShowLine());
        }else{
            didDialogStart = false;
            dialogPanel.SetActive(false);
            dialogMark.SetActive(true);
            Time.timeScale = 1f;
        }
    }
    private IEnumerator ShowLine(){
        dialogText.text = string.Empty;
        foreach(char c in dialogueLines[lineIndex]){
            dialogText.text += c;
            yield return new WaitForSecondsRealtime(0.05f);
        }
    }
    public void StartDialog(){
        didDialogStart = true;
        dialogPanel.SetActive(true);
        dialogMark.SetActive(false);
        lineIndex = 0;
        Time.timeScale = 0f;
        StartCoroutine(ShowLine());
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            isClose = true;
            dialogMark.SetActive(true);
        }
        
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")){
            isClose = false;
            dialogMark.SetActive(false);
        }
    }
}
