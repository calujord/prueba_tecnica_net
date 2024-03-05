using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using OpenAPIClient;

namespace NetTechnicalTest.Model
{
    /// <summary>
    /// Ojbeto de modelo que representa a un precio
    /// </summary>
    public class SinglebalancePrice
    {
        /// <summary>
        /// Constructor por defecto (sirve para que JSON pueda deserializar)
        /// </summary>
        public SinglebalancePrice() { }

        /// <summary>
        /// Construye un objeto precio a patir del objeto de transporte de datos (DTP)
        /// </summary>
        /// <param name="singlebalancePriceDTO">Objeto DTO</param>
        public SinglebalancePrice(SinglebalancePriceDTO singlebalancePriceDTO)
        {
            DownRegPrice = singlebalancePriceDTO.DownRegPrice;
            ImblPurchasePrice = singlebalancePriceDTO.ImblPurchasePrice;
            ImblSalesPrice = singlebalancePriceDTO.ImblSalesPrice;
            IncentivisingComponent = singlebalancePriceDTO.IncentivisingComponent;
            MainDirRegPowerPerMBA = singlebalancePriceDTO.MainDirRegPowerPerMBA;
            Mba = singlebalancePriceDTO.Mba;
            Timestamp = singlebalancePriceDTO.Timestamp;
            UpRegPrice = singlebalancePriceDTO.UpRegPrice;
            ValueOfAvoidedActivation = singlebalancePriceDTO.ValueOfAvoidedActivation;
        }

        /// <summary>
        /// Idenitificador propio del modelo
        /// </summary>
        [BsonId]
        public ObjectId ID { get; set; }

        /// <summary>
        /// DownRegPrice
        /// </summary>
        [BsonElement("downRegPrice")]
        public double DownRegPrice { get; set; }

        /// <summary>
        /// ImblPurchasePrice
        /// </summary>
        [BsonElement("imblPurchasePrice")]
        public double ImblPurchasePrice { get; set; }

        /// <summary>
        /// ImblSalesPrice
        [BsonElement("imblSalesPrice")]
        public double ImblSalesPrice { get; set; }

        /// <summary>
        /// IncentivisingComponent
        /// </summary>
        [BsonElement("incentivisingComponent")]
        public double IncentivisingComponent { get; set; }

        /// <summary>
        /// MainDirRegPowerPerMBA
        /// </summary>
        [BsonElement("mainDirRegPowerPerMBA")]
        public double MainDirRegPowerPerMBA { get; set; }

        /// <summary>
        /// MBA
        /// </summary>
        [BsonElement("mba")]
        public string Mba { get; set; }

        /// <summary>
        /// Timestamp (PK)
        /// </summary>
        [BsonElement("timestamp")]
        public string Timestamp { get; set; }

        /// <summary>
        /// UpRegPrice
        /// </summary>
        [BsonElement("upRegPrice")]
        public double UpRegPrice { get; set; }

        /// <summary>
        /// ValueOfAvoidedActivation
        /// </summary>
        [BsonElement("valueOfAvoidedActivation")]
        public double ValueOfAvoidedActivation { get; set; }
    }
}
