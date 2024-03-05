using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using NetTechnicalTest.IDataAccess;
using NetTechnicalTest.Model;
using OpenAPIClient;
using System.Diagnostics;
using System.Threading;
using System.Xml.Linq;

namespace NetTechnicalTest.DataAccess
{
    /// <summary>
    /// Implementación de IDBAccess para la recuperación y la persistencia del modelo en MongoDB
    /// </summary>
    public class MongoDBAccess : IDBAccess
    {
        /// <summary>
        /// Cliente de la base de datos
        /// </summary>
        private MongoClient client;

        /// <summary>
        /// Construye un objeto MongoDBAccess para la recuperación y la persistencia del modelo en MongoDB
        /// </summary>
        public MongoDBAccess()
        {
            // Construimos la configuración del cliente a partir de la cadena de conexión a la base de datos (el password es demotest)
            const string CONNECTION_URI = "mongodb+srv://testdemo:********@cluster0.easyfyf.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
            MongoClientSettings settings = MongoClientSettings.FromConnectionString(CONNECTION_URI);
            // Establece el campo ServerApi del objeto de configuración para establecer la versión del Stable API en el cliente
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            // Crea un nuevo cliente y conecta al servidor
            client = new MongoClient(settings);
        }

        /// <summary>
        /// Nombre de la Base de datos
        /// </summary>
        private const string DATA_BASE_NAME = "DemoDB";

        /// <summary>
        /// Nombre de la colección para los minoristas
        /// </summary>
        private const string RETAILER_COLLECTION_NAME = "RetailerList";

        /// <summary>
        /// Almacena una lista de minoristas
        /// </summary>
        /// <param name="retailers">Listado de objetos Retailer</param>
        /// <returns>Tarea asíncrona</returns>
        public async Task SaveRetailers(IEnumerable<Retailer> retailers)
        {
            //Obtiene la conexión de la base de datos
            IMongoDatabase db = client.GetDatabase(DATA_BASE_NAME);
            //Elimina la colección de minoristas anterior para asegurarnos de que los objetos que vamos a guardar sobreescriben los existentes
            db.DropCollection(RETAILER_COLLECTION_NAME);
            //Recupera la colección de minorsitas
            IMongoCollection<Retailer> retailerCollection = db.GetCollection<Retailer>(RETAILER_COLLECTION_NAME);
            //Establece una clave única (PK) para asegurarnos que no hay elementos repetidos
            retailerCollection.Indexes.CreateOne(new CreateIndexModel<Retailer>(new IndexKeysDefinitionBuilder<Retailer>().Ascending(x => x.ReCode), new CreateIndexOptions() { Unique = true, Name = "PK" }));
            //Inserta todos los minoristas recibidos
            await retailerCollection.InsertManyAsync(retailers);

            #region Chequeo de guardado en DEBUG
#if DEBUG
            //Código que verifica aue los datos se han escrito correctamente
            IMongoCollection<Retailer> retailerCollection2 = db.GetCollection<Retailer>(RETAILER_COLLECTION_NAME);
            foreach (Retailer? item in retailerCollection2.AsQueryable())
            {
                Debug.WriteLine(item.ReName);
            }
#endif
            #endregion
        }

        /// <summary>
        /// Recupera la lista de minoristas
        /// </summary>
        /// <returns>Tarea asíncrona que devuelve un listado de objetos Retailer</returns>
        public async Task<IEnumerable<Retailer>> AllRetailers()
        {
            //Obtiene la conexión de la base de datos
            IMongoDatabase db = client.GetDatabase(DATA_BASE_NAME);
            //Recupera la colección de minorsitas
            IMongoCollection<Retailer> retailerCollection = db.GetCollection<Retailer>(RETAILER_COLLECTION_NAME);
            //Recupera todos los elementos con un filtro vacío
            return await retailerCollection.Find(Builders<Retailer>.Filter.Empty).ToListAsync();
            //También se podría hacer directamente con AsQueryable, pero entonces no sería una llamada asíncrona
            //return retailerCollection.AsQueryable();
        }

        /// <summary>
        /// Recupera un minorista a partir de su código (PK)
        /// </summary>
        /// <param name="reCode">Código unico del minorista (PK)</param>
        /// <returns>Objeto Retailer</returns>
        public async Task<Retailer> GetRetailer(string reCode)
        {
            //Obtiene la conexión de la base de datos
            IMongoDatabase db = client.GetDatabase(DATA_BASE_NAME);
            //Recupera la colección de minorsitas
            IMongoCollection<Retailer> retailerCollection = db.GetCollection<Retailer>(RETAILER_COLLECTION_NAME);
            //Construimos un filtro para buscar por la PK (propiedad ReCode)
            FilterDefinition<Retailer> filter = Builders<Retailer>.Filter.Eq(r => r.ReCode, reCode);
            //Recupera la lista de elementos que cumplen el filtro, que sólo puedo ser uno o ninugno
            return (await retailerCollection.FindAsync(filter)).FirstOrDefault();
            //También se podría hacer directamente con AsQueryable, pero entonces no sería una llamada asíncrona
            //return retailerCollection.AsQueryable().Where(r => r.ReCode == reCode).FirstOrDefault();
        }

        /// <summary>
        /// Nombre de la colección para los precios
        /// </summary>
        private const string SINGLEBALANCE_PRICE_COLLECTION_NAME = "SinglebalancePriceList";

        /// <summary>
        /// Almacena una lista de precios
        /// </summary>
        /// <param name="singlebalancePrices">Listado de objetos SinglebalancePrice</param>
        /// <returns>Tarea asíncrona</returns>
        public async Task SaveSinglebalancePrices(IEnumerable<SinglebalancePrice> singlebalancePrices)
        {
            //Obtiene la conexión de la base de datos
            IMongoDatabase db = client.GetDatabase(DATA_BASE_NAME);
            //Elimina la colección de precios anterior para asegurarnos de que los objetos que vamos a guardar sobreescriben los existentes
            db.DropCollection(SINGLEBALANCE_PRICE_COLLECTION_NAME);
            //Recupera la colección de precios
            IMongoCollection<SinglebalancePrice> singlebalancePricesCollection = db.GetCollection<SinglebalancePrice>(SINGLEBALANCE_PRICE_COLLECTION_NAME);
            //Establece una clave única (PK) para asegurarnos que no hay elementos repetidos
            singlebalancePricesCollection.Indexes.CreateOne(new CreateIndexModel<SinglebalancePrice>(new IndexKeysDefinitionBuilder<SinglebalancePrice>().Ascending(x => x.Timestamp), new CreateIndexOptions() { Unique = true, Name = "PK" }));
            //Inserta todos los precios recibidos
            await singlebalancePricesCollection.InsertManyAsync(singlebalancePrices);

            #region Chequeo de guardado en DEBUG
#if DEBUG
            //Código que verifica aue los datos se han escrito correctamente
            IMongoCollection<SinglebalancePrice> singlebalancePricesCollection2 = db.GetCollection<SinglebalancePrice>(SINGLEBALANCE_PRICE_COLLECTION_NAME);
            foreach (SinglebalancePrice? item in singlebalancePricesCollection2.AsQueryable())
            {
                Debug.WriteLine(item.Timestamp);
            }
#endif
            #endregion
        }

        /// <summary>
        /// Recupera la lista de precios
        /// </summary>
        /// <returns>Tarea asíncrona que devuelve un listado de objetos SinglebalancePrice</returns>
        public async Task<IEnumerable<SinglebalancePrice>> AllSinglebalancePrices()
        {
            //Obtiene la conexión de la base de datos
            IMongoDatabase db = client.GetDatabase(DATA_BASE_NAME);
            //Recupera la colección de precios
            IMongoCollection<SinglebalancePrice> singlebalancePricesCollection = db.GetCollection<SinglebalancePrice>(SINGLEBALANCE_PRICE_COLLECTION_NAME);
            //Recupera todos los elementos con un filtro vacío
            return await singlebalancePricesCollection.Find(Builders<SinglebalancePrice>.Filter.Empty).ToListAsync();
            //También se podría hacer directamente con AsQueryable, pero entonces no sería una llamada asíncrona
            //return singlebalancePricesCollection.AsQueryable();
        }
    }
}
