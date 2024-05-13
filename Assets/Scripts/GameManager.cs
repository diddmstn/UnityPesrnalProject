using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System;


public class GameManager : MonoBehaviour
{
    //public ParticipantList participantList;
    Coroutine runningCorutine;
    [Header("CharacterSelect")]
    public CharactorAnimationController charactorAnimation;
    public GameObject nameInputPanel;
    public GameObject characterSelect;
    public Image characterImage;
    [Header("NameChange")]
    public CharacterStatHandler characterStatHandler;
    public TMP_Text nameText;
    public TMP_Text warningText;
    [Header("Time")]
    public TMP_Text timeText;
    [Header("MiniUI")]
    public GameObject miniCharacterSelect;
    public TMP_Text miniNameText;
    GameObject lastActiveObj; //â�� ������ �����°� �����ϱ� ���� 

    //public SpriteRenderer playerSprite;

    private void Start()
    {
        Time.timeScale = 0;
    }
    private void Update()
    {
        timeText.text = DateTime.Now.ToString("HH:mm");
    }
    void CheckNameCorrect(TMP_Text inputText,GameObject obj)
    {
        if (inputText.text.Length <= 2)
        {
            if (runningCorutine != null) //�������� �Էµ� �������� 1�ʸ� �������� ������ �۵��ϴ� �ڷ�ƾ ����
                StopCoroutine(runningCorutine);

            warningText.enabled = true;
            warningText.text = "�̸��� �ʹ� ª���ϴ�.";
            runningCorutine = StartCoroutine(TextClose(warningText)); //1�� �ڿ� ����
        }
        else
        {
            characterStatHandler.characterInfo.name = inputText.text;
            obj.SetActive(false);
            characterStatHandler.UpdateStatus();
            Time.timeScale = 1;
        }
    }    
    public void ChangeName()
    {
        GameObject obj = EventSystem.current.currentSelectedGameObject.transform.parent.gameObject;
        CheckNameCorrect(nameInputPanel.activeSelf? nameText: miniNameText, obj);
    }
    IEnumerator TextClose(TMP_Text text)
    {
        yield return new WaitForSecondsRealtime(1.0f);
        warningText.enabled = false;
    }
   public void ButtonActive() 
    {
        Time.timeScale = 0; //��ư Ȱ��ȭ �߿��� ĳ���Ͱ� �������
                            //Ŭ���� ��ư�� ������Ʈ ������ �޾ƿ´�.
        GameObject obj = EventSystem.current.currentSelectedGameObject.transform.GetChild(0).gameObject;
        bool active = obj.activeSelf;
        if (lastActiveObj != null)//��ư�� �����ִ� ���� �ٸ� ��ư�� ���� ��ġ�� ���� ����
        {
            lastActiveObj.SetActive(false);
        }
        obj.SetActive(!active);//���� ���¿� �ݴ�� ���� Ű��
        Time.timeScale = nameInputPanel.activeSelf ? 1 : 0;
        if (!active == false) Time.timeScale = 1;
        lastActiveObj = obj;
       

    }

    public void SelectCharacter()
    {
        GameObject obj = EventSystem.current.currentSelectedGameObject;
        Image image = obj.transform.GetChild(0).GetComponent<Image>();//���� ��ư�� ���� ����
        int num = obj.GetComponent<CharacterNum>().characterId;//���� ��ư�� ���� ����
        ChangeCharacter(image, num);
        obj.transform.parent.gameObject.SetActive(false);

        Time.timeScale  = nameInputPanel.activeSelf ?  0: 1;
        
    }
   
    void ChangeCharacter(Image image, int num)
    {
        characterImage.sprite = image.sprite; //������ �̹��� ����
        charactorAnimation.ChangeAnimator(num); //�ִϸ����� ����

    }
}
