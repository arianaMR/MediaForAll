using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaForAll.Web.Models.Responses
{
    public class ItemItemsResponse<T1, T2> : SuccessResponse
    {
        public T1 Item { get; set; }
        public List<T2> Items { get; set; }
    }
}