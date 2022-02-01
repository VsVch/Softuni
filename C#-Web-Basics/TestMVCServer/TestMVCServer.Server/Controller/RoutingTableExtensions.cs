using System.Reflection;
using TestMVCServer.Server.Http;
using TestMVCServer.Server.Routing;

namespace TestMVCServer.Server.Controller
{
    public static class RoutingTableExtensions
    {
        private static Type httpResponseType = typeof(HttpResponse);

        public static IRoutingTable MapGet<TController>(
            this IRoutingTable routingTable,
            string path,
            Func<TController, HttpResponse> controllerFunction)
            where TController : Controller
             => routingTable.MapGet(path, request => controllerFunction(
             CreateController<TController>(request)));


        public static IRoutingTable MapPost<TController>(
            this IRoutingTable routingTable,
            string path,
            Func<TController, HttpResponse> controllerFunction)
            where TController : Controller
            => routingTable.MapPost(path, request => controllerFunction(
              CreateController<TController>(request)));

        public static IRoutingTable MapControllers(this IRoutingTable routingTable)
        {
            var controllerActions = GetControllerActions();

            foreach (var controllerAction in controllerActions)
            {
                var controlerName = controllerAction.DeclaringType.GetControllerName();
                var actionName = controllerAction.Name;

                var path = $"/{controlerName}/{actionName}";

                var responseFunction = GetResponseFunction(controllerAction);
                 
                routingTable.MapGet(path, responseFunction);

                MapDefaultRoutes(routingTable, actionName, controlerName, responseFunction);
            }

            return routingTable;
        }      

        private static IEnumerable<MethodInfo> GetControllerActions() 
        => Assembly
                .GetEntryAssembly()
                .GetExportedTypes()
                .Where(t =>!t.IsAbstract 
                    && t.IsAssignableTo(typeof(Controller))
                    && t.Name.EndsWith(nameof(Controller)))
                .SelectMany(t => t
                    .GetMethods(BindingFlags.Public | BindingFlags.Instance)
                    .Where(m => m.ReturnType.IsAssignableTo(httpResponseType)))
                .ToList();

        private static Func<HttpRequest, HttpResponse> GetResponseFunction( MethodInfo controllerAction) 
            => request =>
            {
                var controllerInstance = CreateController(controllerAction.DeclaringType, request);
                                
                return (HttpResponse)controllerAction.Invoke(controllerInstance, Array.Empty<object>());
            };

        private static void MapDefaultRoutes(
          IRoutingTable routingTable,
          string actionName,
          string controllerName,
          Func<HttpRequest, HttpResponse> responseFunction)
        {
            const string defautActionName = "Index";
            const string defautControllerName = "Home";

            if (actionName == defautActionName)
            {
                routingTable.MapGet($"/{controllerName}", responseFunction);

                if (controllerName == defautControllerName)
                {
                    routingTable.MapGet("/", responseFunction);
                }
            }
        }

        private static object CreateController(Type controller,HttpRequest request)
        => Activator.CreateInstance(controller, new[] { request });

        private static TController CreateController<TController>(HttpRequest request)
        => (TController)Activator.CreateInstance(typeof(TController), request);
    }
}
