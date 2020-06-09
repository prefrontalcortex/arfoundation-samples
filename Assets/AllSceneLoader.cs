using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AllSceneLoader : MonoBehaviour
{
    public Button template;
    public Transform child;
    public Toggle menu;

    public string[] scenes;

    [ContextMenu("Generate")]
    void Generate() {
        int sceneCount = SceneManager.sceneCountInBuildSettings;
         
        scenes = new string[sceneCount];
        for( int i = 1; i < sceneCount; i++ )
        {
            scenes[i] = Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
        }
    }

    void OnEnable()
    {
        DontDestroyOnLoad(this.gameObject);

        for(int i = 1; i < scenes.Length; i++)
        {
            var b = Instantiate(template, child);
            b.gameObject.SetActive(true);
            b.GetComponentInChildren<Text>().text = scenes[i];
            var k = i;
            b.onClick.AddListener(() => {
                SceneManager.LoadScene(k, LoadSceneMode.Single);
                
                menu.isOn = false;
            });
        }
    }
}
