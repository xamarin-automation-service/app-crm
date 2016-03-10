using Xamarin.UITest;

namespace XamarinCRM.UITest
{
    public class SplashScreenPage : BasePage
    {
        readonly string EnterSignInButton = "SIGN IN";
        readonly string SkipSignInButton = "SKIP SIGN IN (demo)";

        public SplashScreenPage(IApp app, Platform platform)
            : base(app, platform, "SIGN IN", "SIGN IN")
        {
        }

        public void ExitSplashScreen()
        {
            app.Tap(EnterSignInButton);
        }

        public void SkipSignIn()
        {
            app.Tap(SkipSignInButton);
        }

    }
}

