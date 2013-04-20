/// <reference path="../../typings/jquery/jquery.d.ts" />

module PancakeProwler.Meal.Create {
    export class ReverseGeoCoder {
        constructor(public addressBox, public latitude, public longitude) {

        }

        Init() {
            this.addressBox.blur(() => {
                $(".error").addClass("hidden");
                $(".success").addClass("hidden");
                $(".loading").removeClass("hidden");
               
                $.ajax({
                    url: 'http://dev.virtualearth.net/REST/v1/Locations/CA/AB/-/Calgary/' + encodeURIComponent(this.addressBox.val()) + '?maxResults=1&key=AppR9q-SG6Qtlh_6Nh6ZB2swEwxHmbbZeakhYvQAMRrYR384NFRghT5uybCR-ehX&JsonType=callback',
                    dataType: 'jsonp', jsonpCallback: "jsoncallback", success: (result) => {
                        $(".loading").addClass("hidden");
                        
                        if (result.resourceSets[0].estimatedTotal > 0) {
                            this.latitude.val(result.resourceSets[0].resources[0].point.coordinates[0]);
                            this.longitude.val(result.resourceSets[0].resources[0].point.coordinates[1]);
                            $(".success").removeClass("hidden");
                        }
                        else {
                            $(".error").removeClass("hidden");
                        }
                    },
                    jsonp: 'jsonp',
                    error: () => {
                        $(".loading").addClass("hidden");
                        $(".error").removeClass("hidden");
                    }
                });
            });
        }

    }

}