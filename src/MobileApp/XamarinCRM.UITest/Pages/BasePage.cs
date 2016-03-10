using System;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace XamarinCRM.UITest
{
    public class BasePage
    {
        protected readonly IApp app;
        protected readonly bool OnAndroid;
        protected readonly bool OniOS;
        protected Func<AppQuery, AppQuery> Trait;


        protected BasePage(IApp app, Platform platform)
        {
            this.app = app;

            OnAndroid = platform == Platform.Android;
            OniOS = platform == Platform.iOS;
        }

        protected BasePage(IApp app, Platform platform, Func<AppQuery, AppQuery> androidTrait, Func<AppQuery, AppQuery> iOSTrait)
            : this(app, platform)
        {
            if (OnAndroid)
                Trait = androidTrait;
            if (OniOS)
                Trait = iOSTrait;

            AssertOnPage(TimeSpan.FromSeconds(30));

            app.Screenshot("On " + this.GetType().Name);
        }

        protected BasePage(IApp app, Platform platform, string androidTrait, string iOSTrait)
            : this(app, platform, x => x.Marked(androidTrait), x => x.Marked(iOSTrait))
        {
        }

        /// <summary>
        /// Verifies that the trait is still present. Defaults to no wait.
        /// </summary>
        /// <param name="timeout">Time to wait before the assertion fails</param>
        protected void AssertOnPage(TimeSpan? timeout = default(TimeSpan?))
        {
            if (Trait == null)
                throw new NullReferenceException("Trait not set");

            var message = "Unable to verify on page: " + this.GetType().Name;

            if (timeout == null)
                Assert.IsNotEmpty(app.Query(Trait), message);
            else
                Assert.DoesNotThrow(() => app.WaitForElement(Trait, timeout: timeout), message);
        }
    }
}

