using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class NpcDialogue : MonoBehaviour
{
    List<string> list = new List<string>();
    public GameObject dialoguePanel;
    public GameObject TalkButton;
    public TMP_Text dialogue;
    public GameObject BottomUI;

    private void Start()
    {
        list.Add("TIL 쓰셨나요?,꼭 쓰셔야합니다. TIL이 얼마나 중요하냐면, ~1시간 동안 이어진 TIL 이야기~, 아무튼 쓰세요");
        list.Add("여러분 꼭 입실체크 해주셔야합니다,꼭 입실버튼 눌러야합니다. 얼마나 중요하냐면, ~1시간 동안 이어진 입실체크 이야기~, 아무튼 누르세요");
        list.Add("여러분 모르는 문제가 있으면 튜터님들 찾아오셔야합니다.,튜터님들을 찾아가는게 얼마나 중요하냐면, ~1시간 동안 이어진 튜터님들 이야기~, 아무튼 찾아가세요");

    }

    public IEnumerator StartDialogue()
    {
        int a = Random.Range(0, list.Count); //랜덤으로 대사 출력
        string[] spliteText = list[a].Split(',');

        for(int i=0; i<spliteText.Length; i++)
        {
            dialogue.text= spliteText[i];
            yield return new WaitForSecondsRealtime(0.1f);
            while (Input.touchCount < 1 && !Input.GetMouseButtonUp(0)) yield return null;

        }
        dialoguePanel.SetActive(false);
        TalkButton.SetActive(true);
        BottomUI.SetActive(true);

        Time.timeScale = 1;
    }
    public void ActiveDialogueButton()
    {
        Time.timeScale = 0;
        dialoguePanel.SetActive(true);
        TalkButton.SetActive(false);
        BottomUI.SetActive( false);
        StartCoroutine(StartDialogue());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TalkButton.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(TalkButton!=null)
        TalkButton.SetActive(false);
    }
}
