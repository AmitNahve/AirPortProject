
using Models;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Nodes;

await RunInBackground(TimeSpan.FromSeconds(4), () => CreateAirPlaneAsync());

async Task RunInBackground(TimeSpan timeSpan, Action action)
{
    var periodicTimer = new PeriodicTimer(timeSpan);
    while (await periodicTimer.WaitForNextTickAsync())
    {
        action();
    }
}


async void CreateAirPlaneAsync()
{
    //var departure = "http://localhost:5252/api/airport/AddDepartureFlight";
    var landingLink = " http://localhost:5252/api/airport/AddLandingFlight";
    //string[] links = { departure, landingLink };
    Random rnd = new Random();
   // var rndLink = rnd.Next(links.Length);
    HttpClient httpClient = new HttpClient();

    var flight = new Flight
    {
        PassengersCount = rnd.Next(100, 500),
        Target = Shared.Target.Landing
    };
    // Serialize our concrete class into a JSON String
    var stringFlight = JsonConvert.SerializeObject(flight);
    // Wrap our JSON inside a StringContent which then can be used by the HttpClient class
    var httpContent = new StringContent(stringFlight, Encoding.UTF8, "application/json");
    // Do the actual request and await the response
    var httpResponse = await httpClient.PostAsync(landingLink, httpContent);




}
