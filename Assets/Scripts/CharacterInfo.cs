using UnityEngine;

[CreateAssetMenu(fileName ="DefaultCharacterInfo", menuName = "TopDownController/Character/Default", order = 0)]
public class CharacterInfo : ScriptableObject
{
    [Header("Character Info")]
    public string name;
    public int id;
    public float moveSpeed;
    public float runSpeed;

}


