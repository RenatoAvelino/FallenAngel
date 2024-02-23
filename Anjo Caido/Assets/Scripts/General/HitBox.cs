using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    [SerializeField] private float TimeToVanish = 0.1f;
    [SerializeField] private int Damage = 1;

    private GameObject owner;

    public GameObject donoOw {
        set { owner = value; }
        get { return owner; }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject tmp = other.gameObject;

        if(owner.CompareTag("Player") && tmp.CompareTag("Enemy")) //Player Atacou o Inimigo
        {
            tmp.GetComponent<EnemyController>().DamageAmount(Damage);
        }
        //Debug.Log("Nome: " + tmp.name);
    }

    #region AttackEnd
    public void EndAttack()
    {
        StartCoroutine(VanishBox());
    }

    IEnumerator VanishBox()
    {
        //Debug.Log("Hora de Sumir");

        yield return new WaitForSeconds(TimeToVanish);

        //Debug.Log("Sumi");

        if (owner.CompareTag("Player"))
        {
            ControllerPlayer player = owner.GetComponent<ControllerPlayer>();
            player._canPunch = true;
        }
        
        this.gameObject.SetActive(false);
    }
    #endregion
}
