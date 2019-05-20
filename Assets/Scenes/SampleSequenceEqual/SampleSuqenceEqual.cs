using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SampleSuqenceEqual
{
    public class SampleSuqenceEqual : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            var listA = new List<int>() { 0, 1, 2 };
            var listB = new List<int>() { 0, 1, 2 };
            var listC = new List<int>() { 0, 2, 1 };
            Debug.Log("listA==listB:" + listA.SequenceEqual(listB));// true
            Debug.Log("listA==listC:" + listA.SequenceEqual(listC));// false

            var listD = new List<Param>() { new Param() { a = 0, b = 1 }, new Param() { a = 1, b = 0 } };
            var listE = new List<Param>() { new Param() { a = 0, b = 1 }, new Param() { a = 1, b = 0 } };
            Debug.Log("listD==listE:" + listD.SequenceEqual(listE));// false

            var paramA = new Param() { a = 0, b = 1 };
            var paramB = new Param() { a = 1, b = 0 };
            var listF = new List<Param>() { paramA, paramB };
            var listG = new List<Param>() { paramA, paramB };
            var listH = new List<Param>() { paramB, paramA };
            Debug.Log("listF==listG:" + listF.SequenceEqual(listG));// true
            Debug.Log("listF==listH:" + listF.SequenceEqual(listH));// false

            var listI = new List<Param>() { new Param() { a = 0, b = 1 }, new Param() { a = 1, b = 0 } };
            var listJ = new List<Param>() { new Param() { a = 0, b = 1 }, new Param() { a = 1, b = 0 } };
            var paramComparer = new ParamComparer();
            Debug.Log("listI==listJ:" + listI.SequenceEqual(listJ, paramComparer));// true
        }

        class Param
        {
            public int a;
            public int b;
        }

        class ParamComparer : IEqualityComparer<Param>
        {
            public bool Equals(Param p1, Param p2)
            {
                if (p1.a == p2.a &&
                    p1.b == p2.b)
                    return true;
                return false;
            }

            public int GetHashCode(Param obj)
            {
                throw new System.Exception();
            }
        }
    }
}