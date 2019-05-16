using System;
using System.Threading.Tasks;
using ICMASync.Data;
using ICMASync.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ICMASync.Functions.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task CallSync()
        {
            // I want to be able to trigger the Sync function from here...
            // this will also happen from the Azure Function App when added
            
            //Yout have to store it somewhere and get it when you'll need it in app.settings or just hardcode it
            var connectionString = "Server=tcp:icmasql07.database.windows.net,1433;Initial Catalog=icmaconnect;Persist Security Info=False;User ID=cnctsql777;Password=G4d7#jt5;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            var factory = new BaseContextFactory(connectionString);

            // these are the params from the call before
            var engine = new Engine(factory);
            var @params = new EngineSyncParams("xweb_ro", "letmein777", DateTime.Now.AddMonths(-1), "icma-sandbox.preprod.hivebrite.com", "jcook@icma.org", "Belgem100", "3020e253bf632991c57407994951510f05676d2a21d00f87519984cc1f80f068", "83fad47bf170dcbf274cadacafc3e1f085e7d907ff8704f1e0c51149bc857930", 18414);
            await engine.Sync(@params);

            //await Engine.Sync("xweb_ro", "letmein777", DateTime.Now.AddMonths(-1), "icma-sandbox.preprod.hivebrite.com", "jcook@icma.org", "Belgem100", "3020e253bf632991c57407994951510f05676d2a21d00f87519984cc1f80f068", "83fad47bf170dcbf274cadacafc3e1f085e7d907ff8704f1e0c51149bc857930", 18414);
        }
    }
}
