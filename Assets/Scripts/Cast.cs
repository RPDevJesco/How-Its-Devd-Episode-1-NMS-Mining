using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cast : MonoBehaviour 
{
	LineRenderer line;
	public float distance = 100f;
	int counter = 0;

	void Start()
	{
		line = GetComponent<LineRenderer>();
		line.enabled = false;
	}

	private IEnumerator fireCannon()
	{
		line.enabled = true;
		counter = 0;

		while (Input.GetButton("Fire1"))
		{
			Ray ray = new Ray(transform.position, Vector3.forward);
			RaycastHit hit;
			counter++;

			if (counter < 50)
			{
			line.SetPosition(0, ray.origin);

			if (Physics.Raycast(ray, out hit, distance))
			{

                line.SetPosition(1, hit.point);

				BreakableOre breakable = hit.collider.GetComponent<BreakableOre>();

				if (breakable != null)
					breakable.DamageDelt(1f);
			}
			else
			{
				line.SetPosition(1, ray.direction * distance);
			}
			}
			else
			{
				line.enabled = false;
				yield return new WaitForSeconds(5);
			}

			yield return null;
		}
		line.enabled = false;
	}
	void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			StopCoroutine("fireCannon");
			StartCoroutine("fireCannon");
		}
	}
}
