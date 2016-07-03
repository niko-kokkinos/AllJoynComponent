﻿// **************************************************************************** 
// <author>Niko Kokkinos</author> 
// <email>nik.kokkinos@outlook.com</email> 
// <date>02.07.2016</date> 
// <project>nikokokkinos.AllJoynComponent</project> 
// <web>http://nikolaoskokkinos.wordpress.com/</web> 
// ****************************************************************************

namespace nikokkinos.AllJoynComponent
{
    using AllJoynClientLib;
    using AllJoynClientLib.Devices;

    class AllJoynDiscoveryService
    {
        internal bool IsLifxLampPresent { get; private set; }
        internal LifxLamp LifxLamp { get; private set; } = new LifxLamp();
   
        private DeviceManager _deviceManager;

        internal DeviceManager DeviceManager
        {
            get { return _deviceManager ?? (_deviceManager = new DeviceManager()); }
            set { _deviceManager = value; }
        }

        internal AllJoynDiscoveryService()
        {
            this.DeviceManager.DeviceJoined += OnDeviceJoined;
        }

        private void OnDeviceJoined(object sender, DeviceClient device)
        {
            if (device is LightClient)
            {
                LifxLamp.LightClient = (LightClient)device;

                IsLifxLampPresent = true;
            }
        }

        internal void Start()
        {
            if (DeviceManager != null)
            {
                DeviceManager.Start();
            }
        }
    }
}