using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DialogStringDatabase : MonoBehaviour
{
    [SerializeField]
    private List<DialogString> strings;

    // Start is called before the first frame update
    void Start()
    {

        var loaded = Resources.LoadAll("Dialog", typeof(DialogString));
        strings = new List<DialogString>();
        foreach (var e in loaded)
        {
            strings.Add((DialogString)e);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public DialogString GetStringData(int id)
    {
        return strings.FirstOrDefault<DialogString>(s => s.id == id);
    }
}
