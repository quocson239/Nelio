using System.Collections;
using UnityEngine;

public class Player_Trap_Effect : MonoBehaviour
{
    public bool isStunned = false;
    public static Player_Trap_Effect instance;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    public void Stun(float duration)
    {
        if (!isStunned)
        {
            StartCoroutine(StunCoroutine(duration));
        }
    }


    private IEnumerator StunCoroutine(float duration)
    {
        isStunned = true;
        Debug.Log("Player stunned!");
        yield return new WaitForSeconds(duration);
        isStunned = false;
        Debug.Log("Player recovered from stun.");
    }
}
