using System.Collections.Generic;

namespace NotificationHubSystem.SharedKernal.Helper.Pagination
{
    /// <summary>
    /// Grid or table data.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageList<T>
    {
        /// <summary>
        /// Grid data list
        /// </summary>
        public List<T> DataList { get; set; }
        /// <summary>
        /// Grid total data count.
        /// </summary>
        public int TotalCount { get; set; }
        public PageList()
        {
            DataList = new List<T>();
        }
    }
}
