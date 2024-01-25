using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeBlanc : MonoBehaviour
{
    [SerializeField] private GameObject Panel;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        Panel = GameObject.Find("PanelBlanc");
        anim = Panel.GetComponent<Animator>();
        anim.Play("Fade_Blanc");
        StartCoroutine(passageSceneWin());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator passageSceneWin()
    {
        yield return new WaitForSeconds(3f);
        Cursor.visible = true;
        SceneManager.LoadScene(2);
    }
}
