using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finishline : MonoBehaviour
{
    public string NomDeScene;


    public void AllerAuSuivant()
    {
        SceneManager.LoadScene(NomDeScene);
    }

    private void OnTriggerEnter(Collider other)
    {
        AllerAuSuivant();
    }


}
