namespace ASP.netCoreTreningApp.RouteConstraint
{
    public class CyrillicRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            var value = values.FirstOrDefault(x => x.Key == routeKey).Value?.ToString();

            if (value == null)
            {
                return false;
            }

            foreach (var ch in value)
            {
                var allowedCharacters = "абвгдежзийклмнопрстуфхцчшщъьюя";

                if (!allowedCharacters.Contains(char.ToLower(ch)))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
