using static NotificationHubSystem.SharedKernal.Enum.CommonEnum;

namespace NotificationHubSystem.SharedKernal.Helper.Pagination
{
    /// <summary>
    /// Grid or table properties.
    /// </summary>
    public class PagingModel
    {
        /// <summary>
        /// Grid page index
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// Grid page size.
        /// </summary>
        public int PageSize { get; set; }
        public SortDirection SortingDirection { get; set; }
        public string SortingExpression { get; set; }
    }

}
