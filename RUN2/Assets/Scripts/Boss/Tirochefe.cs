using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tirochefe : MonoBehaviour
{
    public GameObject[] vida;
    public int vidaAtual = 3;
    public Combate_Boss_1 player;
    private Animator BossAnim;
    

    // Start is called before the first frame update
    void Start()
    {
        BossAnim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Damage()
    {
        vidaAtual -= 1;
        vida[vidaAtual].SetActive(false);

        if(vidaAtual == 0)
        {
            BossAnim.SetTrigger("Morte");
            Invoke("NextLevel",6.0f);
        }
    }

    void NextLevel()
    {
        SceneManager.LoadScene(4);
    }
}
