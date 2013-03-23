var PancakeProwler;
(function (PancakeProwler) {
    (function (Home) {
        (function (Index) {
            var BingMap = (function () {
                function BingMap(Events, OnClickHandler) {
                    this.Events = Events;
                    this.OnClickHandler = OnClickHandler;
                }
                BingMap.prototype.Bindmap = function () {
                    this.map.entities.clear();
                    this.Events.forEach(function (event) {
                        var eventLocation = event.Location;
                        var geoLocation = new Microsoft.Maps.Location(eventLocation.Lat, eventLocation.Long);
                        var pushpin = new Microsoft.Maps.Pushpin(geoLocation);
                        pushpin.EventId = event.Id;
                        this.map.entities.push(pushpin);
                        var infoBox = new Microsoft.Maps.Infobox(geoLocation, {
                            title: event.Title,
                            titleClickHandler: this.OnClickHandler(event),
                            description: event.Description,
                            pushpin: pushpin
                        });
                        this.map.entities.push(infoBox);
                    });
                };
                BingMap.prototype.Init = function () {
                    var _this = this;
                    Microsoft.Maps.loadModule('Microsoft.Maps.Themes.BingTheme', {
                        callback: function () {
                            _this.map = new Microsoft.Maps.Map(document.getElementById("pancake_map"), {
                                credentials: "AppR9q-SG6Qtlh_6Nh6ZB2swEwxHmbbZeakhYvQAMRrYR384NFRghT5uybCR-ehX",
                                center: new Microsoft.Maps.Location(51.0175, -114.0669),
                                zoom: 10,
                                theme: new Microsoft.Maps.Themes.BingTheme(),
                                enableSearchLogo: false,
                                showBreadcrumb: false
                            });
                            _this.Bindmap();
                        }
                    });
                };
                return BingMap;
            })();
            Index.BingMap = BingMap;            
        })(Home.Index || (Home.Index = {}));
        var Index = Home.Index;
    })(PancakeProwler.Home || (PancakeProwler.Home = {}));
    var Home = PancakeProwler.Home;
})(PancakeProwler || (PancakeProwler = {}));
