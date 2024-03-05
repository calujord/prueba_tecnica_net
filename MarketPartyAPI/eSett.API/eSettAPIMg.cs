using eSett.Model;

namespace eSett.API
{
    public abstract class eSettAPIMg
    {
        protected OpenData _api;

        /// <summary>
        /// Opens a channel from uri using HttpClient
        /// </summary>
        /// <param name="uri">Base Address of the WS</param>
        /// <returns>true if connection was possible, false if not</returns>
        public bool Open(string uri)
        {
            bool result;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(uri);
                _api = new OpenData(client);
                result = true;
            }
            catch(Exception ex)
            {
                xLog.Logger.AddFailure(ex.Message + uri);
                result = false;
            }
            return result;
        }

        protected List<I_MarketParty> Get<T>(Task<ICollection<T>> task, Func<T, I_MarketParty> func)
        {
            List<I_MarketParty> result = new();

            task.Wait();

            if (task.IsCompletedSuccessfully)
            {
                if (task.Result is not null)
                {
                    foreach (var item in task.Result)
                    {
                        try
                        {
                            result.Add(func.Invoke(item));
                        }
                        catch (Exception ex)
                        {
                            xLog.Logger.AddFailure(item + ": " + ex.Message);
                        }
                    }
                }
            }
            else
                throw new Exception(task.Status.ToString(), task.Exception);

            return result;
        }

        //public List<BalanceResponsibleParty> GetBalanceResponsibleParties(string code, string country, string name)
        //{
        //    var result = new List<BalanceResponsibleParty>();
        //    var list = _api.BalanceResponsiblePartiesAsync(code, country, name).Result;
        //    foreach (var item in list)
        //    {
        //        result.Add(new BalanceResponsibleParty()
        //        {
        //            Code = item.BrpCode,
        //            Name = item.BrpName,
        //            country = item.Country,
        //            codingScheme = item.CodingScheme,
        //            bussinesId = item.BusinessId,
        //            validityEnd = item.ValidityEnd,
        //            validityStart = item.ValidityStart
        //        });
        //    }
        //    return result;
        //}

        //public List<BalanceServiceProvider> GetBalanceServiceProviders(string code, string country, string name)
        //{
        //    var result = new List<BalanceServiceProvider>();
        //    var list = _api.BalanceServiceProvidersAsync(code, country, name).Result;
        //    foreach (var item in list)
        //    {
        //        result.Add(new BalanceServiceProvider()
        //        {
        //            Code = item.BspCode,
        //            Name = item.BspName,
        //            country = item.Country,
        //            codingScheme = item.CodingScheme,
        //            bussinesId = item.BusinessId
        //        });
        //    }
        //    return result;
        //}

    }
}
