using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class RandomNumber : MonoBehaviour
{
    private SnakeRoute snakeRoute;
    int randomIndex;
    int bound;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("GenerateRandomNumber",0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async Task<int> GenerateRandomNumber()
    {
        var nr = snakeRoute.ReturnCount();
        bound = await nr;
        randomIndex = Random.Range(0, bound);
        return randomIndex;
    }
}
