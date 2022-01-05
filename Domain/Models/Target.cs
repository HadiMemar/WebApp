using WebApp.Common.Base;

namespace WebApp.Domain.Models
{

    public abstract partial class Target
    {
        /// <summary>
        /// returns the Target Id
        /// </summary>
        /// <returns></returns>
        public abstract int GetTargetId();
        /// <summary>
        /// Updates Target Attrtibutes
        /// </summary>
        /// <param name="quantity"></param>
        /// <param name="attribute"></param>
        /// <returns></returns>
        internal abstract bool Update(double quantity, string attribute);
        /// <summary>
        /// Prints the Target data
        /// </summary>
    }
}