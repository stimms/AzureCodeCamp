using Moq;
using NLog;
using Xunit;
using System;
using Autofac;
using System.Linq;
using SharpTestsEx;
using System.Collections.Generic;
using PancakeProwler.Data.Common;
using PancakeProwler.Web.Controllers;
using PancakeProwler.Data.Common.Repositories;

namespace PancakeProwler.Web.Tests
{
    public class When_registering_container
    {
        [Fact]
        public void A_container_is_built()
        {
            var builder = new PancakeProwler.Web.ContainerBuilder();
            builder.BuildContainer(new Mock<NLog.Logger>().Object).Should().Not.Be.Null();
        }

        [Fact]
        public void Data_layer_configurator_is_registered()
        {
            var builder = new PancakeProwler.Web.ContainerBuilder();
            var container = builder.BuildContainer(new Mock<NLog.Logger>().Object);
            container.IsRegistered<IDataLayerConfigurator>();
        }

        [Fact]
        public void Meal_repository_is_registered()
        {
            var builder = new PancakeProwler.Web.ContainerBuilder();
            var container = builder.BuildContainer(new Mock<NLog.Logger>().Object);
            container.IsRegistered<IMealRepository>();
        }

        [Fact]
        public void Recipe_repository_is_registered()
        {
            var builder = new PancakeProwler.Web.ContainerBuilder();
            var container = builder.BuildContainer(new Mock<NLog.Logger>().Object);
            container.IsRegistered<IRecipeRepository>();
        }

        [Fact]
        public void Meal_controller_is_registered()
        {
            var builder = new PancakeProwler.Web.ContainerBuilder();
            var container = builder.BuildContainer(new Mock<NLog.Logger>().Object);
            container.IsRegistered<MealController>();
        }

        [Fact]
        public void Recipe_controller_is_registered()
        {
            var builder = new PancakeProwler.Web.ContainerBuilder();
            var container = builder.BuildContainer(new Mock<NLog.Logger>().Object);
            container.IsRegistered<RecipeController>();
        }

        [Fact]
        public void Logger_is_registered()
        {
            var builder = new PancakeProwler.Web.ContainerBuilder();
            var container = builder.BuildContainer(new Mock<NLog.Logger>().Object);
            container.IsRegistered<Logger>();
        }
    }
}
