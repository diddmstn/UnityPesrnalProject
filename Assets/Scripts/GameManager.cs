using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    [Header("Script")]
    public CharacterStatHandler characterStatHandler;
    public CharactorAnimationController charactorAnimation;
    [Header("obj")]
    public TMP_Text text;
    public GameObject nameInputPanel;
    public Image characterImage;
    //public SpriteRenderer playerSprite;

    private void Start()
    {
        Time.timeScale = 0;
    }
    public void ChangeName()
    {
        characterStatHandler.characterInfo.name = text.text;
        characterStatHandler.UpdateStatus();
        nameInputPanel.SetActive(false);
        Time.timeScale = 1;

    }
    public void SelectCharacter()
    {
        GameObject obj = EventSystem.current.currentSelectedGameObject;
        Image image = obj.transform.GetChild(0).GetComponent<Image>();//���� ��ư�� ���� ����
        int num = obj.GetComponent<CharacterNum>().characterId;//���� ��ư�� ���� ����
        ChangeCharacter(image, num);
    }
    void ChangeCharacter(Image image, int num)
    {
        characterImage.sprite = image.sprite; //������ �̹��� ����
        //playerSprite.sprite = characterImage.sprite;
        charactorAnimation.ChangeAnimator(num); //�ִϸ����� ����

    }
}
