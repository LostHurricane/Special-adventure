using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SpecialAdventure
{
    public static class Extentions
    {
        public static bool IsVisibleFrom(this Renderer renderer, Camera camera)
        {
            Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
            return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
        }


        public static List<T> SortByDistance<T>(this List<T> objects, Vector3 mesureFrom) where T : Component
        {
            return objects.OrderBy(x => Vector3.Distance(x.transform.position, mesureFrom)).ToList();
        }

    }
}
