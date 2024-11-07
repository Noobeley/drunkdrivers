using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Algorithm : MonoBehaviour
{
    public int FindSmallestValue(List<int> numbers)
    {
        int smallest = int.MaxValue;
        foreach (int num in numbers)
        {
            if (num < smallest)
            {
                smallest = num;
            }
        }
        return smallest;
    }


}
