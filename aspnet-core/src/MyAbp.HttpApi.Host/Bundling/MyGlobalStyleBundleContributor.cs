using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace MyAbp.Bundling
{
    public class MyGlobalStyleBundleContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            //context.Files.Clear();
            context.Files.Add("/styles/global-styles.css");
        }
    }

    public class MyGlobalScriptBundleContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            //context.Files.Clear();
            context.Files.Add("/js/global-styles.js");
        }
    }
}
