using Newtonsoft.Json;

namespace Utilities.Models;

public class BankIdentification
    {
        /// <summary>
        /// The first 4 number in a bank account
        /// </summary>
        [JsonProperty("Bank identifier")]
        public string Bankidentifier { get; set; }

        /// <summary>
        /// Business Identifier Code. An internationally recognized bank code used to identify financial and non-financial institutions
        /// </summary>
        [JsonProperty("BIC")]
        public string BIC { get; set; }

        /// <summary>
        /// Bank Name
        /// </summary>
        [JsonProperty("Bank")]
        public string Bank { get; set; }
    }
