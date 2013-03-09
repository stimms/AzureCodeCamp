var PancakeProwler;
(function (PancakeProwler) {
    (function (Shared) {
        var Menu = (function () {
            function Menu(top) {
                this.top = top;
            }
            Menu.prototype.Init = function () {
                var location = top.location.toString();
                if(location.indexOf("Upcoming") > 0) {
                    $(".menu-upcoming").addClass("active");
                } else if(location.indexOf("Recipe") > 0) {
                    $(".menu-recipes").addClass("active");
                } else if(location.indexOf("Meal") > 0) {
                    $(".menu-meal").addClass("active");
                } else if(location.indexOf("About") > 0) {
                    $(".menu-about").addClass("active");
                } else {
                    $(".menu-today").addClass("active");
                }
            };
            return Menu;
        })();
        Shared.Menu = Menu;        
    })(PancakeProwler.Shared || (PancakeProwler.Shared = {}));
    var Shared = PancakeProwler.Shared;
})(PancakeProwler || (PancakeProwler = {}));
