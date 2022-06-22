using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue string", menuName = "Data/Dialogue String", order = 1)]
public class DialogString : ScriptableObject
{
	public int id = 0;
	public int nextId = -1;
	[TextArea(25, 25)]
	public string data = "";
}
