﻿namespace CashFlow.Api.Middleware;

public class CultureMiddleware
{
    private readonly RequestDelegate _next;



    public CultureMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context
	{
       var culture = context.Request.Headers.AcceptLanguage.FirstOrDefault();

        var cultureInfo = new CultureInfo("pt-BR");

        if (string.IsNullOrWhiteSpace(culture) == false) 
        {
            cultureInfo = new CultureInfo(culture);
        }

        cultureInfo.CurrentCulture = cultureInfo;
        cultureInfo.CurrentUICulture = cultureInfo;

        await _next(context);
    }
}