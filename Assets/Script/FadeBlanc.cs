using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeBlanc : MonoBehaviour
{
    [SerializeField] private GameObject Panel;
    public Animator anim;
    public AudioClip son;
    // Start is called before the first frame update
    void Start()
    {
        Panel = GameObject.Find("PanelBlanc");
        anim = Panel.GetComponent<Animator>();
        anim.Play("Fade_Blanc");
        StartCoroutine(passageSceneWin());
        GetComponent<AudioSource>().PlayOneShot(son);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator passageSceneWin()
    {
        yield return new WaitForSeconds(0.5f);
        GetComponent<AudioSource>().PlayOneShot(son);
        yield return new WaitForSeconds(0.5f);
        GetComponent<AudioSource>().PlayOneShot(son);
        yield return new WaitForSeconds(2f);
        Cursor.visible = true;
        SceneManager.LoadScene(2);
    }
}
