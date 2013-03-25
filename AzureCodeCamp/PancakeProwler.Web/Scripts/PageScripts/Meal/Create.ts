/// <reference path="../../typings/jquery/jquery.d.ts" />

module PancakeProwler.Meal.Create {
    export class ReverseGeoCoder {
        constructor(public addressBox, public latitude, public longitude) {

        }

        Init() {
            this.addressBox.blur( () => {
                $.ajax({
                    url: 'http://dev.virtualearth.net/REST/v1/Locations/CA/AB/-/Calgary/' + encodeURIComponent(this.addressBox.val()) + '?maxResults=1&key=AppR9q-SG6Qtlh_6Nh6ZB2swEwxHmbbZeakhYvQAMRrYR384NFRghT5uybCR-ehX&JsonType=callback',
                    dataType: 'jsonp', jsonpCallback: "jsoncallback", success: (result) => {
                        this.latitude.val(result.resourceSets[0].resources[0].point.coordinates[0]);
                        this.longitude.val(result.resourceSets[0].resources[0].point.coordinates[1]);
                    },
                    jsonp: 'jsonp'
                });
            });
        }

    }

}