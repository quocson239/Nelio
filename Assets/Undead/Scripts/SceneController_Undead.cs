using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class SceneController_Undead : MonoBehaviour
{
    public GameObject Nelio;
    public GameObject Undead;

    public GameObject closeGate;
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;

    public GameObject gateEffect;
    public GameObject Gate;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(A1());
        Undead.SetActive(false);
        gateEffect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator A1()
    {
        yield return new WaitUntil(() => Nelio.transform.position.x > 27.5f);
        cam2.SetActive(true);
        cam1.SetActive(false);
        StartCoroutine(Slow());
        Nelio.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        Nelio.GetComponent<Animator>().SetBool("isRun", false);
        Nelio.GetComponent<P_Block>().isBlock = true;
        yield return new WaitUntil(() => closeGate.transform.position.y <= 0);
        cam3.SetActive(true);
        cam2.SetActive(false);
        gateEffect.SetActive(true);
        yield return new WaitForSeconds(2f);
        Undead.SetActive(true);
        Undead.transform.localScale = new Vector3(-1, 1, 1);
        Undead.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(Vector2.left.x - 1f, Undead.GetComponent<Rigidbody2D>().linearVelocity.y);
        yield return new WaitUntil(() => Undead.transform.position.x < 36.57f);
        Gate.SetActive(false);
        gateEffect.SetActive(false);
        Nelio.GetComponent<P_Block>().isBlock = false;
    }
    IEnumerator Slow()
    {
        InvokeRepeating("GoDown", 0, 0.1f);
        yield return new WaitUntil(() => closeGate.transform.position.y < 0f);
        CancelInvoke();
    }
    void GoDown()
    {
        closeGate.transform.position += new Vector3(0, -0.1f, 0);
    }
}
