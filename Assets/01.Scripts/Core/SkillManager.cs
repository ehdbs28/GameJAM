using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    [SerializeField] List<GameObject> skill = new List<GameObject>();

    [SerializeField]
    Transform Trm;

    [SerializeField]
    Transform Trm_1;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            Image skillImage = Instantiate(skill[Random.Range(0, 6)].GetComponent<Image>());
            skillImage.transform.SetParent(Trm);
            skillImage.transform.localScale = new Vector3(1, 1, 1);
            skillImage.transform.localPosition = new Vector3(-300, 0, 0);
            Image skillImage_1 = Instantiate(skill[Random.Range(0, 6)].GetComponent<Image>());
            skillImage_1.transform.SetParent(Trm_1);
            skillImage_1.transform.localScale = new Vector3(1, 1, 1);
            skillImage_1.transform.localPosition = new Vector3(300, 0, 0);
        }
    }
}
