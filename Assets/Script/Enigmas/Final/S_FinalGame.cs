using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_FinalGame : MonoBehaviour
{



    public bool gameOn = false;
    private bool enemyPlayed = false, playerPlayed = false;
    private bool turn = true; //false -> IA, true -> player
    public List<GameObject> listStick = new List<GameObject>();
    public List<Vector3> listStickPosLocal = new List<Vector3>();
    private int batonnetsRestants;
    private int enleve;
    public S_CheckFinalGame checkFinal;
    private bool enigmaCompleted = false;
    public Animator animator;
    public GameObject finalDoor;
    //private bool state = false;

    // Start is called before the first frame update
    void Start()
    {
        batonnetsRestants = listStick.Count;

        for (int i = 0; i < batonnetsRestants; i++)
        {
            listStickPosLocal.Add(listStick[i].transform.position);

        }
    }

    // Update is called once per frame
    void Update()
    {



        if (gameOn)
        {

            if (!playerPlayed && turn)
            {
                Debug.Log("tour player");
                if (Input.GetKeyDown(KeyCode.Keypad1))
                {

                    StartCoroutine(deleteStickPlayer(batonnetsRestants - 1));
                    batonnetsRestants--;

                }
                else if (Input.GetKeyDown(KeyCode.Keypad2) && batonnetsRestants > 1)
                {
                    StartCoroutine(deleteStickPlayer(batonnetsRestants - 1));
                    StartCoroutine(deleteStickPlayer(batonnetsRestants - 2));

                    batonnetsRestants--;
                    batonnetsRestants--;


                }
                else if (Input.GetKeyDown(KeyCode.Keypad3) && batonnetsRestants > 2)
                {
                    StartCoroutine(deleteStickPlayer(batonnetsRestants - 1));
                    StartCoroutine(deleteStickPlayer(batonnetsRestants - 2));
                    StartCoroutine(deleteStickPlayer(batonnetsRestants - 3));


                    batonnetsRestants--;
                    batonnetsRestants--;
                    batonnetsRestants--;


                }
            }

            //tour joueur


            //tour IA
            if (!enemyPlayed && !turn)
            {

               // Debug.Log("reste " + batonnetsRestants);

                if (batonnetsRestants > 8)
                {
                    enleve = Random.Range(1, 4);

                }
                else if (batonnetsRestants > 4)
                {
                    enleve = Random.Range(3, 4);
                }
                else if (batonnetsRestants > 2)
                {
                    enleve = 2;
                }
                else { enleve = 1; }

                for (int i = 0; i <= enleve; i++)
                {
                    StartCoroutine(deleteStickIA(batonnetsRestants - i));


                }
                batonnetsRestants = batonnetsRestants - enleve;
                //Debug.Log("IA enleve " + enleve);
            }




            //fin du jeu
            if (batonnetsRestants <= 0)
            {
                playerPlayed = false;
                enemyPlayed = true;
                if (turn)
                {
                    //Debug.Log("IA a gagné");

                    StartCoroutine(ResetGame());
                    checkFinal.SetupPuzzle();


                }
                else
                {
                    //Debug.Log("Player a gagné");
                    enigmaCompleted = true;
                    animator.SetTrigger("Open");


                }
                gameOn = false;

            }
        }
    }


    public IEnumerator ResetGame()
    {
        yield return new WaitForSeconds(3);


        batonnetsRestants = listStickPosLocal.Count;

        for (int i = 0; i < batonnetsRestants; i++)
        {
            listStick[i].gameObject.SetActive(true);

            listStick[i].GetComponent<Rigidbody>().velocity = Vector3.zero;

            listStick[i].transform.position = listStickPosLocal[i];
        }

        playerPlayed = false;
        turn = true;



    }



    public IEnumerator deleteStickPlayer(int id)
    {
        playerPlayed = true;
        var currentRb = listStick[id].GetComponent<Rigidbody>();
        currentRb.AddForce(Vector3.back * 6f);
        yield return new WaitForSeconds(1);
        listStick[id].gameObject.SetActive(false);
        turn = false;
        enemyPlayed = false;

    }

    public IEnumerator deleteStickIA(int id)
    {
        enemyPlayed = true;
        var currentRb = listStick[id].GetComponent<Rigidbody>();
        currentRb.AddForce(Vector3.forward * 6f);
        yield return new WaitForSeconds(1);
        listStick[id].gameObject.SetActive(false);
        turn = true;
        playerPlayed = false;

    }

    public bool getEnigmaCompleted() { return enigmaCompleted; }


}


