using Moq;
using NLog;
using System;
using Autofac;
using System.Linq;
using SharpTestsEx;
using System.Collections.Generic;
using PancakeProwler.Data.Common;
using PancakeProwler.Web.Controllers;
using PancakeProwler.Data.Common.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PancakeProwler.Web.Tests
{
    [TestClass]
    public class When_registering_container
    {
        [TestMethod]
        public void A_container_is_built()
        {
            var builder = new PancakeProwler.Web.ContainerBuilder();
            builder.BuildContainer(new Mock<NLog.Logger>().Object).Should().Not.Be.Null();
        }

        [TestMethod]
        public void Data_layer_configurator_is_registered()
        {
            var builder = new PancakeProwler.Web.ContainerBuilder();
            var container = builder.BuildContainer(new Mock<NLog.Logger>().Object);
            container.IsRegistered<IDataLayerConfigurator>();
        }

        [TestMethod]
        public void Meal_repository_is_registered()
        {
            var builder = new PancakeProwler.Web.ContainerBuilder();
            var container = builder.BuildContainer(new Mock<NLog.Logger>().Object);
            container.IsRegistered<IMealRepository>();
        }

        [TestMethod]
        public void Recipe_repository_is_registered()
        {
            var builder = new PancakeProwler.Web.ContainerBuilder();
            var container = builder.BuildContainer(new Mock<NLog.Logger>().Object);
            container.IsRegistered<IRecipeRepository>();
        }

        [TestMethod]
        public void Meal_controller_is_registered()
        {
            var builder = new PancakeProwler.Web.ContainerBuilder();
            var container = builder.BuildContainer(new Mock<NLog.Logger>().Object);
            container.IsRegistered<MealController>();
        }

        [TestMethod]
        public void Recipe_controller_is_registered()
        {
            var builder = new PancakeProwler.Web.ContainerBuilder();
            var container = builder.BuildContainer(new Mock<NLog.Logger>().Object);
            container.IsRegistered<RecipeController>();
        }

        [TestMethod]
        public void Logger_is_registered()
        {
            var builder = new PancakeProwler.Web.ContainerBuilder();
            var container = builder.BuildContainer(new Mock<NLog.Logger>().Object);
            container.IsRegistered<Logger>();
        }
    }
}
