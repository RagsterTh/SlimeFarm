using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public enum AgePhase
{
    Child, Adult, Elder
}
public enum Types
{//Tenho que ver quais vou fazer
    Green, Blue, Red, Purple
}
public class Slime : MonoBehaviour
{
    public AgePhase agePhase;
    [Range(1, 4)]public int reproductionQtd;
    public Types type;
    public int growRate = 1;
    public int age;
    public int moveFrequence = 1;

    public Transform[] reproductionPoints;

    NavMeshAgent agent;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(Grow());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (agePhase.Equals(AgePhase.Adult))
        {
            Reproduce();
        }
    }
    IEnumerator Move()
    {
        yield return new WaitForSeconds(moveFrequence);
        
    }
    void Reproduce()
    {
        int babiesNumber = Random.Range(1, reproductionQtd);
        List<Transform> points = reproductionPoints.ToList<Transform>();
        for (int i = 0; i < babiesNumber; i++)
        {
            int randPos = Random.Range(0, points.Count);
            Instantiate(GameController.instance.slime, points[randPos].position, transform.rotation).GetComponent<Slime>().Birth
                (
                    Random.Range(growRate / 2, growRate * 2) 
                );
            points.RemoveAt(randPos);
        }
        Destroy(gameObject);
    }
    public void Birth(int growRate)
    {
        agePhase = AgePhase.Child;
        this.growRate = growRate > 0 ? growRate : 1;
    }
    IEnumerator Grow()
    {
        yield return new WaitForSeconds(growRate * 10);
        age++;
        if(age >= GameController.instance.adultAge)
        {
            if(age >= GameController.instance.elderAge)
            {
                agePhase = AgePhase.Elder;
            } else
            {
                agePhase = AgePhase.Adult;
            }
        }
        StartCoroutine(Grow());
    }
    /*
    Vector2 RandomPoint()
    {
        Vector3 randomPosition = Random.insideUnitSphere * 30;
        randomPosition.y = 0;
        randomPosition += transform.position;
        UnityEngine.AI.NavMeshHit hit;
        UnityEngine.AI.NavMesh.SamplePosition(randomPosition, out hit, 5, 1);
        Vector3 finalPosition = hit.position;
        position = finalPosition;
        //SetRandomNavTarget();
        //   transform.LookAt (finalPosition); 
        Debug.Log("Movendo");
    }
    */
}
