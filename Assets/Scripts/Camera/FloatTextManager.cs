using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatTextManager : MonoBehaviour
{

    public static FloatTextManager instance;

    [SerializeField] GameObject FloatingText_pre;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void CreateFloatingText(Vector3 pos, string _text)
    {
        GameObject clone = Instantiate(FloatingText_pre, pos, FloatingText_pre.transform.rotation);
        clone.GetComponentInChildren<Text>().text = _text;
    }
}
