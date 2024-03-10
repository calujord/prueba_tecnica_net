using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaNet.Helpers
{
    /// <summary>
    /// States to manage responses.
    /// </summary>
    public enum ResultState
    {
        /// <summary>
        /// Success.
        /// </summary>
        [Display(Name = "Success")]
        Success,

        /// <summary>
        /// No data.
        /// </summary>
        [Display(Name = "NoData")]
        NoData,

        /// <summary>
        /// Error.
        /// </summary>
        [Display(Name = "Error")]
        Error
    }
}
