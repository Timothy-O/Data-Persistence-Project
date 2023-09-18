using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIHandler : MonoBehaviour
{
    [SerializeField]private TMP_InputField nameInput;
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        DataManager.Instance.Name = nameInput.text;
    }
    public void LoadMain()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadStart()
    {
        SceneManager.LoadScene(0);
    }
}
