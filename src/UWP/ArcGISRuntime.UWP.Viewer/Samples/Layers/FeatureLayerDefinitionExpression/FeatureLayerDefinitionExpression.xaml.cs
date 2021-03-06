// Copyright 2016 Esri.
//
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License.
// You may obtain a copy of the License at: http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an 
// "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific 
// language governing permissions and limitations under the License.

using Esri.ArcGISRuntime.Data;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Mapping;
using System;
using Windows.UI.Xaml;

namespace ArcGISRuntime.UWP.Samples.FeatureLayerDefinitionExpression
{
    [ArcGISRuntime.Samples.Shared.Attributes.Sample(
        name: "Feature layer definition expression",
        category: "Layers",
        description: "Limit the features displayed on a map with a definition expression.",
        instructions: "Press the 'Apply Expression' button to limit the features requested from the feature layer to those specified by the SQL query definition expression. Click the 'Reset Expression' button to remove the definition expression on the feature layer, which returns all the records.",
        tags: new[] { "SQL", "definition expression", "filter", "limit data", "query", "restrict data", "where clause" })]
    public partial class FeatureLayerDefinitionExpression
    {
        // Create and hold reference to the feature layer
        private FeatureLayer _featureLayer;

        public FeatureLayerDefinitionExpression()
        {
            InitializeComponent();

            // Setup the control references and execute initialization 
            Initialize();
        }

        private void Initialize()
        {
            // Create new Map with basemap
            Map myMap = new Map(BasemapStyle.ArcGISTopographic);

            // Create a MapPoint the map should zoom to
            MapPoint mapPoint = new MapPoint(
                -13630484, 4545415, SpatialReferences.WebMercator);

            // Set the initial viewpoint for map
            myMap.InitialViewpoint = new Viewpoint(mapPoint, 90000);

            // Provide used Map to the MapView
            MyMapView.Map = myMap;

            // Create the uri for the feature service
            Uri featureServiceUri = new Uri(
                "https://sampleserver6.arcgisonline.com/arcgis/rest/services/SF311/FeatureServer/0");

            // Initialize feature table using a url to feature server url
            ServiceFeatureTable featureTable = new ServiceFeatureTable(featureServiceUri);

            // Initialize a new feature layer based on the feature table
            _featureLayer = new FeatureLayer(featureTable);

            // Add the feature layer to the map
            myMap.OperationalLayers.Add(_featureLayer);
  
        }

        private void OnApplyExpressionClicked(object sender, RoutedEventArgs e)
        {
            // Adding definition expression to show specific features only
            _featureLayer.DefinitionExpression = "req_Type = 'Tree Maintenance or Damage'";
        }

        private void OnResetButtonClicked(object sender, RoutedEventArgs e)
        {
            // Reset the definition expression to see all features again
            _featureLayer.DefinitionExpression = "";
        }
    }
}
