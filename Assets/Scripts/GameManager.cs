using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public CharacterStatHandler characterStatHandler;
    public TMP_Text text;

    public void ChangeName()
    {
        characterStatHandler.characterInfo.name = text.text;
        characterStatHandler.UpdateStatus();
    }
}
