var hearthstoneApiBaseUrl = "https://omgvamp-hearthstone-v1.p.rapidapi.com";

var hearthstoneApiClient = RestService
    .For<IHearthStoneApi>(hearthstoneApiBaseUrl);

try
{
    var cards = await hearthstoneApiClient.GetCardsByName("xpto");
}
catch (ApiException e)
{
    e.Content.Print("Content: ");
    e.StatusCode.Print("StatusCode: ");
    e.ReasonPhrase.Print("ReasonPhrase: ");
    e.Headers.Print("Headers: ");
    e.HttpMethod.Print("HttpMethod: ");
    (await e.GetContentAsAsync<HearthstoneError>()).Print("GetContentAsAsync: ");
}

#region Not throwing

//var response = await hearthstoneApiClient.GetCardsByName("xpto");
//response.Error?.Content.Print("Content: ");
//response.Error?.StatusCode.Print("StatusCode: ");
//response.Error?.ReasonPhrase.Print("ReasonPhrase: ");
//response.Error?.Headers.Print("Headers: ");
//response.Error?.HttpMethod.Print("HttpMethod: ");
//(await response.Error?.GetContentAsAsync<HearthstoneError>()).Print("GetContentAsAsync: ");

#endregion  Not throwing