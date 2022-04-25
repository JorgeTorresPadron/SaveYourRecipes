using System;
using System.Reflection;
using System.Resources;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaveYourRecipes.Extensions
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        public const string ResourceId = "SaveYourRecipes.Strings.Strings";
        private static readonly Lazy<ResourceManager> resMgr = new Lazy<ResourceManager>(() => new ResourceManager(ResourceId, typeof(TranslateExtension).GetTypeInfo().Assembly));

        public string Text { get; set; }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
            {
                return string.Empty;
            }

            var ci = Thread.CurrentThread.CurrentCulture;
            var translate = resMgr.Value.GetString(Text, ci);
            if (translate == null)
            {
                return Text;
            }

            return translate;
        }
    }
}
