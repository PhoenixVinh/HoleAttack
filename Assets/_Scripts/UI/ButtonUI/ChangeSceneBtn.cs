using System;
using _Scripts.ManagerScene;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSceneBtn : MonoBehaviour
{
    public EnumScene namescene;
    
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ChangeScene);
    }

    public virtual void ChangeScene()
    {
        SceneManager.LoadScene(namescene.ToString());
    }
}