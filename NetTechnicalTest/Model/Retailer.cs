using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using OpenAPIClient;

namespace NetTechnicalTest.Model
{
    /// <summary>
    /// Ojbeto de modelo que representa a un minorista
    /// </summary>
    public class Retailer
    {
        /// <summary>
        /// Constructor por defecto (sirve para que JSON pueda deserializar)
        /// </summary>
        public Retailer() {}
        
        /// <summary>
        /// Construye un objeto minorista a patir del objeto de transporte de datos (DTP)
        /// </summary>
        /// <param name="retailerDTO">Objeto DTO</param>
        public Retailer(RetailerDTO retailerDTO)
        {
            CodingScheme = retailerDTO.CodingScheme;
            Country = retailerDTO.Country;
            ReCode = retailerDTO.ReCode;
            ReName = retailerDTO.ReName;
        }

        /// <summary>
        /// Idenitificador propio del modelo
        /// </summary>
        [BsonId]
        public ObjectId ID { get; set; }

        /// <summary>
        /// Esquema de codificación
        /// </summary>
        [BsonElement("codingScheme")]
        public string CodingScheme { get; set; }

        /// <summary>
        /// Pais del minorista
        /// </summary>
        [BsonElement("country")]
        public string Country { get; set; }

        /// <summary>
        /// Código del minorista (PK)
        /// </summary>
        [BsonElement("reCode")]
        public string ReCode { get; set; }

        /// <summary>
        /// Nombre del minorista
        /// </summary>
        [BsonElement("reName")]
        public string ReName { get; set; }
    }
}
