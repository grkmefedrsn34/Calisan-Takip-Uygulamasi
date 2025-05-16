using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Persistance.Extensions
{
    public record PagedData<T> where T : class, new()
    {
        public int activePage { get; set; }
        public int pageSize { get; set; }
        public int TotalRecords { get; set; }
        public int pageCount { get; set; }
        public List<T> data { get; set; }
        public PagedData(List<T> data,int activePage, int TotalRecords, int pageSize)
       {
            this.data = data;
            this.activePage = activePage;
            this.pageSize = pageSize;
            this.TotalRecords = TotalRecords;
            this.pageCount = (int)Math.Ceiling((double)TotalRecords / pageSize);
        }
    }
}
