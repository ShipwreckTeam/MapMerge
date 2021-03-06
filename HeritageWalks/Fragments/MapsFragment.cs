﻿using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Views;
using SupportFragment = Android.Support.V4.App.Fragment;
using System;


namespace HeritageWalks.Fragments
{
    public class MapsFragment : SupportFragment, IOnMapReadyCallback
    {
        //private GoogleMap _Map;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetUpMap();
        }

        private void SetUpMap()
        {
            //if (_Map == null)
            //{
            //    FragmentManager.FindFragmentById(Resource.Id.map);
            //}

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
             try
            {
                View view = inflater.Inflate(Resource.Layout.MapsFragment, container, false);
                SetUpMap();
                return view;
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            MapsInitializer.Initialize(this.Activity);
            LatLng sydney = new LatLng(-33.852, 151.211);
            googleMap.AddMarker(new MarkerOptions().SetPosition(sydney));
            googleMap.MoveCamera(CameraUpdateFactory.NewLatLng(sydney));
        }
    }
}