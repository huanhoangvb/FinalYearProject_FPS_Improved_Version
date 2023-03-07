using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI text;
    public string[] lines;
    public Transform companion;

    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        text.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = companion.position;
    }

    void StartDialogue() {
        NextLine();
    }

    void NextLine() {
        if (index < lines.Length - 1)
        {
            text.text = string.Empty;
            text.text = lines[index++].ToString();
        }
        StartCoroutine(stopDisplayDialogue());
    }

    IEnumerator stopDisplayDialogue() {
        yield return new WaitForSeconds(3);
        GetComponentInParent<Canvas>().gameObject.SetActive(false);
    }
}
