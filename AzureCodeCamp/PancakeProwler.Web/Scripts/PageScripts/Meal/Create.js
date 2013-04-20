var PancakeProwler;
(function (PancakeProwler) {
    (function (Meal) {
        (function (Create) {
            var ReverseGeoCoder = (function () {
                function ReverseGeoCoder(addressBox, latitude, longitude) {
                    this.addressBox = addressBox;
                    this.latitude = latitude;
                    this.longitude = longitude;
                }
                ReverseGeoCoder.prototype.Init = function () {
                    var _this = this;
                    this.addressBox.blur(function () {
                        $(".error").addClass("hidden");
                        $(".success").addClass("hidden");
                        $(".loading").removeClass("hidden");
                        $.ajax({
                            url: 'http://dev.virtualearth.net/REST/v1/Locations/CA/AB/-/Calgary/' + encodeURIComponent(_this.addressBox.val()) + '?maxResults=1&key=AppR9q-SG6Qtlh_6Nh6ZB2swEwxHmbbZeakhYvQAMRrYR384NFRghT5uybCR-ehX&JsonType=callback',
                            dataType: 'jsonp',
                            jsonpCallback: "jsoncallback",
                            success: function (result) {
                                $(".loading").addClass("hidden");
                                if(result.resourceSets[0].estimatedTotal > 0) {
                                    _this.latitude.val(result.resourceSets[0].resources[0].point.coordinates[0]);
                                    _this.longitude.val(result.resourceSets[0].resources[0].point.coordinates[1]);
                                    $(".success").removeClass("hidden");
                                } else {
                                    $(".error").removeClass("hidden");
                                }
                            },
                            jsonp: 'jsonp',
                            error: function () {
                                $(".loading").addClass("hidden");
                                $(".error").removeClass("hidden");
                            }
                        });
                    });
                };
                return ReverseGeoCoder;
            })();
            Create.ReverseGeoCoder = ReverseGeoCoder;            
        })(Meal.Create || (Meal.Create = {}));
        var Create = Meal.Create;
    })(PancakeProwler.Meal || (PancakeProwler.Meal = {}));
    var Meal = PancakeProwler.Meal;
})(PancakeProwler || (PancakeProwler = {}));
