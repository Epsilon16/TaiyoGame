using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeBlanc : MonoBehaviour
{
    [SerializeField] private GameObject Panel;
    public Animator anim;
    public AudioClip son;

    private Animation animdestroy;
    // Start is called before the first frame update
    void Start()
    {
        animdestroy = GameObject.Find("Canvas").GetComponent<Animation>();
        Panel = GameObject.Find("PanelBlanc");
        anim = Panel.GetComponent<Animator>();
        animdestroy.Play("Canvas_Explosion");
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
