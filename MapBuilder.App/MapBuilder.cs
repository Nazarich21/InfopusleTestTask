using System;
using System.Collections.Generic;

namespace MapBuilder.App
{
    public class MapBuilder
    {
        private SignStep _currentOfficeManagerPosition = new()
        {
            Floor = 0,
            Section = 1
        };

        public IEnumerable<string> BuildRouteMap(IEnumerable<SignStep> signatureMap)
        {
            List<string> result = new List<string>();
            string elevator;

            foreach (var step in signatureMap) 
            {
                elevator = step.Floor % 2 == 0 ? "E1" : "E2";
                string res = RouteBySteps(_currentOfficeManagerPosition, step) <= RouteByElevator(_currentOfficeManagerPosition, step) ? "S" : elevator;
                _currentOfficeManagerPosition = step;
                result.Add(res);
            }

            return result;
        }

        public int RouteBySteps(SignStep start, SignStep destination) 
        {
            return Math.Abs(start.Floor - destination.Floor) * 2;   
        }

        public int RouteByElevator(SignStep start, SignStep destination)
        {
            return start.Section == destination.Section ? Math.Abs(start.Floor - destination.Floor) + 1 : Math.Abs(start.Floor - destination.Floor) + 2;
        }
    }
}