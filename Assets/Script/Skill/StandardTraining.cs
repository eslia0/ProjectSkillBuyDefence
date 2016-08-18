﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class StandardTraining : Skill
{
	[SerializeField] int damage;
	[SerializeField] float attackSpeed;
	[SerializeField] float moveSpeed;
	[SerializeField] int healthPoint;
	[SerializeField] int manaPoint;

	//constructor - default
	public StandardTraining ()
	{
		id = 0001;
		name = "StandardTraining";
		level = 1;
		skillRange = 0f;
		coolTime = 0f;
		onTarget = false;
		skillType = Type.Passive;
		damage = 100;
		attackSpeed = 0.05f;
		moveSpeed = 0.05f;
		healthPoint = 200;
		manaPoint = 100;			
	}

}

