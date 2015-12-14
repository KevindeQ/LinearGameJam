using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TooltipManager : MonoBehaviour {
    public Text textBox;
    public Transform left;
    public Transform right;
    public string[] tooltips;
    int index = 0;
    string tooltip;

    void Start ()
    {
        if (tooltips.Length == 0)
            gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (index == 0)
        {
            left.gameObject.SetActive(false);
        } else
        {
            left.gameObject.SetActive(true);
        }

        if (index == tooltips.Length - 1)
        {
            right.gameObject.SetActive(false);
        } else
        {
            right.gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            index -= 1;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            index += 1;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            index = (index + 1)%tooltips.Length;
        }

        index = Mathf.Clamp(index, 0, tooltips.Length - 1);
        tooltip = tooltips[index];
        textBox.text = tooltip;
    }
}
