﻿namespace WicodeApi.Customs;

public class ApiResult<T>
{
    public string StatusCode { get; set; } = "";
    public string Message { get; set; } = "";
    public int Count
    {
        get
        {
            if (Element == null)
            {
                if (Results != null)
                    return Results.Count;
                return 0;
            }
            else
                return 1;
        }
    }
    public List<T> Results { get; set; } = new List<T>();

    public T Element { get; set; }

}
