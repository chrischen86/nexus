using System;
using Nexus.Api.Intelex;
using Nexus.Api.Default;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nexus
{
    public class MyClass
    {
        private readonly Container Container;
        public MyClass()
        {
            Container = new Container(new Uri("http://ilx00385.intelex.com/devChris/api/v2/object"));
            Container.SendingRequest2 += Container_SendingRequest2;
        }

        public async Task<IEnumerable<Nexus_AssociationsObject>> TestGet()
        {
            try
            {
                var result = await Container.Nexus_AssociationsObject.ExecuteAsync();
                return result;
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        private void Container_SendingRequest2(object sender, Microsoft.OData.Client.SendingRequest2EventArgs e)
        {
            var authHeaderValue = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(@"INTELEX\Administrator:Administrator"));

            e.RequestMessage.SetHeader("Authorization", "Basic " + authHeaderValue); //this is where you pass the creds.

        }
    }
}

