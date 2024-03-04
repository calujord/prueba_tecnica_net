using Azure;
using eSettPruebatecnica.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace eSettPruebatecnica.Infrastructure.Persistence
{
    public class eSettDbContextSeed
    {
        public static async Task SeedAsync(eSettDbContext context, ILogger<eSettDbContextSeed> logger)
        {
            if(context.BalanceResponsibleParties.Count()==0)
                await GetPreconfiguredBalanceRespPartiesAsync(context, logger);

            if (context.BalanceServiceProviders.Count() == 0)
                await GetBalanceServiceProvidersAsync(context, logger);

            if (context.DistributionSystemOperators.Count() == 0)
                await GetDistributionSystemOperatorsAsync(context, logger);

            if (context.Retailers.Count() == 0)
                await GetRetailersAsync(context, logger);

        }
        private static async Task<List<BalanceResponsiblePartie>> GetPreconfiguredBalanceRespPartiesAsync(eSettDbContext _context, ILogger<eSettDbContextSeed> logger)
        {
            string apiUrl = "https://api.opendata.esett.com/EXP01/BalanceResponsibleParties";
            IEnumerable<BalanceResponsiblePartie> apiData = null;
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        apiData = await response.Content.ReadFromJsonAsync<IEnumerable<BalanceResponsiblePartie>>();
                        if (apiData.Any())
                        {
                            await ClearBalanceResponsibleParties(_context);

                            await _context.BalanceResponsibleParties!.AddRangeAsync(apiData);
                            await _context.SaveChangesAsync();
                            logger.LogInformation("Estamos insertando nuevos records al db {context}", typeof(eSettDbContext).Name);
                        }
                    }
                    else
                    {
                        logger.LogInformation($"Error al obtener datos de la API: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    logger.LogInformation($"Error al realizar la solicitud HTTP: {ex.Message}");
                }
            }
            return apiData.ToList();

        }
        private static async Task ClearBalanceResponsibleParties(eSettDbContext _context)
        {
            var existingData = await _context.BalanceResponsibleParties.ToListAsync();
            _context.BalanceResponsibleParties.RemoveRange(existingData);
            await _context.SaveChangesAsync();
        }

        private static async Task<List<BalanceServiceProvider>> GetBalanceServiceProvidersAsync(eSettDbContext _context, ILogger<eSettDbContextSeed> logger)
        {
            string apiUrl = "https://api.opendata.esett.com/EXP01/BalanceServiceProviders";
            IEnumerable<BalanceServiceProvider> apiData = null;
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        apiData = await response.Content.ReadFromJsonAsync<IEnumerable<BalanceServiceProvider>>();
                        if (apiData.Any())
                        {
                            await ClearBalanceServiceProvider(_context);

                            await _context.BalanceServiceProviders!.AddRangeAsync(apiData);
                            await _context.SaveChangesAsync();
                            logger.LogInformation("Estamos insertando nuevos records al db {context}", typeof(eSettDbContext).Name);
                        }
                    }
                    else
                    {
                        logger.LogInformation($"Error al obtener datos de la API: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    logger.LogInformation($"Error al realizar la solicitud HTTP: {ex.Message}");
                }
            }
            return apiData.ToList();
        }
        private static async Task ClearBalanceServiceProvider(eSettDbContext _context)
        {
            var existingData = await _context.BalanceServiceProviders.ToListAsync();
            _context.BalanceServiceProviders.RemoveRange(existingData);
            await _context.SaveChangesAsync();
        }
        private static async Task<List<DistributionSystemOperator>> GetDistributionSystemOperatorsAsync(eSettDbContext _context, ILogger<eSettDbContextSeed> logger)
        {
            string apiUrl = "https://api.opendata.esett.com/EXP01/DistributionSystemOperators";
            IEnumerable<DistributionSystemOperator> apiData = null;
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        apiData = await response.Content.ReadFromJsonAsync<IEnumerable<DistributionSystemOperator>>();
                        if (apiData.Any())
                        {
                            await ClearDistributionSystemOperator(_context);

                            await _context.DistributionSystemOperators!.AddRangeAsync(apiData);
                            await _context.SaveChangesAsync();
                            logger.LogInformation("Estamos insertando nuevos records al db {context}", typeof(eSettDbContext).Name);
                        }
                    }
                    else
                    {
                        logger.LogInformation($"Error al obtener datos de la API: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    logger.LogInformation($"Error al realizar la solicitud HTTP: {ex.Message}");
                }
            }
            return apiData.ToList();
        }
        private static async Task ClearDistributionSystemOperator(eSettDbContext _context)
        {
            var existingData = await _context.DistributionSystemOperators.ToListAsync();
            _context.DistributionSystemOperators.RemoveRange(existingData);
            await _context.SaveChangesAsync();
        }

        private static async Task<List<Retailer>> GetRetailersAsync(eSettDbContext _context, ILogger<eSettDbContextSeed> logger)
        {
            string apiUrl = "https://api.opendata.esett.com/EXP01/Retailers";
            IEnumerable<Retailer> apiData = null;
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        apiData = await response.Content.ReadFromJsonAsync<IEnumerable<Retailer>>();
                        if (apiData.Any())
                        {
                            await ClearRetailer(_context);

                            await _context.Retailers!.AddRangeAsync(apiData);
                            await _context.SaveChangesAsync();
                            logger.LogInformation("Estamos insertando nuevos records al db {context}", typeof(eSettDbContext).Name);
                        }
                    }
                    else
                    {
                        logger.LogInformation($"Error al obtener datos de la API: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    logger.LogInformation($"Error al realizar la solicitud HTTP: {ex.Message}");
                }
            }
            return apiData.ToList();
        }
        private static async Task ClearRetailer(eSettDbContext _context)
        {
            var existingData = await _context.Retailers.ToListAsync();
            _context.Retailers.RemoveRange(existingData);
            await _context.SaveChangesAsync();
        }
    }
}
