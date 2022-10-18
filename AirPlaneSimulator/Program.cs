
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
    var httpClient = new HttpClient();
    var response = httpClient.GetAsync("http://localhost:5166/api/airport");

}
