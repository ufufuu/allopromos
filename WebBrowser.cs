using System;
public static class WebBrowser
{
    public static IE Current
    {
        get
        {
            if (!ScenarioContext.Current.ContainsKey("browser"))
                ScenarioContext.Current["browser"] = new IE();
            return ScenarioContext.Current["browser"] as IE;
        }
    }
    [Given(@"I am logged into the site as an administrator")]
    public void GivenIAmLoggedIntoTheSiteAsAnAdministrator()
    {
        WebBrowser.Current.GoTo(https://localhost:24613/Account/LogOn);
        WebBrowser.Current.TextField(Find.ByName("UserName")).TypeText("admin");
        WebBrowser.Current.TextField(Find.ByName("Password")).TypeText("pass123");
        WebBrowser.Current.Button(Find.ByValue("Log On")).Click();
        Assert.IsTrue(WebBrowser.Current.Link(Find.ByText("Log Off")).Exists);
    }
}
