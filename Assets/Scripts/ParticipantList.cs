using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ParticipantList : MonoBehaviour
{
    Dictionary<int,string> participants = new Dictionary<int,string>();
    public TMP_Text participantsList;

    public void SetList()
    {
        int count = transform.childCount;
        for (int i = 0; i < count; i++)
        {
            CharacterStatHandler obj = transform.GetChild(i).gameObject.GetComponent<CharacterStatHandler>();
            participants.Add(obj.characterInfo.id, obj.characterInfo.name);
            string name = participants[i];
            participantsList.text = name;
           
        }
    }

   
}
