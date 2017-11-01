using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;

namespace HeritageWalks.Activities
{
    class MapsActivity : Activity, IOnMapReadyCallback 
    {
        private LatLngBounds AUSTRALIA = new LatLngBounds(
       new LatLng(-44, 113), new LatLng(-10, 154));

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            MapFragment mapFragment = (MapFragment)FragmentManager.FindFragmentById(Resource.Id.map);
            mapFragment.GetMapAsync(this);
        }
        // Instantiates the map
        public void OnMapReady(GoogleMap googleMap)
        {

            //Coordinates seat
            LatLng claremontMarker1 = new LatLng(-31.9798264, 115.7799933); //Coordinates for Claremont
            LatLng claremontMarker2 = new LatLng(-31.980699, 115.7813756); //Coordinates for Claremont but a different spot

            //commands for centering the camera on startup to focus on the pre-existing marker
            CameraUpdate camera = CameraUpdateFactory.NewLatLngZoom(claremontMarker1, 15); //This is a preset location and zoom for the following command to call
            googleMap.MoveCamera(camera); //calls the above coordinates and zoom level to move the camera too


            //Here-in includes all the options and widgets for the first marker
            MarkerOptions markerOptions = new MarkerOptions();
            markerOptions.SetPosition(claremontMarker1); //Latitude and Longitude of marker
            markerOptions.SetTitle("Claremont Trails"); //Title of Marker
            markerOptions.SetSnippet("Start Here"); //Subtext on marker, the smaller grey text
            googleMap.AddMarker(markerOptions);

            MarkerOptions markerOptions2 = new MarkerOptions();
            markerOptions2.SetPosition(claremontMarker2);
            markerOptions2.SetTitle("Claremont Trails Finish");
            markerOptions2.SetSnippet("End Here");
            googleMap.AddMarker(markerOptions2);

            //Optional fluff to do with how the user can interact with the maps
            googleMap.UiSettings.ZoomControlsEnabled = true; //Allow people to control their own Zooming
            googleMap.UiSettings.CompassEnabled = true;
            googleMap.UiSettings.ZoomGesturesEnabled = false; //disables people double tapping the screen to zoom in
            googleMap.UiSettings.MapToolbarEnabled = false; //disables two buttons that would create intents in the actual google maps application


        }
    }
}