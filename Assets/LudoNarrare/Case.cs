﻿using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Case
{
	/* Variables */
	public string name;
	public List<Condition> conditions;
	public List<Operator> operators;
	public List<Page> pages;

	/* Functions */
	public Case(string _name)
	{
		name = _name;
		conditions = new List<Condition>();
		operators = new List<Operator>();
		pages = new List<Page>();
	}

	public void replaceWith(string replace, string with)
	{
		for (int i = 0; i < conditions.Count; i++ )
			conditions[i].replaceWith(replace, with);
		
		for (int i = 0; i < operators.Count; i++)
			operators[i].replaceWith(replace, with);

		for (int i = 0; i < pages.Count; i++)
			pages[i].replaceWith(replace, with);
	}

	public void copyTo(Case c)
	{
		if (c != null)
		{
			c.name = name;

			//Copy conditions
			c.conditions.Clear();
			for (int i = 0; i < conditions.Count; i++)
			{
				Condition temp = new Condition();
				conditions[i].copyTo(temp);
				c.conditions.Add(temp);
			}
			
			//Copy operators
			c.operators.Clear();
			for (int i = 0; i < operators.Count; i++)
			{
				Operator temp = new Operator();
				operators[i].copyTo(temp);
				c.operators.Add(temp);
			}

			//Copy pages
			c.pages.Clear();
			for (int i = 0; i < pages.Count; i++)
			{
				Page temp = new Page("");
				pages[i].copyTo(temp);
				c.pages.Add(temp);
			}
		}
	}
}
