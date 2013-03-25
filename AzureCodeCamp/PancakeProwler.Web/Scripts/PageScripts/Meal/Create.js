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
                        $.ajax({
                            url: 'http://dev.virtualearth.net/REST/v1/Locations/CA/AB/-/Calgary/' + encodeURIComponent(_this.addressBox.val()) + '?maxResults=1&key=AppR9q-SG6Qtlh_6Nh6ZB2swEwxHmbbZeakhYvQAMRrYR384NFRghT5uybCR-ehX&JsonType=callback',
                            dataType: 'jsonp',
                            jsonpCallback: "jsoncallback",
                            success: function (result) {
                                _this.latitude.val(result.resourceSets[0].resources[0].point.coordinates[0]);
                                _this.longitude.val(result.resourceSets[0].resources[0].point.coordinates[1]);
                            },
                            jsonp: 'jsonp'
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
