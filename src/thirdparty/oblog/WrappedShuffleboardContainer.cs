﻿using System;
using System.Collections.Generic;
using System.Text;
using WPILib.Shuffleboard;
using WPILib.SmartDashboard;

namespace WPILib.Oblog
{
    class WrappedShuffleboardContainer : IShuffleboardContainerWrapper
    {
        private readonly IShuffleboardContainer container;

        public WrappedShuffleboardContainer(IShuffleboardContainer container)
        {
            this.container = container;
        }

        public ISimpleWidgetWrapper Add<T>(string title, T defaultValue)
        {
            throw new NotImplementedException();
        }

        public IComplexWidgetWrapper Add(string title, ISendable defaultValue)
        {
            throw new NotImplementedException();
        }

        public IShuffleboardLayoutWrapper GetLayout(string title, ILayoutType type)
        {
            return new WrappedShuffleboardLayout(container.GetLayout(title, type));
        }
    }
}
