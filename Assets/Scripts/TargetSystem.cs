using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TargetSystem : MonoBehaviour
{

	public Transform player;
	public float range = 15;
	public LayerMask enemyLayer; // = (1 << 13) | (1 << 14) | (1 << 15) | (1 << 16);

	public Texture2D aim;
	public float aimSize = 50;

	public GameObject currentTarget;
	//public Collider2D[] colls = new Collider2D[0];
	public List<Transform> collsRay;

	public EnemyManager _enemyManager;
	public List<Transform> colls;

	public Transform bullSpavnerTratsform;
	public LineRenderer line;

	public bool IsRight;

	public float timeFindVraga;
	public float timerFindVraga;

	public Vector3 targetPula;

	[SerializeField] private Transform _targetInIKAnimator;

	private int layer = (1 << 9) | (1 << 11)| (1 << 13)| (1 << 14)| (1 << 15)| (1 << 16);

	[SerializeField] private Transform _playerHPSlider;

	private void Start()
    {
		line = GetComponent<LineRenderer>();
		colls = _enemyManager._displayEnemy;
	}

	public void SetPositionStartPointLazer(Transform transform)
	{
        bullSpavnerTratsform = transform;
    }
 //   void RandomTarget()
	//{
	//	GameObject[] tmp = new GameObject[0];

	//	int x = 0;
	//	foreach (Collider2D element in colls)
	//	{
	//		if (currentTarget != element.gameObject) x++;
	//	}
	//	GameObject[] pureArray = new GameObject[x];
	//	x = 0;
	//	foreach (Collider2D element in colls)
	//	{
	//		if (currentTarget != element.gameObject)
	//		{
	//			pureArray[x] = element.gameObject;
	//			x++;
	//		}
	//	}
	//	tmp = new GameObject[pureArray.Length];
	//	for (int i = 0; i < tmp.Length; i++)
	//	{
	//		tmp[i] = pureArray[i];
	//	}

	//	currentTarget = tmp[Random.Range(0, tmp.Length)];
	//}

	void PlayerRotate()
	{
		
		if (currentTarget)
		{
			if (currentTarget.transform.position.x < player.position.x&&IsRight)
			{
				//transform.localScale = new Vector3(-1.5f, 1f, 1f);
				
				transform.localScale = new Vector3(-player.transform.localScale.x, player.transform.localScale.y, player.transform.localScale.z);
				_playerHPSlider.localScale = new Vector3(-_playerHPSlider.transform.localScale.x, _playerHPSlider.transform.localScale.y, _playerHPSlider.transform.localScale.z);

				IsRight = false;
			}
			else if (currentTarget.transform.position.x > player.position.x&&!IsRight)
			{
				//transform.localScale = new Vector3(1.5f, 1f, 1f);
				transform.localScale = new Vector3(-player.transform.localScale.x, player.transform.localScale.y, player.transform.localScale.z);
				_playerHPSlider.localScale = new Vector3(-_playerHPSlider.transform.localScale.x, _playerHPSlider.transform.localScale.y, _playerHPSlider.transform.localScale.z);

				IsRight = true;

			}
		}
		else
		{
			if (gameObject.GetComponent<PlayerMove>().horizont < 0&&IsRight)
			{
				//transform.localScale = new Vector3(-1.5f, 1f, 1f); 
				transform.localScale = new Vector3(-player.transform.localScale.x, player.transform.localScale.y, player.transform.localScale.z);
				_playerHPSlider.localScale = new Vector3(-_playerHPSlider.transform.localScale.x, _playerHPSlider.transform.localScale.y, _playerHPSlider.transform.localScale.z);

				IsRight = false;
			}
			else if (gameObject.GetComponent<PlayerMove>().horizont > 0&&!IsRight)
			{
				//transform.localScale = new Vector3(1.5f, 1f, 1f);
				transform.localScale = new Vector3(-player.transform.localScale.x, player.transform.localScale.y, player.transform.localScale.z);
				_playerHPSlider.localScale = new Vector3(-_playerHPSlider.transform.localScale.x, _playerHPSlider.transform.localScale.y, _playerHPSlider.transform.localScale.z);

				IsRight = true;
			}
		}
		


	}

	void OnGUI()
	{
		//if (currentTarget)
		//{
		//	Vector2 tmp = new Vector2(Camera.main.WorldToScreenPoint(currentTarget.transform.position).x,
		//							  Screen.height - Camera.main.WorldToScreenPoint(currentTarget.transform.position).y);

		//	Vector2 offset = new Vector2(-aimSize / 2, -aimSize / 2);
		//	GUI.DrawTexture(new Rect(tmp.x + offset.x, tmp.y + offset.y, aimSize, aimSize), aim);
		//}
	}

	void Update()
	{
		timerFindVraga += Time.deltaTime;
        if (timerFindVraga > timeFindVraga)
        {
			GetTarget();
			timerFindVraga = 0;

		}

  //      if (colls.Count == 0)
		//{
		//	currentTarget = null;
		//}
		//else
		//{
		//	//float curDist = Vector3.Distance(player.position, currentTarget.transform.position);
		//	//if (curDist > range)
		//	//{
		//	//	currentTarget = null;
		//	//}
		//}


        line.SetPosition(0, bullSpavnerTratsform.position);
		PlayerRotate();
		if (currentTarget)
		{

			//долбанная математическая формула для луча прицела
			//где вычилсяется к, первое число это растояние на которое быдел лететь луч
			var Rab = Mathf.Sqrt((currentTarget.transform.position.x - bullSpavnerTratsform.position.x) * (currentTarget.transform.position.x - bullSpavnerTratsform.position.x) +
				(currentTarget.transform.position.y - bullSpavnerTratsform.position.y) * (currentTarget.transform.position.y - bullSpavnerTratsform.position.y));
			var k = 25 / Rab;
			var cx = bullSpavnerTratsform.position.x + (currentTarget.transform.position.x - bullSpavnerTratsform.position.x) * k;
			var cy = bullSpavnerTratsform.position.y + (currentTarget.transform.position.y - bullSpavnerTratsform.position.y) * k;
			targetPula = new Vector3(cx, cy, 0);
			line.SetPosition(1, targetPula);
			_targetInIKAnimator.position = currentTarget.transform.position;




		}
		else
		{

			if (IsRight)
			{
				line.SetPosition(1, bullSpavnerTratsform.position + new Vector3(50, 0, 0));
				_targetInIKAnimator.position = player.position + new Vector3(15, 0, 0);
			}
			else
			{
				line.SetPosition(1, bullSpavnerTratsform.position + new Vector3(-50, 0, 0));
				_targetInIKAnimator.position = player.position + new Vector3(-15, 0, 0);
			}
		}
	}

	void NearTarget()
	{
		if (colls.Count > 0)
		{
			Transform currentCollider = null;
			float dist = Mathf.Infinity;

            foreach (Transform coll in colls)
            {
                float currentDist = Vector3.Distance(player.position, coll.position);

				 if (currentDist < dist)   
                {
                    currentCollider = coll;
                    dist = currentDist;
                }

            }
			if (currentCollider != null)
			{
				currentTarget = currentCollider.gameObject;
				
			}
            
		}
		else
		{
			currentTarget = null;
		}
	}
    void NearTargetRay()
    {      
        if (collsRay.Count > 0)
        {
            Transform currentCollider = null;
            float dist = Mathf.Infinity;

            foreach (Transform coll in collsRay)
            {
                float currentDist = Vector3.Distance(player.position, coll.position);
                if (currentDist < dist)
                {
                    currentCollider = coll;
                    dist = currentDist;
                }
            }
            if (currentCollider != null)
            {
                currentTarget = currentCollider.gameObject;
            }
        }
    }

    void GetTarget()
	{
		collsRay.Clear();
        foreach (var coll in colls)
        {
            RaycastHit2D hit2D = Physics2D.Raycast(bullSpavnerTratsform.transform.position, (coll.position - bullSpavnerTratsform.transform.position).normalized, Mathf.Infinity, layer);
            if (hit2D)
            {
                if (hit2D.collider.TryGetComponent<Enemy>(out Enemy enemy))
                {
                    collsRay.Add(coll);
                }
            }
        }
        if (collsRay.Count > 0)
        {           
            NearTargetRay();	
        }
        else
        {
            NearTarget();
        }
	}
}