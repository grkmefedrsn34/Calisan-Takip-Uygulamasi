using System;
using System.Collections.Generic;

namespace TaskManagentment.Application.DTOs
{
    // Genel cevap yapısı - artık her tür veri ile çalışabilir (tekil ya da liste)
    public record Response<T>(T Data, bool IsSuccess, string? ErrorMessage, List<ValidationErorrs>? Errors);

    // Validasyon hatası model
    public record ValidationErorrs(string PropertyName, string ErrorMessage);

    // Veri dönülmeyecek işlemler için kullanılabilir model
    public record NoData();

    // Sayfalama sonucu için model
    public record PagedResult<T>(List<T> Data, int ActivePage, int PageSize, int TotalPage);

    // Sayfalı veri yapısı (detaylı)
    public record PagedData<T> where T : class, new()
    {
        public int ActivePage { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public int PageCount { get; set; }
        public List<T> Data { get; set; }

        public PagedData(List<T> data, int activePage, int totalRecords, int pageSize)
        {
            Data = data;
            ActivePage = activePage;
            PageSize = pageSize;
            TotalRecords = totalRecords;
            PageCount = (int)Math.Ceiling((double)totalRecords / pageSize);
        }
    }
}
