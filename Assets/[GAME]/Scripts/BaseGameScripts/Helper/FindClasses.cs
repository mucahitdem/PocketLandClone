using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts.BaseGameScripts.Helper
{
    public class FindClasses : MonoBehaviour
    {
        public static List<TClass> FindClassesImplement<TClass>()
        {
            var classesImplemented = FindObjectsOfType<Object>().OfType<TClass>();
            return new List<TClass>(classesImplemented);
        }
    }
}