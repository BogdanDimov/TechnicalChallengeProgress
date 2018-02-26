using System.Reflection;

namespace TechnicalChallengeProgress.Helpers
{
    public static class ResourceHelper
    {
        public static string GetResourceFromFileName(string fileName)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var resourceNames = assembly.GetManifestResourceNames();

            foreach (var res in resourceNames)
            {
                if (res.Contains(fileName))
                {
                    return res;
                }
            }

            return null;
        }
    }
}