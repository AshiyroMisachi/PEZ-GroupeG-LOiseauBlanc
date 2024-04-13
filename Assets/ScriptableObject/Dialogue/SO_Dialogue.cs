using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New_Dialogue", menuName = "Dialogue", order = 0)]
public class SO_Dialogue : ScriptableObject
{
    [TextArea]
    public string[] dialogue;
}
