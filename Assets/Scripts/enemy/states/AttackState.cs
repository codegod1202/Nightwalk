using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    // Start is called before the first frame update
    private float moveTimer;
    private float losePlayerTimer;
    public override void Enter()
    {

    }
    public override void Perform()
    {
        if (enemy.CanSeePlayer())
        {
            losePlayerTimer = 0;
            moveTimer += Time.deltaTime;
            enemy.transform.LookAt(enemy.Player.transform);
            /*if (moveTimer > Random.Range(3, 7))
            {
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 5));
                moveTimer = 0;
            }*/
            enemy.LastKnowPos = enemy.Player.transform.position;
            //
            enemy.Agent.SetDestination(enemy.LastKnowPos);
        }
        else
        {
            losePlayerTimer += Time.deltaTime;
            if (losePlayerTimer > 8)
            {
                stateMachine.ChangeState(new SearchState());
            }
        }
    }
    public override void Exit()
    {

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
