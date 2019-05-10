using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

    public void PlayOpenAnim()
    {
        StartCoroutine("StartOpeningCoroutine");
    }
    

    IEnumerator StartOpeningCoroutine()
    {
        GetComponent<Animator>().SetBool("IsOpen", true);
        yield return new WaitForSeconds(.4f);
        GetComponent<Animator>().SetBool("IsOpen", false);
        SceneManager.LoadScene(2);
    }
}
