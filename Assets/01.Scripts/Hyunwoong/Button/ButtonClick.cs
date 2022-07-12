using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    [SerializeField] private List<GameObject> buttons = new List<GameObject>();
    [SerializeField]
    Transform Trm;
    [SerializeField]
    Transform Trm_1;

    Button button;

    void Start()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(() =>
        {
            
        });
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            Image skillImage = Instantiate(buttons[Random.Range(0, 6)].GetComponent<Image>());
            skillImage.transform.localScale = new Vector3(1, 1, 1);
            skillImage.transform.SetParent(Trm);
            Image skillImage_1 = Instantiate(buttons[Random.Range(0, 6)].GetComponent<Image>());
            skillImage_1.transform.localScale = new Vector3(1, 1, 1);
            skillImage_1.transform.SetParent(Trm_1);
        }
    }
}
