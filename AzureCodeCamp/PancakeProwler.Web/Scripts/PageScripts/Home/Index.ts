declare var Microsoft: any;
module PancakeProwler.Home.Index {
    export class BingMap {
        
        map:any;

        constructor(public Events: any[], public OnClickHandler: (any)=>any) { }

        Bindmap() {
            //Add logic to actually display something on the map.
            //Will look something like this:
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
        Init() {
            Microsoft.Maps.loadModule('Microsoft.Maps.Themes.BingTheme', {
                callback:  () => {
                    this.map = new Microsoft.Maps.Map(document.getElementById("pancake_map"), {
                        //NOTE: This key belongs to the Calgary .NET User Group and is for educational purposes. For more information, contact David Paquette (Dave_Paquette on twitter)
                        credentials: "AppR9q-SG6Qtlh_6Nh6ZB2swEwxHmbbZeakhYvQAMRrYR384NFRghT5uybCR-ehX",
                        center: new Microsoft.Maps.Location(51.0175, -114.0669),
                        zoom: 10,
                        theme: new Microsoft.Maps.Themes.BingTheme(),
                        enableSearchLogo: false,
                        showBreadcrumb: false
                    });
                    this.Bindmap();
                }
            });
        }
    }
}