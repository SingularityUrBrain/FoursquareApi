protected async Task InitGeolocate()
{
    TimeSpan check = new TimeSpan(0, 0, 10);
    var locator = CrossGeolocator.Current;

    var position = await locator.GetPositionAsync(check);
    App1.ViewModels.FoursquareViewModel.constLat = position.Latitude.ToString();
    App1.ViewModels.FoursquareViewModel.constLtd = position.Longitude.ToString();
}