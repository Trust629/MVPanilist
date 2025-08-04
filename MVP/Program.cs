using MVP.Components;
using GraphQL.Client;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<IGraphQLClient>(s => 
    new GraphQLHttpClient(
        new GraphQLHttpClientOptions
        {
            EndPoint = new Uri(builder.Configuration["GraphQLServerUri"])
        },
        new NewtonsoftJsonSerializer()
    )
);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();
app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();