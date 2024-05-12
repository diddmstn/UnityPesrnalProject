using UnityEngine;
using TMPro;
public class CharacterStatHandler : MonoBehaviour
{
    public CharacterInfo characterInfo;//SriptableObject만 받고있다. 왜냐하면 스탯이 업데이트 될 필요가 업기 때문이다.
    public TMP_Text nameText;

    public void Awake()
    {
        //시작할때 이름 초기화
        characterInfo.name = "";
    }
    public void UpdateStatus()
    {
        nameText.text = characterInfo.name;
    }
}



