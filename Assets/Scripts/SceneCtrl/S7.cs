using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class S7 : MonoBehaviour
{
    [SerializeField] GameObject nelio;
    [SerializeField] GameObject hpSystem;
    [SerializeField] GameObject scarlet;
    [SerializeField] Image blackBg;
    [SerializeField] GameObject portal;


    [Header("Audio")]
    [SerializeField] AudioSource bgMusic;
    [SerializeField] AudioSource bgMusic2;
    [SerializeField] AudioSource portalSound;
    void Start()
    {
        StartCoroutine(PlayScene7());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator PlayScene7()
    {
        nelio.transform.position = new Vector3(-6, -0.3f, 0);
        blackBg.gameObject.SetActive(true);
        hpSystem.SetActive(false);
        portal.SetActive(false);
        nelio.SetActive(false);
        nelio.GetComponent<P_Block>().isBlock = true;
        scarlet.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        blackBg.CrossFadeAlpha(0, 15f, false);
        yield return new WaitForSeconds(4f);
        blackBg.CrossFadeAlpha(0, 1f, false);
        yield return new WaitForSeconds(2f);
        portal.SetActive(true);
        nelio.SetActive(true);
        nelio.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(1.5f);
        nelio.GetComponent<Animator>().SetBool("isRun", true);
        nelio.GetComponent<SpriteRenderer>().enabled = true;
        //
        nelio.GetComponent<Rigidbody2D>().gravityScale = 0;
        nelio.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(2f, 0);
        yield return new WaitUntil(() => nelio.transform.position.x >= -3f);
        nelio.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        nelio.GetComponent<Rigidbody2D>().gravityScale = 1;
        nelio.GetComponent<Animator>().SetBool("isRun", false);
        yield return new WaitForSeconds(2f);
        portal.SetActive(false);
        yield return new WaitForSeconds(1f);
    }
}
