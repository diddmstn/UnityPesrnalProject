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
        list.Add("TIL ���̳���?,�� ���ž��մϴ�. TIL�� �󸶳� �߿��ϳĸ�, ~1�ð� ���� �̾��� TIL �̾߱�~, �ƹ�ư ������");
        list.Add("������ �� �Խ�üũ ���ּž��մϴ�,�� �Խǹ�ư �������մϴ�. �󸶳� �߿��ϳĸ�, ~1�ð� ���� �̾��� �Խ�üũ �̾߱�~, �ƹ�ư ��������");
        list.Add("������ �𸣴� ������ ������ Ʃ�ʹԵ� ã�ƿ��ž��մϴ�.,Ʃ�ʹԵ��� ã�ư��°� �󸶳� �߿��ϳĸ�, ~1�ð� ���� �̾��� Ʃ�ʹԵ� �̾߱�~, �ƹ�ư ã�ư�����");

    }

    public IEnumerator StartDialogue()
    {
        int a = Random.Range(0, list.Count); //�������� ��� ���
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
