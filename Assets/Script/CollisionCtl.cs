using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionCtl : MonoBehaviour
{
    [SerializeField] private AudioClip finishAudio;
    [SerializeField] private AudioClip deathAudio;
    [SerializeField] private ParticleSystem finishParticle;
    [SerializeField] private ParticleSystem deathParticle;
    

    private AudioSource audioSource;
    private bool isCollision = false;
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    //private void Update()
    //{
    //    ReponNextLevel();
    //    ReponNoCollision();
        
    //}

    private void ReponNextLevel()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            nextScene();
        }
    }

    private void ReponNoCollision()
    {
            isCollision = !isCollision;
    }

    private void NoReponNoCollision()
    {
        isCollision = false; 
    }
    private void ReturnScale()
    {
        gameObject.transform.localScale /= 1.5f;

    }

    //chuyen scene khong dung so
    void nextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;
        if (nextScene == SceneManager.sceneCountInBuildSettings)
        {
            nextScene = 0;
        }
        SceneManager.LoadScene(nextScene);
    }

    void resetScene()
    {
        SceneManager.LoadScene(1);
    }

   
    private void OnCollisionEnter(Collision collision)
    {
        if(isCollision)
        {
            return;
        }
        switch (collision.gameObject.tag)
        {
            case "Finish":                  
                audioSource.Stop();
                audioSource.PlayOneShot(finishAudio);
                finishParticle.Play();
                GetComponent<MoveCtl>().enabled = false;
                Invoke("nextScene", 1f);                
                break;          
            case "Start":                
                break;
            case "Chuongngai":                
                audioSource.Stop();
                audioSource.PlayOneShot(deathAudio);
                deathParticle.Play();
                GetComponent<MoveCtl>().enabled = false;
                Invoke("resetScene", 1f);               
                break;
            default:               
                audioSource.Stop();
                audioSource.PlayOneShot(deathAudio);
                deathParticle.Play();
                GetComponent<MoveCtl>().enabled = false;
                Invoke("resetScene", 1f);              
                break;
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ScaleUp")
        {
            gameObject.transform.localScale *= 1.5f;
            //sau 5s thi se tro ve trang thai ban dau
            Invoke(nameof(ReturnScale), 5f);
        }
        if (other.gameObject.tag == "Khien")
        {
            ReponNoCollision();
            //sau 5s ket thuc trang thai khien
            
            Invoke(nameof(NoReponNoCollision), 3f);
        }
    }
}
