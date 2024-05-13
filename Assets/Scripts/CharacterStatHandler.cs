using UnityEngine;
using TMPro;
public class CharacterStatHandler : MonoBehaviour
{
    public CharacterInfo characterInfo;
    public TMP_Text nameText;

    public void Awake()
    {
        if (characterInfo.name != null)
        {
            nameText.text = characterInfo.name;
        }
        else
        {
            //시작할때 이름 초기화
            characterInfo.name = "";
        }

    }
    public void UpdateStatus()
    {
        nameText.text = characterInfo.name;
    }
}



