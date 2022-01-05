using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApp.Common.Base
{
    public class BaseSoftDeletableEntity
    {
        /// <summary>
        /// Gets or Sets if the entity is deleted
        /// </summary>
        [JsonIgnore]
        public bool IsDeleted { get; set; }

        [JsonIgnore]
        /// <summary>
        /// Gets or Sets the deleted date of the entity
        /// </summary>
        public DateTime? DeletedDate { get; set; }

        [JsonIgnore]
        [MaxLength(100)]
        /// <summary>
        /// Gets or sets the user who is performing the delete action
        /// </summary> 
        public string DeletedBy { get; set; }
    }
}
