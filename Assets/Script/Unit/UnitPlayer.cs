﻿using UnityEngine;
using System.Collections;

//enemy & ally unit process -> movable unit
public class UnitPlayer : UnitProcess
{
	//simple field
	[SerializeField] bool isMove;
	[SerializeField] AnimatorState presentAnimatorState;

	// initialize this script
	void Start()
	{
		animator = GetComponent<Animator>();
		moveAgent = GetComponent<NavMeshAgent>();
		manager = GameObject.FindWithTag( "GameManager" ).GetComponent<GameManager>();
		DataInitialize();
	}
	
	// Update is called once per frame
	void Update()
	{
		if (isMove && ( Vector3.Distance( transform.position, destination ) >= 0.1f ))
		{
			transform.LookAt( destination );		
		}
		else
		{
			destination = transform.position;
			moveAgent.ResetPath();
			isMove = false;
		}

		ActiveAnimator( presentAnimatorState );
	}

	//set player animation - use present state
	protected override void ActiveAnimator( AnimatorState present )
	{
		switch (present)
		{
			case AnimatorState.Idle:
				animator.SetInteger( "State", (int) AnimatorState.Idle );
				animator.Play( "Idle" );
				break;
			case AnimatorState.Run:
				animator.SetInteger( "State", (int) AnimatorState.Run );
				animator.Play( "Run" );
				break;
			case AnimatorState.Attack:
				animator.SetInteger( "State", (int) AnimatorState.Attack );
				animator.Play( "Attack" );
				break;
			case AnimatorState.ThrowAttack:
				animator.SetInteger( "State", (int) AnimatorState.ThrowAttack );
				animator.Play( "ThrowAttack" );
				break;
			case AnimatorState.Casting:
				animator.SetInteger( "State", (int) AnimatorState.Casting );
				animator.Play( "Casting" );
				break;
			case AnimatorState.CastingUltimate:
				animator.SetInteger( "State", (int) AnimatorState.CastingUltimate );
				animator.Play( "CastingUltimate" );
				break;
			case AnimatorState.Die:
				if (!animatorInfo.IsName( "Die" ))
					animator.Play( "Die" );
				break;
		}
	}

	//public method

	//unit position & animation state data receive
	public void ReceiveData( Vector3 positionData, AnimatorState stateData )
	{
		destination = positionData;
		presentAnimatorState = stateData;
		moveAgent.SetDestination( destination );
		isMove = true;
	}

	//receive data -> interpolate position
	public void ReceiveData( Vector3 interpolatePoint )
	{
		if (Vector3.Distance( transform.position, interpolatePoint ) >= 1f)
			transform.position = interpolatePoint;
	}

	//unit damage calculate
	//send unit information to another client
	public override void Damaged( float damage )
	{
		info.PresentHealthPoint -= damage;
		//send unit data
	}
}
