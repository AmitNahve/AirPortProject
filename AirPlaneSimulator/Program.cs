
await RunInBackground(TimeSpan.FromSeconds(10), () => CreateAirPlane());

async Task RunInBackground(TimeSpan timeSpan, Action action)
{
    var periodicTimer = new PeriodicTimer(timeSpan);
    while (await periodicTimer.WaitForNextTickAsync())
    {
        action();
    }
}


void CreateAirPlane()
{
    var departure = "http://localhost:5252/api/airport/AddDepartureFlight";
    var landing=  " http://localhost:5252/api/airport/AddLandingFlight";
    string[] links = { departure , landing };
    var rnd = new Random();
    var rndLink = rnd.Next(links.Length);
var httpClient = new HttpClient();
    var response = httpClient.GetAsync(links[rndLink]);

}
