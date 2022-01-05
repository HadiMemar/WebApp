using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApp.Common
{
    public interface ISoftDeletableEntity
    {
        /// <summary>
        /// Gets or Sets if the entity is deleted
        /// </summary>
        bool IsDeleted { get; set; }

        [JsonIgnore]
        /// <summary>
        /// Gets or sets the user who is performing the delete action
        /// </summary> 
        string DeletedBy { get; set; }

        [JsonIgnore]
        /// <summary>
        /// Gets or Sets the deleted date of the entity
        /// </summary>
        DateTime? DeletedDate { get; set; }
    }
}
