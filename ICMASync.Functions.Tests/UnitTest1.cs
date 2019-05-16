using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ICMASync.Functions.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CallSync()
        {
            // I want to be able to trigger the Sync function from here...
            // this will also happen from the Azure Function App when added

            // these are the params from the call before

            //await Engine.Sync("xweb_ro", "letmein777", DateTime.Now.AddMonths(-1), "icma-sandbox.preprod.hivebrite.com", "jcook@icma.org", "Belgem100", "3020e253bf632991c57407994951510f05676d2a21d00f87519984cc1f80f068", "83fad47bf170dcbf274cadacafc3e1f085e7d907ff8704f1e0c51149bc857930", 18414);
        }
    }
}
